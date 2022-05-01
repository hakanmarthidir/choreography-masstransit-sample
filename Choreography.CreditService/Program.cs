

using Choreography.CreditService.Consumer;
using Choreography.SharedKernel.Evaluation;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CreditEvaluationFailedConsumer>();
    x.AddConsumer<MoneyTransferCompletedConsumer>();
    x.AddConsumer<MoneyTransferFailedConsumer>();
    
    x.UsingRabbitMq((context, cfg) =>
    {

        cfg.ReceiveEndpoint("credit-evaluationfailed-subscriber-queue", c =>
        {
            c.ConfigureConsumer<CreditEvaluationFailedConsumer>(context);
        });

        cfg.ReceiveEndpoint("credit-moneytransfercompleted-subscriber-queue", c =>
        {
            c.ConfigureConsumer<MoneyTransferCompletedConsumer>(context);
        });

        cfg.ReceiveEndpoint("credit-moneytransferfailed-subscriber-queue", c =>
        {
            c.ConfigureConsumer<MoneyTransferFailedConsumer>(context);
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
