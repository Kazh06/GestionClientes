Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("Bitacora")>
Public Class Bitacora
    <Key>
    Public Property IdBitacora As Integer

    <Required, StringLength(20)>
    Public Property Accion As String

    Public Property IdCliente As Integer

    <StringLength(250)>
    Public Property Detalle As String

    Public Property FechaHora As DateTime = DateTime.Now

    <Required, StringLength(50)>
    Public Property NombreUsuario As String
End Class