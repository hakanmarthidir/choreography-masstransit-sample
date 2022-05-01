using Choreography.SharedKernel.MoneyTransfer;
using MassTransit;

namespace Choreography.CreditService.Consumer
{
    public class MoneyTransferFailedConsumer : IConsumer<MoneyTransferFailed>
    {
        public MoneyTransferFailedConsumer()
        {

        }
        public async Task Consume(ConsumeContext<MoneyTransferFailed> context)
        {
            //failed
            if (context.Message != null)
            {
                var message = context.Message;

                //rollback the credit service transaction
                //database operations : update or delete the credit data due to provide the logic

                await Console.Out.WriteLineAsync($"Credit Operation Failed on for : {message.UserId} Amount :  {message.Amount} reason is {message.Description}");
            }

        }
    }
}
