using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WWTBAM.Data.Entities;

public class QuestionEntity
{
    [Key] public int QuestionId { get; set; }
    public string QuestionText { get; set; }
    public ICollection<AnswersEntity> Answers { get; set; }
    
    public int QuestionOfLevelId { get; set; }
    [ForeignKey(nameof(QuestionOfLevelId))]
    public QuestionLevelEntity QuestionToLevel { get; set; }
}