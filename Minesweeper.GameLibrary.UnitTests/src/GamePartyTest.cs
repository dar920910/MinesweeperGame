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
    public void CheckGameOverStatusViaUserTurn(byte customCellRow, byte customCellCol)
    {
        GameParty game = new (TestMineField);
        game.MakeTurn(customCellRow, customCellCol);
        Assert.True(game.IsGameOver);
    }
}
