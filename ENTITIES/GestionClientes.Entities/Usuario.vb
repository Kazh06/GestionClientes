Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("Usuarios")>
Public Class Usuario
    <Key>
    Public Property IdUsuario As Integer

    <Required, StringLength(50)>
    Public Property NombreUsuario As String

    <Required, StringLength(255)>
    Public Property ContrasenaHash As String

    <Required, StringLength(100)>
    Public Property NombreCompleto As String

    Public Property Activo As Boolean = True
    Public Property FechaCreacion As DateTime = DateTime.Now
End Class