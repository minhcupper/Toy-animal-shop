using System;
using System.Collections.Generic;

namespace asmgd2_maivanminh.Models;

public partial class TbCustomer
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Pass { get; set; }

    public string? Email { get; set; }

    public string? Addresz { get; set; }

    public string? Phone { get; set; }
}
