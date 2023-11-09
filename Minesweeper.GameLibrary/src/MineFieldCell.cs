// <copyright file="MineFieldCell.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.GameLibrary;

/// <summary>
/// Определяет объект ячейки минного поля.
/// </summary>
public class MineFieldCell
{
    /// <summary>
    /// Представляет константное значение для статуса заминированной ячейки, активированной пользователем.
    /// </summary>
    public const string ActivatedExplosiveFieldCellStatus = "X";

    /// <summary>
    /// Представляет константное значение для статуса неактивированной заминированной ячейки,
    /// который присваивается данной ячейке в результате успешного прохождения игры пользователем.
    /// </summary>
    public const string NonActivatedExplosiveFieldCellStatus = "M";

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
    }

    /// <summary>
    /// Представляет позицию ячейки в минном поле.
    /// </summary>
    public FieldCellPosition Position { get; }

    /// <summary>
    /// Представляет текущий игровой статус ячейки.
    /// </summary>
    public string GameStatus
    {
        get
        {
            if (this.isActivatedFieldCell)
            {
                if (this.isExplosiveCell)
                {
                    return ActivatedExplosiveFieldCellStatus;
                }
                else
                {
                    switch (this.countOfCellsWithMinesAround)
                    {
                        case 0:
                            return "0";
                        case 1:
                            return "1";
                        case 2:
                            return "2";
                        case 3:
                            return "3";
                        case 4:
                            return "4";
                        case 5:
                            return "5";
                        case 6:
                            return "6";
                        case 7:
                            return "7";
                        case 8:
                            return "8";
                    }
                }
            }

            return NonActivatedFieldCellStatusSymbol.ToString();
        }
    }

    /// <summary>
    /// Активирует текущую ячейку минного поля.
    /// </summary>
    public void Activate()
    {
        this.isActivatedFieldCell = true;
    }
}
