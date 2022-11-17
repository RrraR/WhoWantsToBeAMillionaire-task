using WWTBAM.Data;
using WWTBAM.Data.Entities;

namespace WhoWantsToBeAMillionaire_task.Models;

public class WWTBAMGameViewModel
{
    public QuestionLevelEntity QuestionLevel { get; set; }
    public int CurrentQuestionLevel { get; set; }
    public decimal CurrentPrizeValue { get; set; }
    public QuestionEntity Question { get; set; }
    public AnswersEntity Answer_A { get; set; }
    public AnswersEntity Answer_B { get; set; }
    public AnswersEntity Answer_C { get; set; }
    public AnswersEntity Answer_D { get; set; }
}
