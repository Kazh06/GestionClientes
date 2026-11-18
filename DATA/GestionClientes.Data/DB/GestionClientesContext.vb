Imports System.Data.Entity
Imports GestionClientes.Entities

Public Class GestionClientesContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=ConexionDB")
    End Sub

    Public Property Usuarios As DbSet(Of Usuario)
    Public Property Clientes As DbSet(Of Cliente)
    Public Property Bitacora As DbSet(Of Bitacora)

End Class