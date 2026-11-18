Imports GestionClientes.Entities

Public Class UsuarioDAL

    Public Function ObtenerPorNombreUsuario(nombreUsuario As String) As Usuario
        Using db As New GestionClientesContext()
            Return db.Usuarios.FirstOrDefault(Function(u) u.NombreUsuario = nombreUsuario AndAlso u.Activo = True)
        End Using
    End Function

End Class