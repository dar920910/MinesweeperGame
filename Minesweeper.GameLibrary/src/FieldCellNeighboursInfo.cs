// <copyright file="FieldCellNeighboursInfo.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.GameLibrary;

/// <summary>
/// Представляет информацию о наличии соседних ячеек для некоторой ячейки минного поля.
/// </summary>
public struct FieldCellNeighboursInfo
{
    /// <summary>
    /// Инициализирует структуру типа <see cref="FieldCellNeighboursInfo"/>.
    /// </summary>
    public FieldCellNeighboursInfo()
    {
        this.HasNeighbourOnTop = true;
        this.HasNeighbourOnTopToRight = true;
        this.HasNeighbourToRight = true;
        this.HasNeighbourOnBottomToRight = true;
        this.HasNeighbourOnBottom = true;
        this.HasNeighbourOnBottomToLeft = true;
        this.HasNeighbourToLeft = true;
        this.HasNeighbourOnTopToLeft = true;
    }

    /// <summary>
    /// Предоставляет информацию о наличии верхнего соседа для некоторой ячейки поля.
    /// </summary>
    public bool HasNeighbourOnTop { get; set; }

    /// <summary>
    /// Предоставляет информацию о наличии правого верхнего соседа для некоторой ячейки поля.
    /// </summary>
    public bool HasNeighbourOnTopToRight { get; set; }

    /// <summary>
    /// Предоставляет информацию о наличии правого соседа для некоторой ячейки поля.
    /// </summary>
    public bool HasNeighbourToRight { get; set; }

    /// <summary>
    /// Предоставляет информацию о наличии нижнего правого соседа для некоторой ячейки поля.
    /// </summary>
    public bool HasNeighbourOnBottomToRight { get; set; }

    /// <summary>
    /// Предоставляет информацию о наличии нижнего соседа для некоторой ячейки поля.
    /// </summary>
    public bool HasNeighbourOnBottom { get; set; }

    /// <summary>
    /// Предоставляет информацию о наличии левого нижнего соседа для некоторой ячейки поля.
    /// </summary>
    public bool HasNeighbourOnBottomToLeft { get; set; }

    /// <summary>
    /// Предоставляет информацию о наличии левого соседа для некоторой ячейки поля.
    /// </summary>
    public bool HasNeighbourToLeft { get; set; }

    /// <summary>
    /// Предоставляет информацию о наличии левого верхнего соседа для некоторой ячейки поля.
    /// </summary>
    public bool HasNeighbourOnTopToLeft { get; set; }
}
