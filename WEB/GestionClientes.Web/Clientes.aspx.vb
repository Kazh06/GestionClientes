Imports GestionClientes.Business
Imports GestionClientes.Entities

Public Class Clientes
    Inherits System.Web.UI.Page

    Private ReadOnly _clienteBll As New ClienteBLL()

    Private ReadOnly Property UsuarioActual As Usuario
        Get
            Return TryCast(Session("UsuarioLogueado"), Usuario)
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If UsuarioActual Is Nothing Then
            Response.Redirect("Login.aspx")
            Return
        End If

        If Not IsPostBack Then
            lblUsuarioActivo.Text = UsuarioActual.NombreCompleto
            CargarDatos()
        End If
    End Sub

    Private Sub CargarDatos()
        Dim resultadoClientes = _clienteBll.ObtenerPaginado(gvClientes.PageIndex, gvClientes.PageSize)
        gvClientes.VirtualItemCount = resultadoClientes.TotalRegistros
        gvClientes.DataSource = resultadoClientes.Datos
        gvClientes.DataBind()

        Dim resultadoBitacora = _clienteBll.ObtenerBitacoraPaginada(gvBitacora.PageIndex, gvBitacora.PageSize)
        gvBitacora.VirtualItemCount = resultadoBitacora.TotalRegistros
        gvBitacora.DataSource = resultadoBitacora.Datos
        gvBitacora.DataBind()
    End Sub

    Protected Sub gvClientes_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvClientes.PageIndex = e.NewPageIndex
        CargarDatos()
    End Sub

    Protected Sub gvBitacora_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvBitacora.PageIndex = e.NewPageIndex
        CargarDatos()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        pnlMensaje.Visible = False
        Try
            Dim idCliente As Integer = Convert.ToInt32(hfIdCliente.Value)
            Dim cliente As New Cliente() With {
                .IdCliente = idCliente,
                .Nombres = txtNombres.Text.Trim(),
                .Apellidos = txtApellidos.Text.Trim(),
                .DUI = txtDui.Text.Trim(),
                .Telefono = txtTelefono.Text.Trim(),
                .Correo = txtCorreo.Text.Trim(),
                .Direccion = txtDireccion.Text.Trim()
            }

            Dim exito As Boolean
            If idCliente = 0 Then
                exito = _clienteBll.AgregarCliente(cliente, UsuarioActual.NombreUsuario)
                If exito Then
                    MostrarNotificacion("Cliente agregado correctamente.", True)
                Else
                    MostrarNotificacion("No se pudo registrar el cliente.", False)
                End If
            Else
                exito = _clienteBll.EditarCliente(cliente, UsuarioActual.NombreUsuario)
                If exito Then
                    MostrarNotificacion("Cliente actualizado correctamente.", True)
                Else
                    MostrarNotificacion("No se encontró el cliente para actualizar.", False)
                End If
            End If

            If exito Then
                LimpiarFormulario()
                CargarDatos()
            End If

        Catch ex As ArgumentException
            MostrarNotificacion(ex.Message, False)
        Catch ex As Exception
            MostrarNotificacion("Ocurrió un error inesperado: " & ex.Message, False)
        End Try
    End Sub

    Protected Sub gvClientes_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        pnlMensaje.Visible = False
        Dim idCliente As Integer = Convert.ToInt32(e.CommandArgument)

        Try
            If e.CommandName = "EditarCliente" Then
                Dim cliente = _clienteBll.ObtenerPorId(idCliente)
                If cliente IsNot Nothing Then
                    hfIdCliente.Value = cliente.IdCliente.ToString()
                    txtNombres.Text = cliente.Nombres
                    txtApellidos.Text = cliente.Apellidos
                    txtDui.Text = cliente.DUI
                    txtTelefono.Text = cliente.Telefono
                    txtCorreo.Text = cliente.Correo
                    txtDireccion.Text = cliente.Direccion
                    lblTituloFormulario.Text = $"Editando Cliente #{cliente.IdCliente}"
                    btnGuardar.Text = "Actualizar"
                End If

            ElseIf e.CommandName = "EliminarCliente" Then
                Dim eliminado As Boolean = _clienteBll.EliminarCliente(idCliente, UsuarioActual.NombreUsuario)
                If eliminado Then
                    MostrarNotificacion("Cliente eliminado correctamente.", True)
                    LimpiarFormulario()
                    CargarDatos()
                Else
                    MostrarNotificacion("No se pudo eliminar el cliente.", False)
                End If
            End If

        Catch ex As Exception
            MostrarNotificacion("Error al procesar la acción: " & ex.Message, False)
        End Try
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        pnlMensaje.Visible = False
        LimpiarFormulario()
    End Sub

    Protected Sub btnCerrarSesion_Click(sender As Object, e As EventArgs)
        Session.Clear()
        Session.Abandon()
        Response.Redirect("Login.aspx")
    End Sub

    Private Sub LimpiarFormulario()
        hfIdCliente.Value = "0"
        txtNombres.Text = String.Empty
        txtApellidos.Text = String.Empty
        txtDui.Text = String.Empty
        txtTelefono.Text = String.Empty
        txtCorreo.Text = String.Empty
        txtDireccion.Text = String.Empty
        lblTituloFormulario.Text = "Nuevo Cliente"
        btnGuardar.Text = "Guardar"
    End Sub

    Private Sub MostrarNotificacion(mensaje As String, esExito As Boolean)
        lblMensaje.Text = mensaje
        pnlMensaje.CssClass = If(esExito, "alert alert-success", "alert alert-danger")
        pnlMensaje.Visible = True
    End Sub

End Class