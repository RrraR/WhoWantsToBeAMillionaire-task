using WWTBAM.Data.Entities;

namespace WWTBAM.Data.Repository;

public interface IAnswersRepository
{
    public AnswersEntity? GetAnswer(int id);
    public List<AnswersEntity> GetAnwersById(int id);
}