// <copyright file="MineField.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.GameLibrary;

/// <summary>
/// Определяет объект минного поля указанного размера, содержащий указанное количество мин.
/// </summary>
public class MineField
{
    private const char HiddenFieldCellSymbol = ' ';

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="MineField"/> с помощью указанных параметров.
    /// </summary>
    /// <param name="fieldSize">Структура, определяющая размеры минного поля.</param>
    /// <param name="minesCount">Количество мин.</param>
    public MineField(MineFieldSize fieldSize, ushort minesCount)
    {
        if (minesCount >= fieldSize.Width * fieldSize.Height)
        {
            throw new InvalidMinesCountException(
                "Cannot create a new mine field with an invalid mines count !");
        }
        else
        {
            this.Size = fieldSize;
            this.MinesCount = minesCount;
        }
    }

    /// <summary>
    /// Размер минного поля.
    /// </summary>
    public MineFieldSize Size { get; }

    /// <summary>
    /// Количество мин в минном поле.
    /// </summary>
    public ushort MinesCount { get; }

    /// <summary>
    /// Получает массив значений всех ячеек текущего минного поля.
    /// </summary>
    /// <returns>Массив, содержащий значения всех ячеек текущего минного поля.</returns>
    public string[,] GetAllFieldCells()
    {
        return this.GetAllFieldCellsAsHiddenElements();
    }

    private string[,] GetAllFieldCellsAsHiddenElements()
    {
        string[,] fieldCells = new string[this.Size.Height, this.Size.Width];

        for (byte row = 0; row < this.Size.Height; row++)
        {
            for (byte col = 0; col < this.Size.Width; col++)
            {
                fieldCells[row, col] = HiddenFieldCellSymbol.ToString();
            }
        }

        return fieldCells;
    }
}

/// <summary>
/// Определяет исключительную ситуацию для недопустимого количества мин для минного поля.
/// </summary>
public class InvalidMinesCountException : Exception
{
    /// <summary>
    /// Инициализирует экземпляр класса исключения <see cref="InvalidMinesCountException"/>.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    public InvalidMinesCountException(string message)
        : base(message)
    {
    }
}
