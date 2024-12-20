﻿using System.ComponentModel.DataAnnotations;

namespace MovieApp.Dtos
{
    // record is mainly used to store data
    public record class MovieSummaryDto(
        int Id,
        string Title,
        string Genre,
        string Director,
        decimal TicketPrice,
        DateOnly ReleaseDate
        );

}
