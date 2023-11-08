// <copyright file="MineFieldTest.FieldCellsChecking.cs" company="Minesweeper Game Project">
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
    /// <summary>
    /// Проверяет, содержит ли мину указанная ячейка поля.
    /// </summary>
    /// <param name="cellRow">Номер строки ячейки, выбранной игроком на минном поле.</param>
    /// <param name="cellCol">Номер столбца ячейки, выбранной игроком на минном поле.</param>
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 0)]
    [InlineData(1, 2)]
    [InlineData(2, 1)]
    public void IsExplosiveFieldCell(byte cellRow, byte cellCol)
    {
        MineField mineField = GetTestSquareMineField();
        Assert.True(mineField.IsExplosiveFieldCell(cellRow, cellCol));
    }

    /// <summary>
    /// Проверяет, является ли указанная ячейка поля пустой (не заминированной).
    /// </summary>
    /// <param name="cellRow">Номер строки ячейки, выбранной игроком на минном поле.</param>
    /// <param name="cellCol">Номер столбца ячейки, выбранной игроком на минном поле.</param>
    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 2)]
    [InlineData(1, 1)]
    [InlineData(2, 0)]
    [InlineData(2, 2)]
    public void IsNotExplosiveFieldCell(byte cellRow, byte cellCol)
    {
        MineField mineField = GetTestSquareMineField();
        Assert.False(mineField.IsExplosiveFieldCell(cellRow, cellCol));
    }

    private static MineField GetTestSquareMineField()
    {
        return new (new bool[,]
        {
            { false, true, false, },
            { true, false, true, },
            { false, true, false, },
        });
    }
}
