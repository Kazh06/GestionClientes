Imports GestionClientes.Business
Imports GestionClientes.Entities

Public Class Login
    Inherits System.Web.UI.Page

    Private ReadOnly _usuarioBll As New UsuarioBLL()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("UsuarioLogueado") IsNot Nothing Then
                Response.Redirect("Clientes.aspx")
            End If
        End If
    End Sub

    Protected Sub btnIngresar_Click(sender As Object, e As EventArgs)
        pnlError.Visible = False
        Try
            Dim usuario As Usuario = _usuarioBll.ValidarLogin(txtUsuario.Text, txtContrasena.Text)

            If usuario IsNot Nothing Then
                Session("UsuarioLogueado") = usuario
                Response.Redirect("Clientes.aspx")
            Else
                MostrarError("Usuario o contraseña incorrectos.")
            End If
        Catch ex As ArgumentException
            MostrarError(ex.Message)
        Catch ex As Exception
            Dim detalle = If(ex.InnerException IsNot Nothing, ex.InnerException.Message, ex.Message)
            MostrarError("Error al conectar con el servidor: " & detalle)
        End Try
    End Sub

    Private Sub MostrarError(mensaje As String)
        lblError.Text = mensaje
        pnlError.Visible = True
    End Sub

End Class