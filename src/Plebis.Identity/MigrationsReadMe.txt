# Sqlite

dotnet ef migrations add -c PlebisDbContext -n Identity --project ../Plebis.Identity.Migrations.Sqlite InitialPlebisDb

dotnet ef migrations add -c ConfigurationDbContext -n IdentityServer.ConfigurationDb --project ../Plebis.Identity.Migrations.Sqlite InitialIdentityServer
dotnet ef migrations add -c PersistedGrantDbContext -n IdentityServer.PersistedGrantDb --project ../Plebis.Identity.Migrations.Sqlite InitialIdentityServer

# SqlServer

dotnet ef migrations add -c PlebisDbContext -n Identity --project ../Plebis.Identity.Migrations.SqlServer Initial -- --storageEngine sqlserver
dotnet ef migrations add -c ConfigurationDbContext -n IdentityServer.ConfigurationDb --project ../Plebis.Identity.Migrations.SqlServer InitialIdentityServer -- --storageEngine sqlserver
dotnet ef migrations add -c PersistedGrantDbContext -n IdentityServer.PersistedGrantDb --project ../Plebis.Identity.Migrations.SqlServer InitialIdentityServer -- --storageEngine sqlserver
