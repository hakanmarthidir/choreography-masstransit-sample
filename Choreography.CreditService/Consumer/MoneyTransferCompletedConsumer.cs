using Choreography.SharedKernel.MoneyTransfer;
using MassTransit;

namespace Choreography.CreditService.Consumer
{
    public class MoneyTransferCompletedConsumer : IConsumer<MoneyTransferCompleted>
    {
        public MoneyTransferCompletedConsumer()
        {

        }
        public async Task Consume(ConsumeContext<MoneyTransferCompleted> context)
        {
            //this is end of sequence
            if (context.Message != null)
            {
                var message = context.Message;

                
                //database operations : update due to provide the logic
                
                await Console.Out.WriteLineAsync($"Credit Operation Completed on {message.TransferDate} for : {message.UserId} Amount :  {message.Amount}");
            }

        }
    }
}
