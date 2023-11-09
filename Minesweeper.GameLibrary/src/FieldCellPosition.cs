// <copyright file="FieldCellPosition.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.GameLibrary;

/// <summary>
/// Представляет координаты ячейки минного поля.
/// </summary>
public readonly struct FieldCellPosition
{
    /// <summary>
    /// Инициализирует структуру типа <see cref="FieldCellPosition"/> с помощью указанных параметров.
    /// </summary>
    /// <param name="row">Номер строки ячейки минного поля.</param>
    /// <param name="col">Номер столбца ячейки минного поля.</param>
    public FieldCellPosition(byte row, byte col)
    {
        this.Row = row;
        this.Col = col;
    }

    /// <summary>
    /// Представляет номер строки, который занимает данная ячейка в минном поле.
    /// </summary>
    public byte Row { get; }

    /// <summary>
    /// Представляет номер стобца, который занимает данная ячейка в минном поле.
    /// </summary>
    public byte Col { get; }
}
