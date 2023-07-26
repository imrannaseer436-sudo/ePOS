Public Class ClsEncodeDecode

    Public Shared Function Encode(ByVal InputValue As String) As String

        Dim Tmp As String = ""

        For i As SByte = 1 To InputValue.Length
            Tmp &= Chr(Asc(Mid(InputValue, i, i)) + 17)
        Next

        Return Tmp

    End Function

    Public Shared Function DCode(ByVal InputValue As String) As String

        Dim Tmp As String = ""

        For i As SByte = 1 To InputValue.Length
            Tmp &= Chr(Asc(Mid(InputValue, i, i)) - 17)
        Next

        Return Tmp

    End Function

End Class
