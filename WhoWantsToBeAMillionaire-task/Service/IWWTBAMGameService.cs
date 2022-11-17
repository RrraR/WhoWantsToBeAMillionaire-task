using WhoWantsToBeAMillionaire_task.Models;

namespace WhoWantsToBeAMillionaire_task.Service;

public interface IWWTBAMGameService
{
    public WWTBAMGameViewModel GetGameViewModel(int levelId);
    public WWTBAMGameViewModel UpdateGameViewModel(WWTBAMGameViewModel gameViewModel);
    public bool CheckAnswer(int answerId);
    
    public static T GetRandom<T>(IList<T> list)
    {
        T element = list[new Random().Next(list.Count)];
        list.Remove(element);
        return element;
    }
}