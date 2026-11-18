# Sistema de Gestión de Clientes

Prueba técnica desarrollada en VB.NET (.NET Framework 4.8) con arquitectura en capas (Web, Business, Data y Entities), Entity Framework 6, SQL Server.

## Cómo levantar el proyecto

1. **Base de datos:** Abre SQL Server Management Studio y corre el script que dejé en la carpeta `/Database/GestionClientesDB.sql`. Ahí se crean las tablas, el usuario administrador y 20 clientes de prueba con su bitácora.
2. **Cadena de conexión:** En el proyecto `GestionClientes.Web`, abre el `Web.config` y ajusta el `Data Source` dentro de `<connectionStrings>` según el nombre de tu servidor local (por ejemplo `.`, `localhost` o `.\SQLEXPRESS`):

```xml
<connectionStrings>
  <add name="ConexionDB" 
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=GestionClientesDB;Integrated Security=True;TrustServerCertificate=True;" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
