// <copyright file="MineFieldTest.FieldCellsNeighbours.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.GameLibrary.UnitTests;

using Xunit;
using Minesweeper.GameLibrary;

/// <summary>
/// Тестовый класс, который содержит модульные тесты для проверки функциональности класса <see cref="MineField"/>.
/// </summary>
public partial class MineFieldTest
{
    private const byte TestFieldCellRow = 1;
    private const byte TestFieldCellCol = 1;

    /// <summary>
    /// Проверяет количество заминированных соседних ячеек вокруг выбранной ячейки минного поля.
    /// Данный тест рассматривает случай, когда количество мин, расположенных вокруг ячейки, равно 0.
    /// </summary>
    [Fact]
    public static void GetNeighboursMinesCountForFieldCell_WhenMinesAroundAreEqual_0()
    {
        MineField mineField = new (new bool[,]
        {
            { false, false, false, },
            { false, false, false, },
            { false, false, false, },
        });

        byte neighbourMinesCount = mineField.GetNeighboursMinesCountAroundFieldCell(
            TestFieldCellRow, TestFieldCellCol);

        Assert.Equal(expected: 0, actual: neighbourMinesCount);
    }

    /// <summary>
    /// Проверяет количество заминированных соседних ячеек вокруг выбранной ячейки минного поля.
    /// Данный тест рассматривает случай, когда количество мин, расположенных вокруг ячейки, равно 1.
    /// </summary>
    [Fact]
    public static void GetNeighboursMinesCountForFieldCell_WhenMinesAroundAreEqual_1()
    {
        MineField mineField = new (new bool[,]
        {
            { true, false, false, },
            { false, false, false, },
            { false, false, false, },
        });

        byte neighbourMinesCount = mineField.GetNeighboursMinesCountAroundFieldCell(
            TestFieldCellRow, TestFieldCellCol);

        Assert.Equal(expected: 1, actual: neighbourMinesCount);
    }

    /// <summary>
    /// Проверяет количество заминированных соседних ячеек вокруг выбранной ячейки минного поля.
    /// Данный тест рассматривает случай, когда количество мин, расположенных вокруг ячейки, равно 2.
    /// </summary>
    [Fact]
    public static void GetNeighboursMinesCountForFieldCell_WhenMinesAroundAreEqual_2()
    {
        MineField mineField = new (new bool[,]
        {
            { true, true, false, },
            { false, false, false, },
            { false, false, false, },
        });

        byte neighbourMinesCount = mineField.GetNeighboursMinesCountAroundFieldCell(
            TestFieldCellRow, TestFieldCellCol);

        Assert.Equal(expected: 2, actual: neighbourMinesCount);
    }

    /// <summary>
    /// Проверяет количество заминированных соседних ячеек вокруг выбранной ячейки минного поля.
    /// Данный тест рассматривает случай, когда количество мин, расположенных вокруг ячейки, равно 3.
    /// </summary>
    [Fact]
    public static void GetNeighboursMinesCountForFieldCell_WhenMinesAroundAreEqual_3()
    {
        MineField mineField = new (new bool[,]
        {
            { true, true, true, },
            { false, false, false, },
            { false, false, false, },
        });

        byte neighbourMinesCount = mineField.GetNeighboursMinesCountAroundFieldCell(
            TestFieldCellRow, TestFieldCellCol);

        Assert.Equal(expected: 3, actual: neighbourMinesCount);
    }

    /// <summary>
    /// Проверяет количество заминированных соседних ячеек вокруг выбранной ячейки минного поля.
    /// Данный тест рассматривает случай, когда количество мин, расположенных вокруг ячейки, равно 4.
    /// </summary>
    [Fact]
    public static void GetNeighboursMinesCountForFieldCell_WhenMinesAroundAreEqual_4()
    {
        MineField mineField = new (new bool[,]
        {
            { true, true, true, },
            { false, false, true, },
            { false, false, false, },
        });

        byte neighbourMinesCount = mineField.GetNeighboursMinesCountAroundFieldCell(
            TestFieldCellRow, TestFieldCellCol);

        Assert.Equal(expected: 4, actual: neighbourMinesCount);
    }

