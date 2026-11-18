<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="GestionClientes.Web.Login" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Iniciar Sesión - Gestión de Clientes</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light d-flex align-items-center justify-content-center vh-100">
    <form id="form1" runat="server" class="w-100" style="max-width: 400px;">
        <div class="card shadow-sm border-0">
            <div class="card-body p-4">
                <div class="text-center mb-4">
                    <h4 class="fw-bold text-primary">FUNDAMICRO</h4>
                    <p class="text-muted small">Sistema de Gestión de Clientes</p>
                </div>

                <asp:Panel ID="pnlError" runat="server" Visible="false" CssClass="alert alert-danger py-2 small" role="alert">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </asp:Panel>

                <div class="mb-3">
                    <label for="txtUsuario" class="form-label fw-semibold">Usuario</label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ej. admin" required="required"></asp:TextBox>
                </div>

                <div class="mb-4">
                    <label for="txtContrasena" class="form-label fw-semibold">Contraseña</label>
                    <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password" placeholder="••••••••" required="required"></asp:TextBox>
                </div>

                <div class="d-grid">
                    <asp:Button ID="btnIngresar" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary fw-semibold" OnClick="btnIngresar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>