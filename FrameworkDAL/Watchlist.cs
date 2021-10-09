namespace FrameworkDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Watchlist")]
    public partial class Watchlist
    {
        public int WatchlistId { get; set; }

        [StringLength(255)]
        public string Tickr { get; set; }

        public DateTime? EntryDate { get; set; }

        [StringLength(255)]
        public string ImageLink { get; set; }

        public int RsiWeekly { get; set; }
    }
}
