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

    private readonly bool[,] mines;

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

            this.mines = CreateMines(fieldSize, minesCount);
        }
    }

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="MineField"/> с помощью логического массива,
    /// где элементы со значениями true соответствуют заминированным ячейкам минного поля.
    /// </summary>
    /// <param name="mines">Логический массив для создания объекта минного поля.</param>
    public MineField(bool[,] mines)
    {
        byte fieldHeight = Convert.ToByte(mines.GetLength(0));
        byte fieldWidth = Convert.ToByte(mines.GetLength(1));

        this.Size = new MineFieldSize(fieldWidth, fieldHeight);
        this.MinesCount = CalculateMinesCount(mines);
        this.mines = mines;
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

    /// <summary>
    /// Проверяет наличие мины в указанной ячейке минного поля.
    /// </summary>
    /// <param name="cellRow">Номер строки ячейки минного поля.</param>
    /// <param name="cellCol">Номер столбца ячейки минного поля.</param>
    /// <returns>Значение true, если в указанной ячейке расположена мина, в противном случае false.</returns>
    public bool IsExplosiveFieldCell(byte cellRow, byte cellCol)
    {
        if (cellCol < this.Size.Width && cellRow < this.Size.Height)
        {
            return this.mines[cellRow, cellCol];
        }
        else
        {
            throw new InvalidFieldCellException(
                "Невозможно выбрать ячейку с некорректным значением индекса строки и/или столбца !");
        }
    }

    /// <summary>
    /// Получает количество заминированных соседних ячеек вокруг выбранной ячейки минного поля.
    /// </summary>
    /// <param name="cellRow">Номер строки ячейки минного поля.</param>
    /// <param name="cellCol">Номер столбца ячейки минного поля.</param>
    /// <returns>Количество мин, расположенных в соседних ячейках вокруг указанной ячейки.</returns>
    public byte GetNeighboursMinesCountAroundFieldCell(byte cellRow, byte cellCol)
    {
        if (cellCol < this.Size.Width && cellRow < this.Size.Height)
        {
            FieldCellNeighboursInfo neighboursInfo = this.GetNeighboursInfoAroundFieldCell(cellRow, cellCol);

            byte minesCountAroundFieldCell = 0;

            if (neighboursInfo.HasNeighbourOnTop)
            {
                byte neighbourRow = (byte)(cellRow - 1);

                if (this.mines[neighbourRow, cellCol])
                {
                    minesCountAroundFieldCell++;
                }
            }

            if (neighboursInfo.HasNeighbourOnTopToRight)
            {
                byte neighbourRow = (byte)(cellRow - 1);
                byte neighbourColumn = (byte)(cellCol + 1);

                if (this.mines[neighbourRow, neighbourColumn])
                {
                    minesCountAroundFieldCell++;
                }
            }

            if (neighboursInfo.HasNeighbourToRight)
            {
                byte neighbourColumn = (byte)(cellCol + 1);

                if (this.mines[cellRow, neighbourColumn])
                {
                    minesCountAroundFieldCell++;
                }
            }

            if (neighboursInfo.HasNeighbourOnBottomToRight)
            {
                byte neighbourRow = (byte)(cellRow + 1);
                byte neighbourColumn = (byte)(cellCol + 1);

                if (this.mines[neighbourRow, neighbourColumn])
                {
                    minesCountAroundFieldCell++;
                }
            }

            if (neighboursInfo.HasNeighbourOnBottom)
            {
                byte neighbourRow = (byte)(cellRow + 1);

                if (this.mines[neighbourRow, cellCol])
                {
                    minesCountAroundFieldCell++;
                }
            }

            if (neighboursInfo.HasNeighbourOnBottomToLeft)
            {
                byte neighbourRow = (byte)(cellRow + 1);
                byte neighbourColumn = (byte)(cellCol - 1);

                if (this.mines[neighbourRow, neighbourColumn])
                {
                    minesCountAroundFieldCell++;
                }
            }

            if (neighboursInfo.HasNeighbourToLeft)
            {
                byte neighbourColumn = (byte)(cellCol - 1);

                if (this.mines[cellRow, neighbourColumn])
                {
                    minesCountAroundFieldCell++;
                }
            }

            if (neighboursInfo.HasNeighbourOnTopToLeft)
            {
                byte neighbourRow = (byte)(cellRow - 1);
                byte neighbourColumn = (byte)(cellCol - 1);

                if (this.mines[neighbourRow, neighbourColumn])
                {
                    minesCountAroundFieldCell++;
                }
            }

            return minesCountAroundFieldCell;
        }
        else
        {
            throw new InvalidFieldCellException(
                "Невозможно выбрать ячейку с некорректным значением индекса строки и/или столбца !");
        }
    }

    private static bool IsOnLeftArrayBound(byte columnIndex) => columnIndex == 0;

    private static bool IsOnTopArrayBound(byte rowIndex) => rowIndex == 0;

    private static bool IsOnRightArrayBound(byte columnIndex, byte columns) => columnIndex == (columns - 1);

    private static bool IsOnBottomArrayBound(byte rowIndex, byte rows) => rowIndex == (rows - 1);

    private static bool[,] CreateMines(MineFieldSize fieldSize, ushort minesCount)
    {
        bool[,] minesArray = new bool[fieldSize.Height, fieldSize.Width];

        for (byte row = 0; row < minesArray.GetLength(0); row++)
        {
            for (byte col = 0; col < minesArray.GetLength(1); col++)
            {
                minesArray[row, col] = false;
            }
        }

        while (minesCount > 0)
        {
            byte randomRow = Convert.ToByte(Random.Shared.Next(0, minesArray.GetLength(0)));
            byte randomCol = Convert.ToByte(Random.Shared.Next(0, minesArray.GetLength(1)));

            if (minesArray[randomRow, randomCol] is false)
            {
                minesArray[randomRow, randomCol] = true;
                minesCount--;
            }
        }

        return minesArray;
    }

    private static ushort CalculateMinesCount(bool[,] mines)
    {
        ushort minesCount = 0;

        for (int row = 0; row < mines.GetLength(0); row++)
        {
            for (int col = 0; col < mines.GetLength(1); col++)
            {
                if (mines[row, col])
                {
                    minesCount++;
                }
            }
        }

        return minesCount;
    }

    private FieldCellNeighboursInfo GetNeighboursInfoAroundFieldCell(byte cellRow, byte cellCol)
    {
        FieldCellNeighboursInfo neighboursInfo = new ();

        if (IsOnLeftArrayBound(cellCol))
        {
            neighboursInfo.HasNeighbourOnBottomToLeft = false;
            neighboursInfo.HasNeighbourToLeft = false;
            neighboursInfo.HasNeighbourOnTopToLeft = false;
        }

        if (IsOnTopArrayBound(cellRow))
        {
            neighboursInfo.HasNeighbourOnTopToLeft = false;
            neighboursInfo.HasNeighbourOnTop = false;
            neighboursInfo.HasNeighbourOnTopToRight = false;
        }

        if (IsOnRightArrayBound(cellCol, this.Size.Width))
        {
            neighboursInfo.HasNeighbourOnTopToRight = false;
            neighboursInfo.HasNeighbourToRight = false;
            neighboursInfo.HasNeighbourOnBottomToRight = false;
        }

        if (IsOnBottomArrayBound(cellRow, this.Size.Height))
        {
            neighboursInfo.HasNeighbourOnBottomToRight = false;
            neighboursInfo.HasNeighbourOnBottom = false;
            neighboursInfo.HasNeighbourOnBottomToLeft = false;
        }

        return neighboursInfo;
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

/// <summary>
/// Определяет исключительную ситуацию для выбора недопустимых координат ячейки минного поля.
/// </summary>
public class InvalidFieldCellException : Exception
{
    /// <summary>
    /// Инициализирует экземпляр класса исключения <see cref="InvalidFieldCellException"/>.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
        public InvalidFieldCellException(string message)
        : base(message)
    {
    }
}
