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
        this.CurrentMineField = field;

        this.summaryEmptyCellsCount = CalculateSummaryEmptyCellsCount(field);
        this.mineFieldCells = field.GetListOfAllFieldCells();

        this.detectedEmptyCellsCount = 0;

        this.IsGameOver = false;

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
        if (this.CurrentMineField.IsExplosiveFieldCell(customCellRow, customCellCol))
        {
            this.IsGameOver = true;

            // неудачное завершение игры (взрыв) => все ячейки открываются, мины обозначаются буквой "X"

            // обновить this.CurrentMineFieldGameStatus
        }
        else
        {
            this.detectedEmptyCellsCount++;

            if (this.detectedEmptyCellsCount == this.summaryEmptyCellsCount)
            {
                this.IsGameOver = true;

                // успешное завершение игры (открыты все пустые ячейки) => все ячейки открываются, мины обозначаются буквой "M"

                // обновить this.CurrentMineFieldGameStatus
            }
            else
            {
                this.IsGameOver = false;

                // 1. новая ячейка содержит 0 опасных соседей => откываются все смежные нулевые ячейки + смежные с ними числовые ячейки
                // 2. новая ячейка содержит от 1 до 8 опасных соседей. => открывается только текущая ячейка

                // обновить this.CurrentMineFieldGameStatus
            }
        }
    }

    private static ushort CalculateSummaryEmptyCellsCount(MineField field)
    {
        ushort summaryCellsCount = Convert.ToUInt16(field.Size.Height * field.Size.Width);
        return Convert.ToUInt16(summaryCellsCount - field.MinesCount);
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
