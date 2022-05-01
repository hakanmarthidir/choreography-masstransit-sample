using Choreography.SharedKernel.Evaluation;
using MassTransit;

namespace Choreography.CreditService.Consumer
{
    public class CreditEvaluationFailedConsumer : IConsumer<EvaluationFailed>
    {
        public CreditEvaluationFailedConsumer()
        {

        }
        public async Task Consume(ConsumeContext<EvaluationFailed> context)
        {
            //this is rollback transaction
            if (context.Message != null)
            {
                var message = context.Message;

                //Do your rollback operations here...
                //database operations : update or delete or other due to provide the logic

                await Console.Out.WriteLineAsync($"this evaluation failed.. set new status to demand : {message.UserId} reason is {message.Description}");
            }

        }
    }
}
