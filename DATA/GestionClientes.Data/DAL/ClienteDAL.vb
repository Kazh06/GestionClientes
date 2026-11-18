Imports GestionClientes.Entities

Public Class ClienteDAL

    Public Function ListarActivosPaginado(paginaActual As Integer, tamanoPagina As Integer) As ResultadoPaginado(Of Cliente)
        Using db As New GestionClientesContext()
            Return db.Clientes _
                     .Where(Function(c) c.Activo = True) _
                     .OrderByDescending(Function(c) c.IdCliente) _
                     .Paginar(paginaActual, tamanoPagina)
        End Using
    End Function

    Public Function ListarBitacoraPaginada(paginaActual As Integer, tamanoPagina As Integer) As ResultadoPaginado(Of Bitacora)
        Using db As New GestionClientesContext()
            Return db.Bitacora _
                     .OrderByDescending(Function(b) b.FechaHora) _
                     .Paginar(paginaActual, tamanoPagina)
        End Using
    End Function

    Public Function ObtenerPorId(idCliente As Integer) As Cliente
        Using db As New GestionClientesContext()
            Return db.Clientes.FirstOrDefault(Function(c) c.IdCliente = idCliente AndAlso c.Activo = True)
        End Using
    End Function

    Public Function ExisteDui(dui As String, Optional idClienteExcluir As Integer = 0) As Boolean
        Using db As New GestionClientesContext()
            Return db.Clientes.Any(Function(c) c.DUI = dui AndAlso c.Activo = True AndAlso c.IdCliente <> idClienteExcluir)
        End Using
    End Function

    Public Function Agregar(cliente As Cliente, nombreUsuario As String) As Boolean
        Using db As New GestionClientesContext()
            Using tx = db.Database.BeginTransaction()
                Try
                    cliente.Activo = True
                    cliente.FechaRegistro = DateTime.Now
                    db.Clientes.Add(cliente)
                    Dim filasCliente = db.SaveChanges()

                    Dim log As New Bitacora() With {
                        .Accion = "AGREGAR",
                        .IdCliente = cliente.IdCliente,
                        .Detalle = $"Se registró el cliente: {cliente.Nombres} {cliente.Apellidos}",
                        .FechaHora = DateTime.Now,
                        .nombreUsuario = nombreUsuario
                    }
                    db.Bitacora.Add(log)
                    Dim filasLog = db.SaveChanges()

                    tx.Commit()
                    Return (filasCliente > 0 AndAlso filasLog > 0)
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Function

    Public Function Editar(clienteEditado As Cliente, nombreUsuario As String) As Boolean
        Using db As New GestionClientesContext()
            Using tx = db.Database.BeginTransaction()
                Try
                    Dim clienteDb = db.Clientes.FirstOrDefault(Function(c) c.IdCliente = clienteEditado.IdCliente AndAlso c.Activo = True)
                    If clienteDb Is Nothing Then Return False

                    clienteDb.Nombres = clienteEditado.Nombres
                    clienteDb.Apellidos = clienteEditado.Apellidos
                    clienteDb.DUI = clienteEditado.DUI
                    clienteDb.Telefono = clienteEditado.Telefono
                    clienteDb.Correo = clienteEditado.Correo
                    clienteDb.Direccion = clienteEditado.Direccion

                    Dim log As New Bitacora() With {
                        .Accion = "EDITAR",
                        .IdCliente = clienteDb.IdCliente,
                        .Detalle = $"Se actualizó el cliente: {clienteDb.Nombres} {clienteDb.Apellidos}",
                        .FechaHora = DateTime.Now,
                        .nombreUsuario = nombreUsuario
                    }
                    db.Bitacora.Add(log)
                    Dim filas = db.SaveChanges()

                    tx.Commit()
                    Return filas > 0
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Function

    Public Function Eliminar(idCliente As Integer, nombreUsuario As String) As Boolean
        Using db As New GestionClientesContext()
            Using tx = db.Database.BeginTransaction()
                Try
                    Dim clienteDb = db.Clientes.FirstOrDefault(Function(c) c.IdCliente = idCliente AndAlso c.Activo = True)
                    If clienteDb Is Nothing Then Return False

                    clienteDb.Activo = False

                    Dim log As New Bitacora() With {
                        .Accion = "ELIMINAR",
                        .idCliente = clienteDb.IdCliente,
                        .Detalle = $"Se eliminó el cliente: {clienteDb.Nombres} {clienteDb.Apellidos}",
                        .FechaHora = DateTime.Now,
                        .nombreUsuario = nombreUsuario
                    }
                    db.Bitacora.Add(log)
                    Dim filas = db.SaveChanges()

                    tx.Commit()
                    Return filas > 0
                Catch
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Function

End Class