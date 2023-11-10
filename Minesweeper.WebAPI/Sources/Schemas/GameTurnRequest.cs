// <copyright file="GameTurnRequest.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.WebAPI.Schemas;

/// <summary>
/// Представляет тело HTTP-запроса с информацией о новом ходе игрока в игровой партии.
/// </summary>
public record GameTurnRequest
{
    /// <summary>
    /// Инициализирует экземпляр записи типа <see cref="GameTurnRequest"/> (по умолчанию).
    /// </summary>
    public GameTurnRequest()
    {
    }

    /// <summary>
    /// Инициализирует экземпляр записи типа <see cref="GameTurnRequest"/>.
    /// </summary>
    /// <param name="gameID">Идентификатор текущей игровой партии.</param>
    /// <param name="row">Номер строки ячейки, выбранной игроком для выполнения хода.</param>
    /// <param name="col">Номер столбца ячейки, выбранной игроком для выполнения хода.</param>
    public GameTurnRequest(string gameID, byte row, byte col)
    {
        this.Game_ID = gameID;
        this.Row = row;
        this.Col = col;
    }

    /// <summary>
    /// Представляет параметр тела запроса для идентификатора игровой партии.
    /// </summary>
    public string Game_ID { get; set; }

    /// <summary>
    /// Представляет параметр тела запроса для номера строки ячейки, выбранной игроком для выполнения следующего хода.
    /// </summary>
    public byte Row { get; set; }

    /// <summary>
    /// Представляет параметр тела запроса для номера столбца ячейки, выбранной игроком для выполнения следующего хода.
    /// </summary>
    public byte Col { get; set; }
}
