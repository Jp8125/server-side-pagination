using System;
using System.Collections.Generic;

namespace server_side_pagination.Models;

public partial class Salary
{
    public int Sid { get; set; }

    public decimal? Amount { get; set; }

    public int? EmaployeId { get; set; }
}
