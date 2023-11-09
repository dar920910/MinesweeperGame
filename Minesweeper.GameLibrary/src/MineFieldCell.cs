// <copyright file="MineFieldCell.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.GameLibrary;

/// <summary>
/// Определяет объект ячейки минного поля.
/// </summary>
public class MineFieldCell
{
    private const char NonActivatedFieldCellStatusSymbol = ' ';

    private readonly bool isExplosiveCell;
    private readonly byte countOfCellsWithMinesAround;

    private bool isActivatedFieldCell;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="MineFieldCell"/> с помощью указанных параметров.
    /// </summary>
    /// <param name="position">Позиция ячейки в минном поле.</param>
    /// <param name="isExplosiveCell">Принимает значение true, если ячейка содержит мину.</param>
    /// <param name="countOfCellsWithMinesAround">Количество заминированных соседних ячеек.</param>
    public MineFieldCell(FieldCellPosition position, bool isExplosiveCell, byte countOfCellsWithMinesAround)
    {
        this.isExplosiveCell = isExplosiveCell;
        this.countOfCellsWithMinesAround = countOfCellsWithMinesAround;

        this.isActivatedFieldCell = false;

        this.Position = position;
        this.GameStatus = NonActivatedFieldCellStatusSymbol.ToString();
    }

    /// <summary>
    /// Представляет позицию ячейки в минном поле.
    /// </summary>
    public FieldCellPosition Position { get; }

    /// <summary>
    /// Представляет текущий игровой статус ячейки.
    /// </summary>
    public string GameStatus { get; }
}
