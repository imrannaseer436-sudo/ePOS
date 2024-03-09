Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Public AppVersion As Short = 1117

        Private Sub LoadVersionPath()

            VersionPath = ""

            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\POSSettings.xml") = True Then

                Dim xRdr As New Xml.XmlTextReader(My.Application.Info.DirectoryPath & "\POSSettings.xml")
                While xRdr.Read
                    If xRdr.Name = "VersionPath" Then
                        VersionPath = xRdr.ReadElementString("VersionPath")
                    End If
                End While
                xRdr.Close()

            End If

        End Sub

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

            GetTheme(3)
            LoadVersionPath()

            If VersionPath = "" Then
                MsgBox("Version path not configured..!", MsgBoxStyle.Information)
            Else

                Try

                    Dim WC As New System.Net.WebClient

                    Dim NewVersion As String = WC.DownloadString(VersionPath)
                    If Val(NewVersion) > AppVersion Then
                        If MsgBox("Update available, Do you want to update..!", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Shell(Application.Info.DirectoryPath & "\" & "UniversalUpdater.exe", AppWinStyle.NormalFocus)
                            e.Cancel = True
                        End If
                    End If

                Catch ex As System.Net.WebException

                Catch ex1 As Exception

                End Try

            End If

        End Sub

    End Class

End Namespace

