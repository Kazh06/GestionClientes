Imports System.Runtime.CompilerServices
Imports GestionClientes.Entities

Public Module QueryableExtensions

    <Extension()>
    Public Function Paginar(Of T)(consulta As IQueryable(Of T), paginaActual As Integer, tamanoPagina As Integer) As ResultadoPaginado(Of T)
        Dim total As Integer = consulta.Count()
        Dim items As List(Of T) = consulta _
            .Skip(paginaActual * tamanoPagina) _
            .Take(tamanoPagina) _
            .ToList()

        Return New ResultadoPaginado(Of T) With {
            .Datos = items,
            .TotalRegistros = total,
            .paginaActual = paginaActual,
            .tamanoPagina = tamanoPagina
        }
    End Function

End Module