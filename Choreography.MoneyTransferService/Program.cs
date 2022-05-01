using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMassTransit(x => x.UsingRabbitMq((context, cfg) =>
{
    cfg.Host("192.168.178.35", "choreography", h =>
    {
        h.Username("tadev");
        h.Password("tadev");
    });

    cfg.ConfigureEndpoints(context);
})
);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
