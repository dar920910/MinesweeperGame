// <copyright file="MinesweeperController.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.WebAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using Minesweeper.GameLibrary;
using Minesweeper.WebAPI.Schemas;

/// <summary>
/// Определяет класс контроллера для API игры "Сапёр".
/// </summary>
[ApiController]
[Route("[controller]")]
public class MinesweeperController : ControllerBase
{
    private readonly ILogger<MinesweeperController> logger;

    /// <summary>
    /// Инициалирует экземпляр класса контроллера <see cref="MinesweeperController"/>.
    /// </summary>
    /// <param name="logger">Внедренная зависимость для устройства журналирования.</param>
    public MinesweeperController(ILogger<MinesweeperController> logger)
    {
        this.logger = logger;
    }

    /// <summary>
    /// Определяет метод API игры "Сапёр", предназначенный для формирования запроса на создание новой игровой партии.
    /// </summary>
    /// <param name="newGameRequest">Тело запроса, содержащее параметры запроса новой игровой партии.</param>
    /// <returns>Результат выполнения запроса, содержащий тело ответа с информацией о новой игровой партии.</returns>
    [HttpPost("new")]
    [ProducesResponseType(200, Type = typeof(GameInfoResponse))]
    [ProducesResponseType(400, Type = typeof(BadRequestResult))]
    public IActionResult StartNewGame([FromBody] NewGameRequest newGameRequest)
    {
        if (newGameRequest == null)
        {
            return this.BadRequest();
        }

        MineFieldSize mineFieldSize = new (newGameRequest.Width, newGameRequest.Height);
        MineField mineField = new (mineFieldSize, newGameRequest.Mines_Count);
        GameParty gameParty = new (mineField);

        return this.Ok(new GameInfoResponse(gameParty));
    }

    /// <summary>
    /// Определяет метод API игры "Сапёр", предназначенный для формирования запроса на выполнение хода игрока в текущей игровой партии.
    /// </summary>
    /// <param name="gameTurnRequest">Тело запроса, содержащее параметры запроса для совершения хода в текущей игровой партии.</param>
    /// <returns>Результат выполнения запроса, содержащий тело ответа с информацией об измененном состоянии игровой партии.</returns>
    [HttpPost("turn")]
    [ProducesResponseType(200, Type = typeof(GameInfoResponse))]
    internal GameInfoResponse MakeGameTurn([FromBody] GameTurnRequest gameTurnRequest)
    {
        GameParty gameParty = GameParty.GetGamePartyByID(gameTurnRequest.Game_ID);
        gameParty.MakeTurn(gameTurnRequest.Row, gameTurnRequest.Col);
        return new GameInfoResponse(gameParty);
    }
}
