# Sqlite

dotnet ef migrations add -c PlebisDbContext -n Identity --project ../PlebisID.Migrations.Sqlite InitialPlebisDb

dotnet ef migrations add -c ConfigurationDbContext -n IdentityServer.ConfigurationDb --project ../PlebisID.Migrations.Sqlite InitialIdentityServer
dotnet ef migrations add -c PersistedGrantDbContext -n IdentityServer.PersistedGrantDb --project ../PlebisID.Migrations.Sqlite InitialIdentityServer

# SqlServer

dotnet ef migrations add -c PlebisDbContext -n Identity --project ../PlebisID.Migrations.SqlServer Initial -- --storageEngine sqlserver
dotnet ef migrations add -c ConfigurationDbContext -n IdentityServer.ConfigurationDb --project ../PlebisID.Migrations.SqlServer InitialIdentityServer -- --storageEngine sqlserver
dotnet ef migrations add -c PersistedGrantDbContext -n IdentityServer.PersistedGrantDb --project ../PlebisID.Migrations.SqlServer InitialIdentityServer -- --storageEngine sqlserver
