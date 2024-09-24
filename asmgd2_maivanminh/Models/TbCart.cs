using System;
using System.Collections.Generic;

namespace asmgd2_maivanminh.Models;

public partial class TbCart
{
    public int CartId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<TbCartDetail> TbCartDetails { get; set; } = new List<TbCartDetail>();
}
