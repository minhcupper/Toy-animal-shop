using System;
using System.Collections.Generic;

namespace asmgd2_maivanminh.Models;

public partial class TbCategory
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<TbProduct> TbProducts { get; set; } = new List<TbProduct>();
}
