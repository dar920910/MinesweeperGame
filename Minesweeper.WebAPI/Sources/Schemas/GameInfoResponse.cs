// <copyright file="GameInfoResponse.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.WebAPI.Schemas;

using Minesweeper.GameLibrary;

/// <summary>
/// Представляет тело HTTP-ответа с обновленной информацией о ячейках минного поля текущей игровой партии.
/// </summary>
internal record GameInfoResponse
{
    /// <summary>
    /// Инициализирует экземпляр записи типа <see cref="GameInfoResponse"/>.
    /// </summary>
    /// <param name="game">Текущая игровая партия.</param>
    internal GameInfoResponse(GameParty game)
    {
        this.Game_ID = game.ID.ToString();

        this.Width = game.CurrentMineField.Size.Width;
        this.Height = game.CurrentMineField.Size.Height;
        this.Mines_Count = game.CurrentMineField.MinesCount;

        this.Completed = game.IsGameOver;
        this.Field = game.CurrentMineField.GetAllFieldCells();
    }

    /// <summary>
    /// Представляет параметр тела ответа для идентификатора игровой партии.
    /// </summary>
    internal string Game_ID { get; }

    /// <summary>
    /// Представляет параметр тела ответа для ширины минного поля.
    /// </summary>
    internal int Width { get; }

    /// <summary>
    /// Представляет параметр тела ответа для высоты минного поля.
    /// </summary>
    internal int Height { get; }

    /// <summary>
    /// Представляет параметр тела ответа для количества заминированных ячеек в минном поле.
    /// </summary>
    internal int Mines_Count { get; }

    /// <summary>
    /// Представляет параметр тела ответа для статуса завершения игровой партии.
    /// </summary>
    internal bool Completed { get; }

    /// <summary>
    /// Представляет параметр тела ответа для содержимого минного поля.
    /// </summary>
    internal string[,] Field { get; }
}
