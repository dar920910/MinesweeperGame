// <copyright file="MineFieldCellTest.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.GameLibrary.UnitTests;

using Xunit;
using Minesweeper.GameLibrary;

/// <summary>
/// Тестовый класс, который содержит модульные тесты для проверки функциональности класса <see cref="MineFieldCell"/>.
/// </summary>
public class MineFieldCellTest
{
    private const byte TestFieldCellRow = 1;
    private const byte TestFieldCellCol = 1;

    /// <summary>
    /// Инициализирует экземпляр тестового класса <see cref="MineFieldCellTest"/> по умолчанию.
    /// </summary>
    public MineFieldCellTest()
    {
    }

    /// <summary>
    /// Тестирует получение визуального статуса неактивированной ячейки минного поля (стартовый игровой статус).
    /// </summary>
    [Fact]
    public void GetGameStatusForNonActivatedFieldCell()
    {
        MineField mineField = CreateTestMineFieldByDefault();
        MineFieldCell fieldCell = CreateTestFieldCellByDefault(mineField);

        Assert.Equal(expected: " ", actual: fieldCell.GameStatus);
    }

    private static MineField CreateTestMineFieldByDefault() => new (new bool[,]
    {
        { false, false, false },
        { false, false, false },
        { false, false, false },
    });

    private static MineFieldCell CreateTestFieldCellByDefault(MineField mineField) => new (
        position: new FieldCellPosition(
            TestFieldCellRow, TestFieldCellCol),
        isExplosiveCell: mineField.IsExplosiveFieldCell(
            TestFieldCellRow, TestFieldCellCol),
        countOfCellsWithMinesAround: mineField.GetNeighboursMinesCountAroundFieldCell(
            TestFieldCellRow, TestFieldCellCol));
}
