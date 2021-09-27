namespace FrameworkDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trade")]
    public partial class Trade
    {
        public int TradeId { get; set; }

        [StringLength(10)]
        public string TICKR { get; set; }

        [StringLength(10)]
        public string EntryPattern { get; set; }

        [StringLength(10)]
        public string EntryPrice { get; set; }

        [StringLength(10)]
        public string ExitPrice { get; set; }

        public DateTime? EntryDateTime { get; set; }

        public DateTime? ExitDateTime { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        [StringLength(4000)]
        public string Notes { get; set; }

        [StringLength(255)]
        public string ImageLink { get; set; }
    }
}
