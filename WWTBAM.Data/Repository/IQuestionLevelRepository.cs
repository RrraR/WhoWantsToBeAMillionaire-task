using WWTBAM.Data.Entities;

namespace WWTBAM.Data.Repository;

public interface IQuestionLevelRepository
{
    public QuestionLevelEntity GetQuestionLevelById(int id);
    public decimal GetQuestionValueById(int id);
}