using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WWTBAM.Data.Entities;

namespace WWTBAM.Data.Repository;

//all repositories made according to Repository-Service pattern

public class AnswersRepository : IAnswersRepository
{
    private readonly WWTBAMDbContext context;

    public AnswersRepository(WWTBAMDbContext context)
    {
        this.context = context;
    }

    public AnswersEntity? GetAnswer(int id)
    {
        return context.Answers.FirstOrDefault(x => x.AnswerId == id);
    }

    public List<AnswersEntity> GetAnwersById(int id)
    {
        return context.Answers.Where(x => x.QuestionId == id).ToList();
    }
}