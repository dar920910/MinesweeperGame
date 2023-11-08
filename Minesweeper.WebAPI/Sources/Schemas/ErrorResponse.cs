// <copyright file="ErrorResponse.cs" company="Minesweeper Game Project">
// Copyright (c) Minesweeper Game Project. All rights reserved.
// </copyright>

namespace Minesweeper.WebAPI.Schemas;

/// <summary>
/// Представляет тело ответа на HTTP-запрос, который был возвращен с непредвиденной ошибкой.
/// </summary>
internal record ErrorResponse
{
    /// <summary>
    /// Сообщение об ошибке по умолчанию.
    /// </summary>
    internal const string Error = "Произошла непредвиденная ошибка";
}
