using System.ComponentModel.DataAnnotations.Schema;

namespace WWTBAM.Data.Entities;

//Answers entity contains same fields as in database except the last one which is navigatin property

public class AnswersEntity
{
    public int AnswerId { get; set; }
    public string AnswerText { get; set; }
    
    public bool AnswerIsCorrect { get; set; }
    
    public int QuestionId { get; set; }

    [ForeignKey( nameof(QuestionId))]
    public QuestionEntity Question { get; set; }
}