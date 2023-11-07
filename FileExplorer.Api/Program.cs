using FileExplorer.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

await builder.ConfigureAsync();

var app = builder.Build();

await app.ConfigureAsync();

await app.RunAsync();


// https://localhost:5245/api/directories/root/entries?pageSize=20&pageToken=1&includeDirectories=true&includeFiles=true
// http://localhost:5245/api/directories/root/entries?IncludeFiles=true&IncludeDirectories=true&PageSize=20&PageToken=1