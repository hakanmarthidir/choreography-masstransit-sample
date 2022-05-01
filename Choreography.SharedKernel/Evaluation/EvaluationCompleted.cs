using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography.SharedKernel.Evaluation
{
    public class EvaluationCompleted
    {
        public Guid UserId { get; set; }
        public DateTime CompletedDate { get; set; }
        public decimal Amount { get; set; }
    }


}
