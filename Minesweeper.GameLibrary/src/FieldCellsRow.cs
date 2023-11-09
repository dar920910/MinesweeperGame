// <copyright file="FieldCellsRow.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.GameLibrary;

/// <summary>
/// Представляет вспомогательную запись с информацией о ячейках некоторой строки в минном поле.
/// </summary>
public record FieldCellsRow
{
    /// <summary>
    /// Инициализирует экземпляр записи типа <see cref="FieldCellsRow"/> (по умолчанию).
    /// </summary>
    public FieldCellsRow()
    {
        this.Cells = new List<string>();
    }

    /// <summary>
    /// Представляет ячейки данной строки в минном поле.
    /// </summary>
    public List<string> Cells { get; set; }
}
