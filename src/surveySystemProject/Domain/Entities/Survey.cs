using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Survey: Entity<Guid>
{
    public Survey(Guid id, string surveyTitle):base(id)
    {
        SurveyTitle = surveyTitle;
    }
    public Survey()
    {
        
    }
    public string SurveyTitle { get; set; }

    public virtual ICollection<SurveyMember>? SurveyMember { get; set; }
    public virtual ICollection<SurveyAnswer>? SurveyAnswer { get; set; }
    public virtual ICollection<Question>? Questions { get; set; }
}
