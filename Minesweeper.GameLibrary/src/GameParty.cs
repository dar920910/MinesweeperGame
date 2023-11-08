// <copyright file="GameParty.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.GameLibrary;

/// <summary>
/// Представляет объект однопользовательской партии игры "Сапёр".
/// </summary>
public class GameParty
{
    private readonly ushort summaryEmptyCellsCount;
    private ushort detectedEmptyCellsCount;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="GameParty"/> с помощью объекта минного поля.
    /// </summary>
    /// <param name="field">Объект минного поля для текущей игровой партии.</param>
    public GameParty(MineField field)
    {
        this.ID = Guid.NewGuid();
        this.CurrentMineField = field;

        this.summaryEmptyCellsCount = CalculateSummaryEmptyCellsCount(field);
        this.detectedEmptyCellsCount = 0;

        this.IsGameOver = false;
    }

    /// <summary>
    /// Получает глобальный уникальный идентификатор для текущей игровой партии.
    /// </summary>
    public Guid ID { get; }

    /// <summary>
    /// Получает текущий экземпляр минного поля для данной игровой партии.
    /// </summary>
    public MineField CurrentMineField { get; }

    /// <summary>
    /// Получает значение, отражающее статус завершения текущей игровой партии.
    /// </summary>
    public bool IsGameOver { get; private set; }

    /// <summary>
    /// Сделать игровой ход с помощью указания координат ячейки минного поля.
    /// </summary>
    /// <param name="customCellRow">Номер строки ячейки, выбранной игроком на минном поле.</param>
    /// <param name="customCellCol">Номер столбца ячейки, выбранной игроком на минном поле.</param>
    public void MakeTurn(byte customCellRow, byte customCellCol)
    {
        if (this.CurrentMineField.IsExplosiveFieldCell(customCellRow, customCellCol))
        {
            this.IsGameOver = true;
        }
        else
        {
            this.detectedEmptyCellsCount++;

            if (this.detectedEmptyCellsCount == this.summaryEmptyCellsCount)
            {
                this.IsGameOver = true;
            }
            else
            {
                this.IsGameOver = false;
            }
        }
    }

    private static ushort CalculateSummaryEmptyCellsCount(MineField field)
    {
        ushort summaryCellsCount = Convert.ToUInt16(field.Size.Height * field.Size.Width);
        return Convert.ToUInt16(summaryCellsCount - field.MinesCount);
    }
}
