using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WWTBAM.Data.Entities;

namespace WWTBAM.Data.Repository;

public class QuestionsRepository : IQuestionsRepository
{
    private readonly WWTBAMDbContext context;

    public QuestionsRepository(WWTBAMDbContext context)
    {
        this.context = context;
    }

    public List<QuestionEntity> GetQuestionsByLevel(int CurrentLevel)
    {
        return context.Questions.Where(x => x.QuestionOfLevelId == CurrentLevel).ToList();
    }
}