using Microsoft.AspNetCore.Mvc;
using WhoWantsToBeAMillionaire_task.Models;
using WhoWantsToBeAMillionaire_task.Service;

//controller used to navigate Game page and access GameOver, Result, YouWon and SafeHeaven pages

namespace WhoWantsToBeAMillionaire_task.Controllers;

public class GameController : Controller
{
    private readonly IWWTBAMGameService _gameService;

    public GameController(IWWTBAMGameService gameService)
    {
        _gameService = gameService;
    }


    [HttpPost]
    public IActionResult Play(WWTBAMGameViewModel currentGameModel, int answerId)
    {
        if (_gameService.CheckAnswer(answerId))
        {
            return currentGameModel.CurrentQuestionLevel switch
            {
                5 or 10 => View("SafeHeaven", _gameService.GetGameViewModel(currentGameModel.CurrentQuestionLevel)),
                15 => View("Result", _gameService.GetGameViewModel(currentGameModel.CurrentQuestionLevel)),
                _ => View("Game", _gameService.UpdateGameViewModel(currentGameModel))
            };
        }
        else
        {
            switch (currentGameModel.CurrentQuestionLevel)
            {
                case <= 5:
                    return View("GameOver");
                case <= 10:
                    currentGameModel.CurrentQuestionLevel = 5;
                    return View("Result", _gameService.GetGameViewModel(currentGameModel.CurrentQuestionLevel));
                case <= 15:
                    currentGameModel.CurrentQuestionLevel = 10;
                    return View("Result", _gameService.GetGameViewModel(currentGameModel.CurrentQuestionLevel));
            }
        }

        return View("GameOver");
    }

    public IActionResult Leave(WWTBAMGameViewModel currentGameModel)
    {
        return View("Result", _gameService.GetGameViewModel(currentGameModel.CurrentQuestionLevel));
    }

    [HttpPost]
    public IActionResult SafeHeaven(WWTBAMGameViewModel currentGameModel)
    {
        currentGameModel.CurrentQuestionLevel++;
        return View("Game", _gameService.GetGameViewModel(currentGameModel.CurrentQuestionLevel));
    }

    // GET
    public IActionResult Index()
    {
        return View("Game", _gameService.GetGameViewModel(1));
    }
}