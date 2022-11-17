using WWTBAM.Data.Entities;

namespace WWTBAM.Data.Repository;

public interface IQuestionsRepository
{
    public List<QuestionEntity> GetQuestionsByLevel(int CurrentLevel);
}