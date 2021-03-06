using Choreography.MoneyTransferService.Consumer;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMassTransit(x =>
{
    //EvaluationCompletedConsumer
    x.AddConsumer<EvaluationCompletedConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ReceiveEndpoint("moneytransfer-evaluationcompleted-subscriber-queue", c =>
        {
            c.ConfigureConsumer<EvaluationCompletedConsumer>(context);
        });

        cfg.Host("192.168.178.35", "choreography", h =>
        {
            h.Username("tadev");
            h.Password("tadev");
        });

        cfg.ConfigureEndpoints(context);
    });
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
