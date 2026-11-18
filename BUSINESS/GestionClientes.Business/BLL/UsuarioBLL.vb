Imports GestionClientes.Data
Imports GestionClientes.Entities

Public Class UsuarioBLL

    Private ReadOnly _usuarioDal As New UsuarioDAL()

    Public Function ValidarLogin(nombreUsuario As String, contrasena As String) As Usuario
        If String.IsNullOrWhiteSpace(nombreUsuario) OrElse String.IsNullOrWhiteSpace(contrasena) Then
            Throw New ArgumentException("Debe ingresar el usuario y la contraseña.")
        End If

        Dim usuario = _usuarioDal.ObtenerPorNombreUsuario(nombreUsuario.Trim())
        If usuario Is Nothing Then
            Return Nothing
        End If

        Dim hashIngresado = SeguridadHelper.GenerarSha256(contrasena)
        If String.Equals(usuario.ContrasenaHash, hashIngresado, StringComparison.OrdinalIgnoreCase) Then
            Return usuario
        End If

        Return Nothing
    End Function

End Class