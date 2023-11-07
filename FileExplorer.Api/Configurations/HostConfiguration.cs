﻿namespace FileExplorer.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddMapping()
            .AddBrokers()
            .AddFileStorageInfrastructure()
            .AddDevTools()
            .AddRestExposers()
            .AddCustomCors();

        return new ValueTask<WebApplicationBuilder>(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseDevTools()
            .UseCustomCors()
            .MapRoutes()
            .UseFileStorage();

        return new ValueTask<WebApplication>(app);
    }
}