namespace Choreography.SharedKernel.MoneyTransfer
{
    public class MoneyTransferFailed
    {
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }

}
