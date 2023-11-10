// <copyright file="FieldCellsRowGameStatusView.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.GameLibrary;

/// <summary>
/// Представляет запись, содержащую информацию о текущем игровом статусе ячеек, расположенных на некоторой строке минного поля.
/// </summary>
public record FieldCellsRowGameStatusView
{
    /// <summary>
    /// Инициализирует экземпляр записи типа <see cref="FieldCellsRowGameStatusView"/> (по умолчанию).
    /// </summary>
    public FieldCellsRowGameStatusView()
    {
        this.Cells = new List<string>();
    }

    /// <summary>
    /// Представляет ячейки данной строки в минном поле.
    /// </summary>
    public List<string> Cells { get; set; }
}
