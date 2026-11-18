Imports System.Security.Cryptography
Imports System.Text

Public Class SeguridadHelper

    Public Shared Function GenerarSha256(textoPlano As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(textoPlano)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            Dim sb As New StringBuilder()
            For Each b As Byte In hash
                sb.Append(b.ToString("X2"))
            Next
            Return sb.ToString()
        End Using
    End Function

End Class