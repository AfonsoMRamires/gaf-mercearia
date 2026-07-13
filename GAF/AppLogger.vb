Imports System.IO

''' <summary>
''' Monthly rotating file logger. One file per month (GAF_yyyy-MM.log) written to the
''' executable directory. Built-in StreamWriter — no external dependencies.
''' Thread-safe via SyncLock. Logging never throws to the caller.
''' </summary>
Public Module AppLogger

    Private ReadOnly _lock As New Object()
    Private _currentMonth As String = String.Empty
    Private _writer As StreamWriter = Nothing

    Public Sub Info(ByVal context As String, ByVal msg As String)
        WriteEntry("INFO", context, msg)
    End Sub

    Public Sub Warn(ByVal context As String, ByVal msg As String)
        WriteEntry("WARN", context, msg)
    End Sub

    Public Sub [Error](ByVal context As String, ByVal ex As Exception)
        WriteEntry("ERROR", context, ex.Message & " | " & ex.StackTrace)
    End Sub

    Public Sub [Error](ByVal context As String, ByVal msg As String)
        WriteEntry("ERROR", context, msg)
    End Sub

    Public Sub Close()
        SyncLock _lock
            If _writer IsNot Nothing Then
                _writer.Flush()
                _writer.Close()
                _writer = Nothing
            End If
        End SyncLock
    End Sub

    Private Sub WriteEntry(ByVal level As String, ByVal context As String, ByVal msg As String)
        SyncLock _lock
            Try
                EnsureWriter()
                _writer.WriteLine(String.Format("{0:yyyy-MM-dd HH:mm:ss} [{1,-5}] [{2}] {3}",
                                                 DateTime.Now, level, context, msg))
                _writer.Flush()
            Catch
                ' Logging must never crash the application.
            End Try
        End SyncLock
    End Sub

    Private Sub EnsureWriter()
        Dim thisMonth As String = DateTime.Now.ToString("yyyy-MM")
        If thisMonth <> _currentMonth OrElse _writer Is Nothing Then
            ' Month rolled over (or first write) — close old writer, open new file.
            If _writer IsNot Nothing Then
                _writer.Flush()
                _writer.Close()
                _writer = Nothing
            End If
            _currentMonth = thisMonth
            ' Write under %LocalAppData%\GAF, not the exe directory — the latter is
            ' often non-writable (e.g. Program Files), which would silently drop logs.
            Dim logDir As String = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GAF")
            Directory.CreateDirectory(logDir)
            Dim logPath As String = Path.Combine(logDir, "GAF_" & thisMonth & ".log")
            _writer = New StreamWriter(logPath, append:=True, encoding:=System.Text.Encoding.UTF8)
        End If
    End Sub

End Module
