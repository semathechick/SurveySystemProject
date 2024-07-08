

using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Question:Entity<Guid>
{
    
    public Question()
    {
        
    }

    public Question(Guid id, string ındvQuestion):base(id)
    {
        IndvQuestion = ındvQuestion;
    }

    public string IndvQuestion {  get; set; }
    public Guid SurveyId { get; set; }
    public virtual Survey? Survey { get; set; }
    

    public virtual ICollection<QuestionAnswer>? QuestionAnswers { get; set; }
    public virtual ICollection<MemberQuestion>? MemberQuestions { get; set; }
    

}
