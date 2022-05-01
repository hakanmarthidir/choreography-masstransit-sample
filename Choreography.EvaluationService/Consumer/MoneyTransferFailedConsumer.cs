using Choreography.SharedKernel.MoneyTransfer;
using MassTransit;

namespace Choreography.EvaluationService.Consumer
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

                //rollback the evaluation transaction
                //database operations : update or delete the evaluation data due to provide the logic

                await Console.Out.WriteLineAsync($"Evaluation Operation Failed on for : {message.UserId} Amount :  {message.Amount} reason is {message.Description}");
            }

        }
    }
}
