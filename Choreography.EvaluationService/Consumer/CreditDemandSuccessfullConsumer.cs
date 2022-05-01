using Choreography.SharedKernel.Credit;
using Choreography.SharedKernel.Evaluation;
using Choreography.SharedKernel.Interfaces;
using MassTransit;

namespace Choreography.EvaluationService.Consumer
{
    public class CreditDemandCreatedConsumer : IConsumer<CreditDemandCreated>
    {

        private readonly IPublishEndpoint _publishEndpoint;
        public CreditDemandCreatedConsumer(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<CreditDemandCreated> context)
        {
            var message = context.Message;
            if (message != null)
            {
                await Console.Out.WriteLineAsync($"User who has demand is : {message.UserId} {message.Amount}");

                // -----
                //Your Operations comes here regarding Evaluation.. 
                //data persistence
                //some conditions and decide that it is ok or not. 
                // -----


                //my dummy condition to test 
                if (message.Amount < 10000)
                {
                    // it is ok, go to the next step -> money transfer
                    //moneytransfer service should be subscribed this event
                    await this._publishEndpoint.Publish(new EvaluationCompleted()
                    {
                        Amount = message.Amount,
                        CompletedDate = DateTime.UtcNow,
                        UserId = message.UserId,
                    }).ConfigureAwait(false);
                }
                else
                {
                    // it is failed raised failed event
                    //credit service should be subscribed this event
                    //you can choose Publish or Send scenario 
                    await this._publishEndpoint.Publish(new EvaluationFailed()
                    {
                        Description = "too much money was demanded, your score is negative.",
                        UserId = message.UserId,
                    }).ConfigureAwait(false);
                }
            }
        }
    }
}
