using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MemberQuestion:Entity<Guid>
{
    public virtual Member? Member { get; set; }
    public Guid MemberId { get; set; }
    public virtual Question? Question { get; set; }
    public Guid QuestionId { get; set; }
}
