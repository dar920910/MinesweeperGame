// <copyright file="MineFieldTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
    /// Тестирует выброс исключения <see cref="InvalidMinesCountException"/>
    /// при указании недопустимого количества мин в момент создания объекта минного поля.
    /// </summary>
    /// <param name="fieldWidth">Ширина минного поля в количестве ячеек.</param>
    /// <param name="fieldHeight">Высота минного поля в количестве ячеек.</param>
    /// <param name="minesCount">Количество мин в минном поле.</param>
    [Theory]
    [InlineData(2, 2, 4)]
    [InlineData(2, 2, 5)]
    [InlineData(5, 5, 50)]
    [InlineData(10, 10, 500)]
    [InlineData(30, 30, 1000)]
    public void CreateMineFieldWithInvalidMinesCount(byte fieldWidth, byte fieldHeight, ushort minesCount)
    {
        Assert.Throws<InvalidMinesCountException>(() => new MineField(new MineFieldSize(fieldWidth, fieldHeight), minesCount));
    }

    /// <summary>
    /// Тестирует получение значений всех ячеек минного поля в начале игры "Сапёр".
    /// </summary>
    /// <param name="fieldWidth">Ширина минного поля в количестве ячеек.</param>
    /// <param name="fieldHeight">Высота минного поля в количестве ячеек.</param>
    [Theory]
    [InlineData(2, 2)]
    [InlineData(5, 5)]
    [InlineData(10, 10)]
    [InlineData(30, 10)]
    [InlineData(10, 30)]
    [InlineData(30, 30)]
    public void GetAllFieldCellsWhenGameStart(byte fieldWidth, byte fieldHeight)
    {
        ushort minesCount = GenerateRandomMinesCount(fieldWidth, fieldHeight);

        string[,] expectedMineField = GenerateUnknownCellsArray(fieldHeight, fieldWidth);
        string[,] actualMineField = new MineField(
            new MineFieldSize(fieldWidth, fieldHeight), minesCount)
            .GetAllFieldCells();

        Assert.Equal(expected: expectedMineField, actual: actualMineField);
    }

    private static ushort GenerateRandomMinesCount(byte fieldWidth, byte fieldHeight) =>
        Convert.ToUInt16(Random.Shared.Next(ushort.MinValue, fieldWidth * fieldHeight));

    private static string[,] GenerateUnknownCellsArray(byte rows, byte cols)
    {
        const char hiddenCellSymbol = ' ';

        string[,] array = new string[rows, cols];
        for (byte row = 0; row < rows; row++)
        {
            for (byte col = 0; col < cols; col++)
            {
                array[row, col] = hiddenCellSymbol.ToString();
            }
        }

        return array;
    }
}
