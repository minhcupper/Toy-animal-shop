using System;
using System.Collections.Generic;

namespace asmgd2_maivanminh.Models;

public partial class TbProduct
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? CategoryId { get; set; }

    public decimal? Price { get; set; }

    public string? Descriptions { get; set; }

    public virtual TbCategory? Category { get; set; }

    public virtual ICollection<TbCartDetail> TbCartDetails { get; set; } = new List<TbCartDetail>();
}
