using Choreography.SharedKernel.Interfaces;

namespace Choreography.SharedKernel.Credit
{
    public class CreditDemandCreated : IEvent
    {
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
    }
}
