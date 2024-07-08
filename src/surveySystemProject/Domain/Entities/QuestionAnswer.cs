using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class QuestionAnswer:Entity<Guid>
{
    public virtual Question? Question { get; set; }
    public Guid QuestionId { get; set; }
    public virtual Answer? Answer { get; set; }
    public Guid AnswerId { get; set; }
}
