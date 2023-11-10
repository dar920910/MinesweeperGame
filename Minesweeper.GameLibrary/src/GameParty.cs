// <copyright file="GameParty.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.GameLibrary;

/// <summary>
/// Представляет объект однопользовательской партии игры "Сапёр".
/// </summary>
public class GameParty
{
    private static readonly Dictionary<string, GameParty> GamesHistory;

    private readonly ushort summaryEmptyCellsCount;
    private readonly List<MineFieldCell> mineFieldCells;

    private List<MineFieldCell> activatedFieldCells;
    private ushort detectedEmptyCellsCount;

    static GameParty()
    {
        GamesHistory = new Dictionary<string, GameParty>();
    }

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="GameParty"/> с помощью объекта минного поля.
    /// </summary>
    /// <param name="field">Объект минного поля для текущей игровой партии.</param>
    public GameParty(MineField field)
    {
        this.ID = Guid.NewGuid();
        this.IsGameOver = false;

        this.CurrentMineField = field;
        this.mineFieldCells = this.CurrentMineField.GetListOfAllFieldCells();
        this.CurrentMineFieldGameStatus = InitializeMineFieldGameStatus(this.mineFieldCells);
        this.summaryEmptyCellsCount = CalculateSummaryEmptyCellsCount(this.CurrentMineField);

        this.activatedFieldCells = new List<MineFieldCell>();
        this.detectedEmptyCellsCount = 0;

        GamesHistory.Add(this.ID.ToString(), this);
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
    /// Получает текущее состояние ячеек минного поля текущей игровой партии.
    /// </summary>
    public Dictionary<FieldCellPosition, string> CurrentMineFieldGameStatus { get; private set; }

    /// <summary>
    /// Получает сведения об игровой партии из глобальной истории игры по указанному идентификатору.
    /// </summary>
    /// <param name="gamePartyID">Идентификатор игровой партии.</param>
    /// <returns>Объект игровой партии, соответствующий указанному идентификатору.</returns>
    public static GameParty GetGamePartyByID(string gamePartyID)
    {
        if (GamesHistory.ContainsKey(gamePartyID))
        {
            return GamesHistory[gamePartyID];
        }
        else
        {
            throw new GamePartyNotFoundException(
                "Игровая партия с указанным идентификатором не найдена в глобальной истории игры !");
        }
    }

    /// <summary>
    /// Сделать игровой ход с помощью указания координат ячейки минного поля.
    /// </summary>
    /// <param name="customCellRow">Номер строки ячейки, выбранной игроком на минном поле.</param>
    /// <param name="customCellCol">Номер столбца ячейки, выбранной игроком на минном поле.</param>
    public void MakeTurn(byte customCellRow, byte customCellCol)
    {
        if (this.IsAlreadyActivatedFieldCell(customCellRow, customCellCol))
        {
            throw new FieldCellIsAlreadyActivatedException("Невозможно выбрать уже открытую ячейку в текущей игре !");
        }

        MineFieldCell selectedFieldCell = new (
            position: new FieldCellPosition(customCellRow, customCellCol),
            isExplosiveCell: this.CurrentMineField.IsExplosiveFieldCell(customCellRow, customCellCol),
            countOfCellsWithMinesAround: this.CurrentMineField.GetNeighboursMinesCountAroundFieldCell(customCellRow, customCellCol));

        if (this.CurrentMineField.IsExplosiveFieldCell(customCellRow, customCellCol))
        {
            this.IsGameOver = true;

            // неудачное завершение игры (взрыв) => все ячейки открываются, мины обозначаются буквой "X"
            foreach (MineFieldCell cell in this.mineFieldCells)
            {
                cell.Activate();
                this.CurrentMineFieldGameStatus[cell.Position] = cell.GameStatus;
            }
        }
        else
        {
            this.detectedEmptyCellsCount++;

            if (this.detectedEmptyCellsCount == this.summaryEmptyCellsCount)
            {
                this.IsGameOver = true;
                selectedFieldCell.Activate();

                // успешное завершение игры (открыты все пустые ячейки) => все ячейки открываются, мины обозначаются буквой "M"
                this.CurrentMineFieldGameStatus[selectedFieldCell.Position] = selectedFieldCell.GameStatus;

                foreach (MineFieldCell cell in this.mineFieldCells)
                {
                    if (cell.IsExplosiveCell)
                    {
                        this.CurrentMineFieldGameStatus[cell.Position] = MineFieldCell.NonActivatedExplosiveFieldCellStatus;
                    }
                }
            }
            else
            {
                this.IsGameOver = false;
                selectedFieldCell.Activate();

                if (selectedFieldCell.CountOfCellsWithMinesAround == 0)
                {
                    // Если выбранная ячейка содержит 0 опасных соседей, то открываются все смежные нулевые ячейки + смежные с ними числовые ячейки.
                    this.CurrentMineFieldGameStatus[selectedFieldCell.Position] = selectedFieldCell.GameStatus; // временный вариант-заглушка

                    /*
                        Ориентировочный алгоритм:
                        1. открыть выбранную ячейку.
                        2. открыть все соседние нулевые ячейки.
                        3. для каждой нулевой ячейки открыть числовые ячейки.
                    */
                }
                else
                {
                    // Если выбранная ячейка содержит от 1 до 8 опасных соседей, то открывается только текущая ячейка.
                    this.CurrentMineFieldGameStatus[selectedFieldCell.Position] = selectedFieldCell.GameStatus;
                }
            }
        }

        this.activatedFieldCells.Add(selectedFieldCell);
    }

    private static ushort CalculateSummaryEmptyCellsCount(MineField field)
    {
        ushort summaryCellsCount = Convert.ToUInt16(field.Size.Height * field.Size.Width);
        return Convert.ToUInt16(summaryCellsCount - field.MinesCount);
    }

    private static Dictionary<FieldCellPosition, string> InitializeMineFieldGameStatus(List<MineFieldCell> fieldCells)
    {
        Dictionary<FieldCellPosition, string> mineFieldGameStatus = new ();

        foreach (var cell in fieldCells)
        {
            mineFieldGameStatus.Add(cell.Position, cell.GameStatus);
        }

        return mineFieldGameStatus;
    }

    private bool IsAlreadyActivatedFieldCell(byte cellRow, byte cellCol)
    {
        foreach (MineFieldCell cell in this.activatedFieldCells)
        {
            if ((cell.Position.Row == cellRow) && (cell.Position.Col == cellCol))
            {
                return true;
            }
        }

        return false;
    }
}

/// <summary>
/// Определяет исключительную ситуацию для отсутствия игровой партии в глобальной истории игры.
/// </summary>
public class GamePartyNotFoundException : Exception
{
    /// <summary>
    /// Инициализирует экземпляр класса исключения <see cref="GamePartyNotFoundException"/>.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    public GamePartyNotFoundException(string message)
        : base(message)
    {
    }
}

/// <summary>
/// Определяет исключительную ситуацию для попытки игрока повторно выбрать уже активированную ячейку минного поля.
/// </summary>
public class FieldCellIsAlreadyActivatedException : Exception
{
    /// <summary>
    /// Инициализирует экземпляр класса исключения <see cref="FieldCellIsAlreadyActivatedException"/>.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    public FieldCellIsAlreadyActivatedException(string message)
        : base(message)
    {
    }
}
