namespace Choreography.SharedKernel.MoneyTransfer
{
    public class MoneyTransferCompleted
    {
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransferDate { get; set; }
    }
}
