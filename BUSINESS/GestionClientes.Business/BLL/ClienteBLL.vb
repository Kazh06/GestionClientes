Imports System.Text.RegularExpressions
Imports GestionClientes.Data
Imports GestionClientes.Entities

Public Class ClienteBLL

    Private ReadOnly _clienteDal As New ClienteDAL()

    Public Function ObtenerPaginado(paginaActual As Integer, tamanoPagina As Integer, Optional searchQuery As String = "") As ResultadoPaginado(Of Cliente)
        Return _clienteDal.ListarActivosPaginado(paginaActual, tamanoPagina, searchQuery)
    End Function

    Public Function ObtenerBitacoraPaginada(paginaActual As Integer, tamanoPagina As Integer, Optional searchQuery As String = "") As ResultadoPaginado(Of Bitacora)
        Return _clienteDal.ListarBitacoraPaginada(paginaActual, tamanoPagina, searchQuery)
    End Function

    Public Function ObtenerPorId(idCliente As Integer) As Cliente
        If idCliente <= 0 Then
            Throw New ArgumentException("El ID del cliente no es válido.")
        End If
        Return _clienteDal.ObtenerPorId(idCliente)
    End Function

    Public Function AgregarCliente(cliente As Cliente, nombreUsuario As String) As Boolean
        ValidarDatosCliente(cliente)

        If _clienteDal.ExisteDui(cliente.DUI) Then
            Throw New ArgumentException("Ya existe un cliente registrado con ese número de DUI.")
        End If

        Return _clienteDal.Agregar(cliente, nombreUsuario)
    End Function

    Public Function EditarCliente(cliente As Cliente, nombreUsuario As String) As Boolean
        If cliente.IdCliente <= 0 Then
            Throw New ArgumentException("El ID del cliente a editar no es válido.")
        End If

        ValidarDatosCliente(cliente)

        If _clienteDal.ExisteDui(cliente.DUI, cliente.IdCliente) Then
            Throw New ArgumentException("Ya existe otro cliente registrado con ese número de DUI.")
        End If

        Return _clienteDal.Editar(cliente, nombreUsuario)
    End Function

    Public Function EliminarCliente(idCliente As Integer, nombreUsuario As String) As Boolean
        If idCliente <= 0 Then
            Throw New ArgumentException("El ID del cliente a eliminar no es válido.")
        End If

        Return _clienteDal.Eliminar(idCliente, nombreUsuario)
    End Function

    Private Sub ValidarDatosCliente(cliente As Cliente)
        If String.IsNullOrWhiteSpace(cliente.Nombres) Then
            Throw New ArgumentException("El campo Nombres es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(cliente.Apellidos) Then
            Throw New ArgumentException("El campo Apellidos es obligatorio.")
        End If

        If String.IsNullOrWhiteSpace(cliente.DUI) Then
            Throw New ArgumentException("El campo DUI es obligatorio.")
        End If

        If Not Regex.IsMatch(cliente.DUI.Trim(), "^\d{8}-\d$") Then
            Throw New ArgumentException("El formato del DUI no es válido. Debe ser 00000000-0.")
        End If

        If Not String.IsNullOrWhiteSpace(cliente.Telefono) AndAlso
           Not Regex.IsMatch(cliente.Telefono.Trim(), "^\d{4}-\d{4}$") Then
            Throw New ArgumentException("El formato del teléfono no es válido. Debe ser 0000-0000.")
        End If

        If Not String.IsNullOrWhiteSpace(cliente.Correo) AndAlso
           Not Regex.IsMatch(cliente.Correo.Trim(), "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
            Throw New ArgumentException("El formato del correo electrónico no es válido.")
        End If
    End Sub

End Class