// <copyright file="GameParty.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.GameLibrary;

/// <summary>
/// Представляет объект однопользовательской партии игры "Сапёр".
/// </summary>
public class GameParty
{
    private readonly MineField gameMineField;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="GameParty"/> с помощью объекта минного поля.
    /// </summary>
    /// <param name="field">Объект минного поля для текущей игровой партии.</param>
    public GameParty(MineField field)
    {
        this.gameMineField = field;
    }

    /// <summary>
    /// Получает значение, отражающее статус завершения текущей игровой партии.
    /// </summary>
    public bool IsGameOver { get; private set; }

    /// <summary>
    /// Сделать игровой ход с помощью указания координат ячейки минного поля.
    /// </summary>
    /// <param name="customCellRow">Номер строки ячейки, выбранной игроком на минном поле.</param>
    /// <param name="customCellCol">Номер столбца ячейки, выбранной игроком на минном поле.</param>
    public void MakeTurn(byte customCellRow, byte customCellCol)
    {
        if (this.gameMineField.IsExplosiveFieldCell(customCellRow, customCellCol))
        {
            this.IsGameOver = true;
        }
        else
        {
            this.IsGameOver = false;
        }
    }
}
