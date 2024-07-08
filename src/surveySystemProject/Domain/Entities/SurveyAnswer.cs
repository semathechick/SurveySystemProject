using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class SurveyAnswer:Entity<Guid>
{
    public virtual Survey? Survey { get; set; }
    public Guid SurveyId { get; set; }
    public virtual Answer? Answer { get; set; }
    public Guid AnswerId { get; set; }
}
