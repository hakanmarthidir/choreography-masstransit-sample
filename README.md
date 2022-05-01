##### Saga Choreography Sample Sequence

***Step 1***

Service : CreditService

Publish : CreditDemandCreated

Subscribe : MoneyTransferCompleted, MoneyTransferFailed, EvaluationFailed


***Step 2***

Service : EvaluationService


Publish : EvaluationCompleted, EvaluationFailed

Subscribe : CreditDemandCreated, MoneyTransferFailed


***Step 3***

Service : MoneyTransferService

Publish : MoneyTransferCompleted, MoneyTransferFailed

Subscribe : EvaluationCompleted