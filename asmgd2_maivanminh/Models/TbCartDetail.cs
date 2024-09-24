using System;
using System.Collections.Generic;

namespace asmgd2_maivanminh.Models;

public partial class TbCartDetail
{
    public int CartDetailId { get; set; }

    public int? CartId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public virtual TbCart? Cart { get; set; }

    public virtual TbProduct? Product { get; set; }
}
