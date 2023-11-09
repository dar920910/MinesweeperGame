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

    private const string NonActivatedFieldCellStatus = " ";
    private const string ActivatedExplosiveFieldCellStatus = "X";
    private const string NonActivatedExplosiveFieldCellStatus = "M";

    /// <summary>
    /// Инициализирует экземпляр тестового класса <see cref="MineFieldCellTest"/> по умолчанию.
    /// </summary>
    public MineFieldCellTest()
    {
    }

    /// <summary>
    /// Тестирует получение визуального статуса активированной ячейки, вокруг которой расположено 0 заминированных ячеек.
    /// </summary>
    [Fact]
    public void GetGameStatusForActivatedFieldCell_WhenNeighbourCellsWithMinesAroundAreEqual0()
    {
        MineField mineField = new (new bool[,]
        {
            { false, false, false },
            { false, false, false },
            { false, false, false },
        });

        MineFieldCell fieldCell = new (
            position: new FieldCellPosition(1, 1),
            isExplosiveCell: false,
            countOfCellsWithMinesAround: 0);

        fieldCell.Activate();

        Assert.Equal(expected: "0", actual: fieldCell.GameStatus);
    }

    /// <summary>
    /// Тестирует получение визуального статуса активированной ячейки, вокруг которой расположено 1 заминированных ячеек.
    /// </summary>
    [Fact]
    public void GetGameStatusForActivatedFieldCell_WhenNeighbourCellsWithMinesAroundAreEqual1()
    {
        MineField mineField = new (new bool[,]
        {
            { true, false, false },
            { false, false, false },
            { false, false, false },
        });

        MineFieldCell fieldCell = new (
            position: new FieldCellPosition(1, 1),
            isExplosiveCell: false,
            countOfCellsWithMinesAround: 1);

        fieldCell.Activate();

        Assert.Equal(expected: "1", actual: fieldCell.GameStatus);
    }

    /// <summary>
    /// Тестирует получение визуального статуса активированной ячейки, вокруг которой расположено 2 заминированных ячеек.
    /// </summary>
    [Fact]
    public void GetGameStatusForActivatedFieldCell_WhenNeighbourCellsWithMinesAroundAreEqual2()
    {
        MineField mineField = new (new bool[,]
        {
            { true, true, false },
            { false, false, false },
            { false, false, false },
        });

        MineFieldCell fieldCell = new (
            position: new FieldCellPosition(1, 1),
            isExplosiveCell: false,
            countOfCellsWithMinesAround: 2);

        fieldCell.Activate();

        Assert.Equal(expected: "2", actual: fieldCell.GameStatus);
    }

    /// <summary>
    /// Тестирует получение визуального статуса активированной ячейки, вокруг которой расположено 3 заминированных ячеек.
    /// </summary>
    [Fact]
    public void GetGameStatusForActivatedFieldCell_WhenNeighbourCellsWithMinesAroundAreEqual3()
    {
        MineField mineField = new (new bool[,]
        {
            { true, true, true },
            { false, false, false },
            { false, false, false },
        });

        MineFieldCell fieldCell = new (
            position: new FieldCellPosition(1, 1),
            isExplosiveCell: false,
            countOfCellsWithMinesAround: 3);

        fieldCell.Activate();

        Assert.Equal(expected: "3", actual: fieldCell.GameStatus);
    }

    /// <summary>
    /// Тестирует получение визуального статуса активированной ячейки, вокруг которой расположено 4 заминированных ячеек.
    /// </summary>
    [Fact]
    public void GetGameStatusForActivatedFieldCell_WhenNeighbourCellsWithMinesAroundAreEqual4()
    {
        MineField mineField = new (new bool[,]
        {
            { true, true, true },
            { false, false, true },
            { false, false, false },
        });

        MineFieldCell fieldCell = new (
            position: new FieldCellPosition(1, 1),
            isExplosiveCell: false,
            countOfCellsWithMinesAround: 4);

        fieldCell.Activate();

        Assert.Equal(expected: "4", actual: fieldCell.GameStatus);
    }

    /// <summary>
    /// Тестирует получение визуального статуса активированной ячейки, вокруг которой расположено 5 заминированных ячеек.
    /// </summary>
    [Fact]
    public void GetGameStatusForActivatedFieldCell_WhenNeighbourCellsWithMinesAroundAreEqual5()
    {
        MineField mineField = new (new bool[,]
        {
            { true, true, true },
            { false, false, true },
            { false, false, true },
        });

        MineFieldCell fieldCell = new (
            position: new FieldCellPosition(1, 1),
            isExplosiveCell: false,
            countOfCellsWithMinesAround: 5);

        fieldCell.Activate();

        Assert.Equal(expected: "5", actual: fieldCell.GameStatus);
    }

    /// <summary>
    /// Тестирует получение визуального статуса активированной ячейки, вокруг которой расположено 6 заминированных ячеек.
    /// </summary>
    [Fact]
    public void GetGameStatusForActivatedFieldCell_WhenNeighbourCellsWithMinesAroundAreEqual6()
    {
        MineField mineField = new (new bool[,]
        {
            { true, true, true },
            { false, false, true },
            { false, true, true },
        });

        MineFieldCell fieldCell = new (
            position: new FieldCellPosition(1, 1),
            isExplosiveCell: false,
            countOfCellsWithMinesAround: 6);

        fieldCell.Activate();

        Assert.Equal(expected: "6", actual: fieldCell.GameStatus);
    }

    /// <summary>
    /// Тестирует получение визуального статуса активированной ячейки, вокруг которой расположено 7 заминированных ячеек.
    /// </summary>
    [Fact]
    public void GetGameStatusForActivatedFieldCell_WhenNeighbourCellsWithMinesAroundAreEqual7()
    {
        MineField mineField = new (new bool[,]
        {
            { true, true, true },
            { false, false, true },
            { true, true, true },
        });

        MineFieldCell fieldCell = new (
            position: new FieldCellPosition(1, 1),
            isExplosiveCell: false,
            countOfCellsWithMinesAround: 7);

        fieldCell.Activate();

        Assert.Equal(expected: "7", actual: fieldCell.GameStatus);
    }

    /// <summary>
    /// Тестирует получение визуального статуса активированной ячейки, вокруг которой расположено 8 заминированных ячеек.
    /// </summary>
    [Fact]
    public void GetGameStatusForActivatedFieldCell_WhenNeighbourCellsWithMinesAroundAreEqual8()
    {
        MineField mineField = new (new bool[,]
        {
            { true, true, true },
            { true, false, true },
            { true, true, true },
        });

        MineFieldCell fieldCell = new (
            position: new FieldCellPosition(1, 1),
            isExplosiveCell: false,
            countOfCellsWithMinesAround: 8);

        fieldCell.Activate();

        Assert.Equal(expected: "8", actual: fieldCell.GameStatus);
    }

    /// <summary>
    /// Тестирует получение визуального статуса неактивированной ячейки минного поля (стартовый игровой статус).
    /// </summary>
    [Fact]
    public void GetGameStatusForNonActivatedFieldCell()
    {
        MineField mineField = CreateTestMineFieldByDefault();
        MineFieldCell fieldCell = CreateTestFieldCellByDefault(mineField);

        Assert.Equal(expected: NonActivatedFieldCellStatus, actual: fieldCell.GameStatus);
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
