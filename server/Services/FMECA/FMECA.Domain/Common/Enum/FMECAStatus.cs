using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMECA.Domain.Common.Enum;
public enum FMECAStatus
{
    AssessmentUnderWay = 0,
    IntialAssessmentComplete = 1,
    CorrectiveActionAssigned = 2,
    CorrectiveActionComplete = 3,
    PostActionScoringComplete = 4
}
