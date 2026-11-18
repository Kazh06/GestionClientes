Public Class ResultadoPaginado(Of T)
    Public Property Datos As List(Of T)
    Public Property TotalRegistros As Integer
    Public Property PaginaActual As Integer
    Public Property TamanoPagina As Integer
End Class