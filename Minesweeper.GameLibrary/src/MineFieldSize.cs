// <copyright file="MineFieldSize.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Minesweeper.GameLibrary;

/// <summary>
/// Определяет композитный объект для хранения размеров минного поля.
/// </summary>
public readonly struct MineFieldSize
{
    /// <summary>
    /// Инициализирует экземпляр класса <see cref="MineFieldSize"/> с помощью указанных параметров.
    /// </summary>
    /// <param name="width">Ширина минного поля в количестве ячеек.</param>
    /// <param name="height">Высота минного поля в количестве ячеек.</param>
    public MineFieldSize(byte width, byte height)
    {
        this.Width = width;
        this.Height = height;
    }

    /// <summary>
    /// Ширина минного поля (количество столбцов в матрице).
    /// </summary>
    public byte Width { get; }

    /// <summary>
    /// Высота минного поля (количество строк в матрице).
    /// </summary>
    public byte Height { get; }
}
