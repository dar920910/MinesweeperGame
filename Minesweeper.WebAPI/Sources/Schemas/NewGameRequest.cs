// <copyright file="NewGameRequest.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.WebAPI.Schemas;

/// <summary>
/// Представляет тело HTTP-запроса с информацией о новой игровой партии.
/// </summary>
internal readonly struct NewGameRequest
{
    /// <summary>
    /// Инициализирует экземпляр структуры <see cref="NewGameRequest"/>.
    /// </summary>
    /// <param name="width">Ширина минного поля в количестве ячеек.</param>
    /// <param name="height">Высота минного поля в количестве ячеек.</param>
    /// <param name="minesCount">Количество заминированных ячеек в минном поле.</param>
    internal NewGameRequest(byte width, byte height, ushort minesCount)
    {
        this.Width = width;
        this.Height = height;
        this.Mines_Count = minesCount;
    }

    /// <summary>
    /// Представляет параметр тела запроса для ширины минного поля.
    /// </summary>
    internal byte Width { get; }

    /// <summary>
    /// Представляет параметр тела запроса для высоты минного поля.
    /// </summary>
    internal byte Height { get; }

    /// <summary>
    /// Представляет параметр тела запроса для количества заминированных ячеек в минном поле.
    /// </summary>
    internal int Mines_Count { get; }
}
