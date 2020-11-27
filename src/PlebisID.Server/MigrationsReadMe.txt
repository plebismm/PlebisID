dotnet ef migrations add -c PlebisIDContext -n Identity --project ../PlebisID.Migrations.Sqlite InitialPlebisDb

dotnet ef migrations add -c ConfigurationDbContext -n IdentityServer.ConfigurationDb --project ../PlebisID.Migrations.Sqlite InitialIdentityServer
dotnet ef migrations add -c PersistedGrantDbContext -n IdentityServer.PersistedGrantDb --project ../PlebisID.Migrations.Sqlite InitialIdentityServer