// See https://aka.ms/new-console-template for more information

using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddGrpcClient<Test.TestClient>(op =>
{
    op.Address = new Uri("http://localhost:8888");
});

var app = builder.Build();

var client = app.Services.GetRequiredService<Test.TestClient>();

var res = await client.TestAsync(new Empty());