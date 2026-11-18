Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("Clientes")>
Public Class Cliente
    <Key>
    Public Property IdCliente As Integer

    <Required, StringLength(100)>
    Public Property Nombres As String

    <Required, StringLength(100)>
    Public Property Apellidos As String

    <Required, StringLength(10)>
    Public Property DUI As String

    <StringLength(15)>
    Public Property Telefono As String

    <StringLength(100)>
    Public Property Correo As String

    <StringLength(250)>
    Public Property Direccion As String

    Public Property Activo As Boolean = True
    Public Property FechaRegistro As DateTime = DateTime.Now
End Class