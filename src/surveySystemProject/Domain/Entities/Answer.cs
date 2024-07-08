using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Answer: Entity<Guid>
{
  
    public string UserAnswer {  get; set; }   
    public virtual ICollection<QuestionAnswer>? QuestionAnswers { get; set; }
    public virtual ICollection<MemberAnswer>? MemberAnswers { get; set; }
    public virtual ICollection<SurveyAnswer>? SurveyAnswers { get; set; }

}
