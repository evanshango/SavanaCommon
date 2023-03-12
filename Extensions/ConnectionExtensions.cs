using Microsoft.AspNetCore.Builder;

namespace Treasures.Common.Extensions; 

public static class ConnectionExtensions {
    public static string Postgres(this WebApplicationBuilder builder, string connString) {
        var dbServer = builder.Configuration["Database:DbServer"]!;
        var dbPort = builder.Configuration["Database:DbPort"]!;
        var dbUser = builder.Configuration["Database:DbUser"]!;
        var dbPass = builder.Configuration["Database:DbPass"]!;
        var db = builder.Configuration["Database:Db"]!;
        
        connString = connString.Replace("<DB_SERVER>", dbServer);
        connString = connString.Replace("<DB_PORT>", dbPort);
        connString = connString.Replace("<DB_USER>", dbUser);
        connString = connString.Replace("<DB_PASSWORD>", dbPass);
        connString = connString.Replace("<DB_SCHEMA>", db);
        
        return connString;
    }
}