    /// <summary>
    /// Проверяет количество заминированных соседних ячеек вокруг выбранной ячейки минного поля.
    /// Данный тест рассматривает случай, когда количество мин, расположенных вокруг ячейки, равно 5.
    /// </summary>
    [Fact]
    public static void GetNeighboursMinesCountForFieldCell_WhenMinesAroundAreEqual_5()
    {
        MineField mineField = new (new bool[,]
        {
            { true, true, true, },
            { false, false, true, },
            { false, false, true, },
        });

        byte neighbourMinesCount = mineField.GetNeighboursMinesCountAroundFieldCell(
            TestFieldCellRow, TestFieldCellCol);

        Assert.Equal(expected: 5, actual: neighbourMinesCount);
    }

    /// <summary>
    /// Проверяет количество заминированных соседних ячеек вокруг выбранной ячейки минного поля.
    /// Данный тест рассматривает случай, когда количество мин, расположенных вокруг ячейки, равно 6.
    /// </summary>
    [Fact]
    public static void GetNeighboursMinesCountForFieldCell_WhenMinesAroundAreEqual_6()
    {
        MineField mineField = new (new bool[,]
        {
            { true, true, true, },
            { false, false, true, },
            { false, true, true, },
        });

        byte neighbourMinesCount = mineField.GetNeighboursMinesCountAroundFieldCell(
            TestFieldCellRow, TestFieldCellCol);

        Assert.Equal(expected: 6, actual: neighbourMinesCount);
    }

    /// <summary>
    /// Проверяет количество заминированных соседних ячеек вокруг выбранной ячейки минного поля.
    /// Данный тест рассматривает случай, когда количество мин, расположенных вокруг ячейки, равно 7.
    /// </summary>
    [Fact]
    public static void GetNeighboursMinesCountForFieldCell_WhenMinesAroundAreEqual_7()
    {
        MineField mineField = new (new bool[,]
        {
            { true, true, true, },
            { false, false, true, },
            { true, true, true, },
        });

        byte neighbourMinesCount = mineField.GetNeighboursMinesCountAroundFieldCell(
            TestFieldCellRow, TestFieldCellCol);

        Assert.Equal(expected: 7, actual: neighbourMinesCount);
    }

    /// <summary>
    /// Проверяет количество заминированных соседних ячеек вокруг выбранной ячейки минного поля.
    /// Данный тест рассматривает случай, когда количество мин, расположенных вокруг ячейки, равно 8.
    /// </summary>
    [Fact]
    public static void GetNeighboursMinesCountForFieldCell_WhenMinesAroundAreEqual_8()
    {
        MineField mineField = new (new bool[,]
        {
            { true, true, true, },
            { true, false, true, },
            { true, true, true, },
        });

        byte neighbourMinesCount = mineField.GetNeighboursMinesCountAroundFieldCell(
            TestFieldCellRow, TestFieldCellCol);

        Assert.Equal(expected: 8, actual: neighbourMinesCount);
    }

    /// <summary>
    /// Тестирует выброс исключения <see cref="InvalidFieldCellException"/>
    /// при получении количества соседних заминированных ячеек в случае
    /// указания недопустимых координат ячейки минного поля.
    /// </summary>
    /// <param name="fieldWidth">Ширина минного поля в количестве ячеек.</param>
    /// <param name="fieldHeight">Высота минного поля в количестве ячеек.</param>
    [Theory]
    [InlineData(0, 3)]
    [InlineData(3, 0)]
    [InlineData(3, 3)]
    public void GetNeighboursMinesCountForFieldCell_WhenInvalidFieldCellSelection(byte fieldWidth, byte fieldHeight)
    {
        MineField mineField = new (new bool[,]
        {
            { false, false, false, },
            { false, false, false, },
            { false, false, false, },
        });

        Assert.Throws<InvalidFieldCellException>(() => mineField.GetNeighboursMinesCountAroundFieldCell(fieldWidth, fieldHeight));
    }
}
