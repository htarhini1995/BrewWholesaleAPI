using System;
using System.Collections.Generic;

namespace BrewWholesaleAPI.Core.Data;

public partial class Log
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public string? Message { get; set; }

    public string? Exception { get; set; }

    public string? FullExeption { get; set; }
}
