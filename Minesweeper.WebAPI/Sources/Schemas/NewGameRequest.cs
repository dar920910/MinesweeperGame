// <copyright file="NewGameRequest.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.WebAPI.Schemas;

/// <summary>
/// Представляет тело HTTP-запроса с информацией о новой игровой партии.
/// </summary>
public record NewGameRequest
{
    /// <summary>
    /// Инициализирует экземпляр записи типа <see cref="NewGameRequest"/> (по умолчанию).
    /// </summary>
    public NewGameRequest()
    {
    }

    /// <summary>
    /// Инициализирует экземпляр записи типа <see cref="NewGameRequest"/>.
    /// </summary>
    /// <param name="width">Ширина минного поля в количестве ячеек.</param>
    /// <param name="height">Высота минного поля в количестве ячеек.</param>
    /// <param name="minesCount">Количество заминированных ячеек в минном поле.</param>
    public NewGameRequest(byte width, byte height, ushort minesCount)
    {
        this.Width = width;
        this.Height = height;
        this.Mines_Count = minesCount;
    }

    /// <summary>
    /// Представляет параметр тела запроса для ширины минного поля.
    /// </summary>
    public byte Width { get; set; }

    /// <summary>
    /// Представляет параметр тела запроса для высоты минного поля.
    /// </summary>
    public byte Height { get; set; }

    /// <summary>
    /// Представляет параметр тела запроса для количества заминированных ячеек в минном поле.
    /// </summary>
    public ushort Mines_Count { get; set; }
}
