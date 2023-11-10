// <copyright file="GameInfoResponse.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.WebAPI.Schemas;

using Minesweeper.GameLibrary;

/// <summary>
/// Представляет тело HTTP-ответа с обновленной информацией о ячейках минного поля текущей игровой партии.
/// </summary>
public record GameInfoResponse
{
    /// <summary>
    /// Инициализирует экземпляр записи типа <see cref="GameInfoResponse"/> (по умолчанию).
    /// </summary>
    public GameInfoResponse()
    {
    }

    /// <summary>
    /// Инициализирует экземпляр записи типа <see cref="GameInfoResponse"/>.
    /// </summary>
    /// <param name="game">Текущая игровая партия.</param>
    public GameInfoResponse(GameParty game)
    {
        this.Game_ID = game.ID.ToString();

        this.Width = game.CurrentMineField.Size.Width;
        this.Height = game.CurrentMineField.Size.Height;
        this.Mines_Count = game.CurrentMineField.MinesCount;

        this.Completed = game.IsGameOver;
        this.Field = game.GetSummaryMineFieldGameStatus();
    }

    /// <summary>
    /// Представляет параметр тела ответа для идентификатора игровой партии.
    /// </summary>
    public string Game_ID { get; set; }

    /// <summary>
    /// Представляет параметр тела ответа для ширины минного поля.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Представляет параметр тела ответа для высоты минного поля.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Представляет параметр тела ответа для количества заминированных ячеек в минном поле.
    /// </summary>
    public int Mines_Count { get; set; }

    /// <summary>
    /// Представляет параметр тела ответа для статуса завершения игровой партии.
    /// </summary>
    public bool Completed { get; set; }

    /// <summary>
    /// Представляет параметр тела ответа для содержимого минного поля.
    /// </summary>
    public List<FieldCellsRowGameStatusView> Field { get; set; }
}
