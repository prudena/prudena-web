using System;
using System.ComponentModel.DataAnnotations;

namespace Prudena.Web.Models
{
    public class UserTickerRating
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public SystemUser Author { get; set; }

        [Required]

        public Ticker Ticker { get; set; }

        [Required]
        //[Index("IX_UserTickerRating_TickerSymbol", 1, IsUnique = false)]
        [StringLength(100)]

        public string TickerSymbol { get; set; }

        [Required]
        public string TickerName { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime DateModified { get; set; }

        [Required]
        public double CurrentRatingVeryInterestingLongAt { get; set; }

        [Required]
        public double CurrentRatingInterestingLongAt { get; set; }

        [Required]
        public double CurrentRatingVeryInterestingShortAt { get; set; }

        [Required]
        public double CurrentRatingInterestingShortAt { get; set; }

        [Required]
        public double LastPriceAtTimeOfRating { get; set; }


        [Required]
        public bool Publish { get; set; }

        public bool ShareWithStockTwits { get; set; }

        public string StockTwitsText { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }

        public string Notes { get; set; }

        public int Model201ID { get; set; }

    }

}