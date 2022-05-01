using Choreography.SharedKernel.Evaluation;
using Choreography.SharedKernel.MoneyTransfer;
using MassTransit;

namespace Choreography.MoneyTransferService.Consumer
{
    public class EvaluationCompletedConsumer : IConsumer<EvaluationCompleted>
    {
        IPublishEndpoint _publishEndpoint;
        public EvaluationCompletedConsumer(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async Task Consume(ConsumeContext<EvaluationCompleted> context)
        {
            if (context.Message != null)
            {
                var message = context.Message;


                //Your money transfer logic here!


                //dummy condition to test
                var moneyTransferStatus = message.Amount % 2 == 0;

                if (moneyTransferStatus == true)
                {
                    await Console.Out.WriteLineAsync($"Money transferred.. ");
                    await this._publishEndpoint.Publish(new MoneyTransferCompleted()
                    {
                        Amount = message.Amount,
                        TransferDate = DateTime.UtcNow,
                        UserId = message.UserId,
                    }).ConfigureAwait(false);
                }
                else
                {
                    await Console.Out.WriteLineAsync($"An exception occurred while Money transferring..");
                    await this._publishEndpoint.Publish(new MoneyTransferFailed()
                    {
                        UserId = message.UserId,
                        Amount = message.Amount,
                        Description = "An exception occurred while Money transferring.."
                    }
                    ).ConfigureAwait(false);
                }
            }
        }
    }
}
