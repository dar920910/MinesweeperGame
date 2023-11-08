// <copyright file="GamePartyTest.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.GameLibrary.UnitTests;

using Minesweeper.GameLibrary;
using Xunit;

/// <summary>
/// Тестовый класс, который содержит модульные тесты для проверки функциональности класса <see cref="GameParty"/>.
/// </summary>
public class GamePartyTest
{
    private static readonly MineField TestMineField;

    static GamePartyTest()
    {
        TestMineField = new MineField(new bool[,]
        {
            { false, true, false, },
            { true, false, true, },
            { false, true, false, },
        });
    }

    /// <summary>
    /// Тестирует завершение игровой партии в результате попадания игрока на мину.
    /// </summary>
    /// <param name="customCellRow">Номер строки ячейки, выбранной игроком на минном поле.</param>
    /// <param name="customCellCol">Номер столбца ячейки, выбранной игроком на минном поле.</param>
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 0)]
    [InlineData(1, 2)]
    [InlineData(2, 1)]
    public void CheckGameOverStatusAfterMineDetection(byte customCellRow, byte customCellCol)
    {
        GameParty game = new (TestMineField);
        game.MakeTurn(customCellRow, customCellCol);
        Assert.True(game.IsGameOver);
    }

    /// <summary>
    /// Тестирует завершение игровой партии в результате попаданий игрока во все пустые (не заминированные) ячейки поля.
    /// Случай № 1 - Приблизительно равное количество пустых и заминированных ячеек на минном поле.
    /// </summary>
    [Fact]
    public void CheckGameOverStatusAfterSuccessfulTurns_TestCase_1()
    {
        GameParty game = new (TestMineField);

        game.MakeTurn(0, 0);
        game.MakeTurn(0, 2);
        game.MakeTurn(1, 1);
        game.MakeTurn(2, 2);
        game.MakeTurn(2, 0);

        Assert.True(game.IsGameOver);
    }

    /// <summary>
    /// Тестирует завершение игровой партии в результате попаданий игрока во все пустые (не заминированные) ячейки поля.
    /// Случай № 2 - Все ячейки в минном поле являются пустыми.
    /// </summary>
    [Fact]
    public void CheckGameOverStatusAfterSuccessfulTurns_TestCase_2()
    {
        GameParty game = new (new MineField(new bool[,]
        {
            { false, false, false, },
            { false, false, false, },
            { false, false, false, },
        }));

        game.MakeTurn(0, 0);
        game.MakeTurn(0, 1);
        game.MakeTurn(0, 2);
        game.MakeTurn(1, 2);
        game.MakeTurn(1, 1);
        game.MakeTurn(1, 0);
        game.MakeTurn(2, 0);
        game.MakeTurn(2, 1);
        game.MakeTurn(2, 2);

        Assert.True(game.IsGameOver);
    }

    /// <summary>
    /// Тестирует завершение игровой партии в результате попаданий игрока во все пустые (не заминированные) ячейки поля.
    /// Случай № 3 - Все ячейки в минном поле являются заминированными, кроме единственной пустой ячейки.
    /// </summary>
    [Fact]
    public void CheckGameOverStatusAfterSuccessfulTurns_TestCase_3()
    {
        GameParty game = new (new MineField(new bool[,]
        {
            { true, true, true, },
            { true, false, true, },
            { true, true, true, },
        }));

        game.MakeTurn(1, 1);

        Assert.True(game.IsGameOver);
    }
}
