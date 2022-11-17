using System.ComponentModel.DataAnnotations;

namespace WWTBAM.Data.Entities;

public class QuestionLevelEntity
{
    [Key] public int LevelId { get; set; }
    public decimal ValueOfLevel { get; set; }
    public ICollection<QuestionEntity> QuestionsOfLevel { get; set; }
}