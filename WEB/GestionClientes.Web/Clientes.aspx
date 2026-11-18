<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Clientes.aspx.vb" Inherits="GestionClientes.Web.Clientes" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Gestión de Clientes - FUNDAMICRO</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .pagination-ys table > tbody > tr > td {
            display: inline;
        }
        .pagination-ys table > tbody > tr > td > a,
        .pagination-ys table > tbody > tr > td > span {
            position: relative;
            float: left;
            padding: 5px 11px;
            line-height: 1.42857143;
            color: #0d6efd;
            text-decoration: none;
            background-color: #fff;
            border: 1px solid #dee2e6;
            margin: 8px 2px;
            border-radius: 4px;
        }
        .pagination-ys table > tbody > tr > td > span {
            z-index: 3;
            color: #fff;
            cursor: default;
            background-color: #0d6efd;
            border-color: #0d6efd;
        }
        .pagination-ys table > tbody > tr > td > a:hover {
            background-color: #e9ecef;
            border-color: #dee2e6;
        }
    </style>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <!-- Barra superior -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary shadow-sm mb-4">
            <div class="container">
                <a class="navbar-brand fw-bold" href="#">FUNDAMICRO | Gestión de Clientes</a>
                <div class="d-flex align-items-center text-white">
                    <span class="me-3 small">Bienvenido, <strong><asp:Label ID="lblUsuarioActivo" runat="server"></asp:Label></strong></span>
                    <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" CssClass="btn btn-outline-light btn-sm" OnClick="btnCerrarSesion_Click" CausesValidation="false" />
                </div>
            </div>
        </nav>

        <div class="container pb-5">
            <!-- Alertas de notificación -->
            <asp:Panel ID="pnlMensaje" runat="server" Visible="false" CssClass="alert alert-dismissible fade show" role="alert">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </asp:Panel>

            <div class="row g-4">
                <!-- Formulario de Cliente (Izquierda) -->
                <div class="col-lg-4">
                    <div class="card shadow-sm border-0">
                        <div class="card-header bg-white fw-bold py-3">
                            <asp:Label ID="lblTituloFormulario" runat="server" Text="Nuevo Cliente"></asp:Label>
                        </div>
                        <div class="card-body">
                            <asp:HiddenField ID="hfIdCliente" runat="server" Value="0" />

                            <div class="mb-3">
                                <label class="form-label small fw-semibold">Nombres *</label>
                                <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control form-control-sm" MaxLength="100"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <label class="form-label small fw-semibold">Apellidos *</label>
                                <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control form-control-sm" MaxLength="100"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <label class="form-label small fw-semibold">DUI (00000000-0) *</label>
                                <asp:TextBox ID="txtDui" runat="server" CssClass="form-control form-control-sm" MaxLength="10" inputmode="numeric" placeholder="00000000-0"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <label class="form-label small fw-semibold">Teléfono</label>
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control form-control-sm" MaxLength="9" inputmode="numeric" placeholder="0000-0000"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <label class="form-label small fw-semibold">Correo Electrónico</label>
                                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control form-control-sm" TextMode="Email" MaxLength="100"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <label class="form-label small fw-semibold">Dirección</label>
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control form-control-sm" TextMode="MultiLine" Rows="2" MaxLength="250"></asp:TextBox>
                            </div>

                            <div class="d-flex gap-2">
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary btn-sm flex-grow-1 fw-semibold" OnClick="btnGuardar_Click" />
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary btn-sm" OnClick="btnCancelar_Click" CausesValidation="false" />
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Listado de Clientes y Bitácora (Derecha) -->
                <div class="col-lg-8">
                    <!-- Tabla de Clientes -->
                    <div class="card shadow-sm border-0 mb-4">
                        <div class="card-header bg-white fw-bold py-3">
                            Clientes Registrados
                        </div>
                        <div class="card-body p-0">
                            <div class="table-responsive">
                                <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" DataKeyNames="IdCliente"
                                    CssClass="table table-hover table-striped mb-0 align-middle small" GridLines="None"
                                    EmptyDataText="No hay clientes registrados."
                                    AllowPaging="True" AllowCustomPaging="True" PageSize="5"
                                    OnPageIndexChanging="gvClientes_PageIndexChanging"
                                    OnRowCommand="gvClientes_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="IdCliente" HeaderText="ID" />
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                                        <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                                        <asp:BoundField DataField="DUI" HeaderText="DUI" />
                                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                                        <asp:BoundField DataField="Correo" HeaderText="Correo" />
                                        <asp:TemplateField HeaderText="Acciones">
                                            <ItemTemplate>
                                                <div class="d-flex gap-1">
                                                    <asp:LinkButton ID="btnEditar" runat="server" CommandName="EditarCliente"
                                                        CommandArgument='<%# Eval("IdCliente") %>' CssClass="btn btn-warning btn-sm py-0 px-2">
                                                        Editar
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btnEliminar" runat="server" CommandName="EliminarCliente"
                                                        CommandArgument='<%# Eval("IdCliente") %>' CssClass="btn btn-danger btn-sm py-0 px-2"
                                                        OnClientClick="return confirm('¿Está seguro de eliminar este cliente?');">
                                                        Eliminar
                                                    </asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pagination-ys bg-white border-top" HorizontalAlign="Center" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                    <!-- Tabla de Bitácora -->
                    <div class="card shadow-sm border-0">
                        <div class="card-header bg-white fw-bold py-3">
                            Bitácora de Auditoría
                        </div>
                        <div class="card-body p-0">
                            <div class="table-responsive">
                                <asp:GridView ID="gvBitacora" runat="server" AutoGenerateColumns="False"
                                    CssClass="table table-sm table-striped mb-0 align-middle small" GridLines="None"
                                    EmptyDataText="Sin registros en bitácora."
                                    AllowPaging="True" AllowCustomPaging="True" PageSize="5"
                                    OnPageIndexChanging="gvBitacora_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="FechaHora" HeaderText="Fecha/Hora" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                                        <asp:BoundField DataField="Accion" HeaderText="Acción" />
                                        <asp:BoundField DataField="IdCliente" HeaderText="ID Cliente" />
                                        <asp:BoundField DataField="Detalle" HeaderText="Detalle" />
                                        <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                                    </Columns>
                                    <PagerStyle CssClass="pagination-ys bg-white border-top" HorizontalAlign="Center" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Máscaras automáticas para DUI y Teléfono -->
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            const txtDui = document.getElementById("<%= txtDui.ClientID %>");
            const txtTelefono = document.getElementById("<%= txtTelefono.ClientID %>");

            if (txtDui) {
                txtDui.addEventListener("input", function (e) {
                    let valor = e.target.value.replace(/\D/g, "").substring(0, 9);
                    if (valor.length > 8) {
                        e.target.value = valor.slice(0, 8) + "-" + valor.slice(8);
                    } else {
                        e.target.value = valor;
                    }
                });
            }

            if (txtTelefono) {
                txtTelefono.addEventListener("input", function (e) {
                    let valor = e.target.value.replace(/\D/g, "").substring(0, 8);
                    if (valor.length > 4) {
                        e.target.value = valor.slice(0, 4) + "-" + valor.slice(4);
                    } else {
                        e.target.value = valor;
                    }
                });
            }
        });
    </script>
</body>
</html>