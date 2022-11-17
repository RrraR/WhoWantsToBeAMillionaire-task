using WWTBAM.Data.Entities;

namespace WWTBAM.Data.Repository;

public class QuestionLevelRepository : IQuestionLevelRepository
{
    private readonly WWTBAMDbContext context;

    public QuestionLevelRepository(WWTBAMDbContext context)
    {
        this.context = context;
    }

    public QuestionLevelEntity GetQuestionLevelById(int id)
    {
        return context.QuestionLevel.FirstOrDefault(x => x.LevelId == id);
    }

    public decimal GetQuestionValueById(int id)
    {
        return context.QuestionLevel.FirstOrDefault(t => t.LevelId == id).ValueOfLevel;
    }
}