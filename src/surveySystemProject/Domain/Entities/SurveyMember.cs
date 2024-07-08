using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class SurveyMember:Entity<Guid>
{
    public virtual Member? Member { get; set; }
    public Guid MemberId { get; set; }
    public virtual Survey? Survey{ get; set; }
    public Guid SurveyId { get; set; }
}
