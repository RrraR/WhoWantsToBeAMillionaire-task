using WhoWantsToBeAMillionaire_task.Models;
using WWTBAM.Data.Entities;
using WWTBAM.Data.Repository;

namespace WhoWantsToBeAMillionaire_task.Service;

public class WWTBAMGameService : IWWTBAMGameService
{
    private readonly IQuestionsRepository _questionRepository;
    private readonly IAnswersRepository _answerRepository;
    private readonly IQuestionLevelRepository _questionLevelRepository;

    public WWTBAMGameService(IQuestionsRepository questionRepository,
        IAnswersRepository answerRepository, IQuestionLevelRepository questionLevelRepository)
    {
        _questionRepository = questionRepository;
        _answerRepository = answerRepository;
        _questionLevelRepository = questionLevelRepository;
    }

    public WWTBAMGameViewModel GetGameViewModel(int levelId)
    {
        IList<QuestionEntity> questions = _questionRepository.GetQuestionsByLevel(levelId);
        var currentQuestion = GetRandom(questions);
        IList<AnswersEntity> answers = _answerRepository.GetAnwersById(currentQuestion.QuestionId);
        var gameModel = new WWTBAMGameViewModel
        {
            QuestionLevel = _questionLevelRepository.GetQuestionLevelById(levelId),
            CurrentPrizeValue = _questionLevelRepository.GetQuestionValueById(levelId),
            CurrentQuestionLevel = levelId,
            Question = currentQuestion,
            Answer_A = answers[0],
            Answer_B = answers[1],
            Answer_C = answers[2],
            Answer_D = answers[3]
        };
        return gameModel;
    }

    public WWTBAMGameViewModel UpdateGameViewModel(WWTBAMGameViewModel gameViewModel)
    {
        gameViewModel.CurrentQuestionLevel++;
        gameViewModel.QuestionLevel = _questionLevelRepository.GetQuestionLevelById(gameViewModel.CurrentQuestionLevel);
        IList<QuestionEntity> questions = _questionRepository.GetQuestionsByLevel(gameViewModel.CurrentQuestionLevel);
        gameViewModel.Question = GetRandom(questions);
        IList<AnswersEntity> answers = _answerRepository.GetAnwersById(gameViewModel.Question.QuestionId);
        gameViewModel.Answer_A = answers[0];
        gameViewModel.Answer_B = answers[1];
        gameViewModel.Answer_C = answers[2];
        gameViewModel.Answer_D = answers[3];
        gameViewModel.CurrentPrizeValue =
            _questionLevelRepository.GetQuestionLevelById(gameViewModel.CurrentQuestionLevel - 1).ValueOfLevel;
        return gameViewModel;
    }

    public bool CheckAnswer(int answerId)
    {
        return _answerRepository.GetAnswer(answerId).AnswerIsCorrect;
    }

    private static T GetRandom<T>(IList<T> list)
    {
        T element = list[new Random().Next(list.Count)];
        list.Remove(element);
        return element;
    }
}