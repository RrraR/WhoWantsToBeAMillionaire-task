using System.ComponentModel.DataAnnotations;

namespace WWTBAM.Data.Entities;

//QuestionLevel entity is used to point out level of the question and it's value in the game 
//all fields same as in the database excpt th last one

public class QuestionLevelEntity
{
    [Key] public int LevelId { get; set; }
    public decimal ValueOfLevel { get; set; }
    public ICollection<QuestionEntity> QuestionsOfLevel { get; set; }
}