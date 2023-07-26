'************************************************ Bismillah *****************************************
'Imports Microsoft.PointOfService
Public Class PrinterTesting

    '    'Private Sub btnConnectPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnectPrinter.Click

    '    Dim PosEx As New PosExplorer
    '    Dim PosDv As DeviceInfo
    '    Dim PosPr As PosPrinter
    '    Dim Resut As String = ""

    '        Try
    '            PosDv = PosEx.GetDevice("PosPrinter")
    '            PosPr = PosEx.CreateInstance(PosDv)
    '            Resut = "Passed : Object Initialization..!" & vbCrLf
    '        Catch ex As PosException
    '            Resut = "Failed : Object Initialization..!" & vbCrLf _
    '                  & "Error  :" & ex.Message
    '            GoTo er
    '        Catch ex1 As Exception
    '            Resut = "Failed : Object Initialization..!" & vbCrLf _
    '                  & "Error  :" & ex1.Message
    '            GoTo er
    '        End Try

    '        Try

    '            PosPr.Open()
    '            Resut &= "Passed : Device Open...!" & vbCrLf
    '            PosPr.Claim(1000)
    '            Resut &= "Passed : Device Claim...!" & vbCrLf
    '            PosPr.DeviceEnabled = True
    '            Resut &= "Passed : Device Device Enable...!" & vbCrLf

    '            PosPr.Close()
    '            PosPr.DeviceEnabled = False
    '            PosPr.Release()

    '        Catch ex As PosControlException
    '            Resut &= "Error  :" & ex.Message
    '        Catch ex1 As Exception
    '            Resut &= "Error  :" & ex1.Message
    '        End Try

    'Er:
    '        MsgBox(Resut, vbExclamation)

    '    End Sub

End Class