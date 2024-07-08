using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Member: Entity<Guid>
{
    public Member()
    {
        
    }
    public string name { get; set; }
    public string surname { get; set; }
    public string email { get; set; }
    public string Password { get; set; }

    public Guid UserId { get; set; }
    public virtual User? User { get; set; }

    public virtual ICollection<SurveyMember> SurveyMembers { get; set;}
    public virtual ICollection<MemberAnswer> MemberAnswer { get; set; }
    public virtual ICollection<MemberQuestion> MemberQuestions { get; set; }

}
