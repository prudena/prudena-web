using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Prudena.Web.Models
{
    public enum SentimentApi
    {
        Alchemy,
        OpenAmplify,
        Test,
    }
    public enum OutputDestination
    {
        Screen,
        Excel,
        
    }

    public enum EnableFinance
    {
        Yes,
        No,

    }

    public enum ContentSource
    {
        Twitter,
        Test
    }
    public enum RefreshCache
    {
        Yes,
        No
    }
    public enum PeriodLength
    {
        Day,
        Hour,
        
    }
    public class SearchParameters
    {
        const int DEFAULT_NUMBER_OF_DAYS_BACK_FOR_START_DATE = 2;

        public SearchParameters()
        {
            SearchText = DefaultSearchText;
            Tickers = DefaultTickerText;
            PageSize = 5;
            MaxResults = 10;
            CurrentPageNumber = 1;
            UID = new Guid();
            StartDate = System.DateTime.UtcNow.AddDays(-1 * DEFAULT_NUMBER_OF_DAYS_BACK_FOR_START_DATE);
            EndDate = System.DateTime.UtcNow;
            SentimentApi = SentimentApi.Alchemy;
            RefreshCache = Models.RefreshCache.No;
            TimeWindow = "1h";
            SentimentApi = SentimentApi.Test;
            this.PeriodLength = PeriodLength.Day;
            OutputDestination = Models.OutputDestination.Screen;
            ContentSource = Models.ContentSource.Test;
            Site = string.Empty;
            
            
        }
        public string CacheKey
        {
            get
            {
                return this.SearchText + "|" + this.Tickers + "|" + this.TimeWindow.ToString() + "|" + this.StartDate.ToString() 
                    + "|" + this.EndDate.ToString() + "|" + this.PageSize.ToString() + "|" + this.MaxResults.ToString()
                    + "|" + this.SentimentApi.ToString() + "|" + this.ContentSource.ToString() + "|" + this.Site.ToString() + "|" + this.PeriodLength.ToString();
            }
        }
        public Guid UID { get; set; }
        public List<string> TickerList
        {
            get
            {
                if (string.IsNullOrEmpty(this.Tickers) || this.Tickers.Split(char.Parse(",")).Count() < 1)
                    return new List<string>();
                else
                    return new List<string>(this.Tickers.Split(char.Parse(",")));
            }
        }
        public TimeSpan TimeSpan { get { return EndDate - StartDate; } }

        [Display(Name = "Sentiment")]
        public SentimentApi SentimentApi { get; set; }

        [Display(Name = "Source")]
        public ContentSource ContentSource { get; set; }

        [Display(Name = "Output Destination")]
        public OutputDestination OutputDestination { get; set; }

        [Display(Name = "Period Length")]
        public PeriodLength PeriodLength { get; set; }

        [Display(Name = "Refresh Cache")]
        public RefreshCache RefreshCache { get; set; }
                
        [StringLength(255, ErrorMessage = "Maximum of 255 characters")]
        [Display(Name = "Search Text")]
        public string SearchText { get; set; }

        [StringLength(255, ErrorMessage = "Maximum of 255 characters")]
        [Display(Name = "Ticker")]
        public string Tickers { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public string EndDateUnixTimeStamp { get { return Utilities.DateTimeToUnixTimestamp(EndDate).ToString(); } }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        public string StartDateUnixTimeStamp { get { return Utilities.DateTimeToUnixTimestamp(StartDate).ToString(); } }


        [Display(Name = "Time Window")]
        [StringLength(50, ErrorMessage = "Maximum of 50 characters")]
        public string TimeWindow { get; set; }
        
        [Display(Name = "Page Size")]
        public int PageSize { get; set; }

        [Display(Name = "Results/Period")]
        public int MaxResults { get; set; }

        public int CurrentPageNumber { get; set; }
        public string DefaultSearchText { get; set; }
        public string DefaultTickerText { get; set; }
        public string Site { get; set; }

        public void SetDates()
        {
            if (TimeWindow.ToLower() != "custom")
            {
                EndDate = DateTime.UtcNow;
                switch (TimeWindow)
                {
                    case "h":
                        StartDate = EndDate.AddHours(-1);
                        break;
                    case "h12":
                        StartDate = EndDate.AddHours(-12);
                        break;
                    case "d":
                        StartDate = EndDate.AddDays(-1);
                        break;
                    case "d2":
                        StartDate = EndDate.AddDays(-2);
                        break;
                    case "d7":
                        StartDate = EndDate.AddDays(-7);
                        break;
                    case "d31":
                        StartDate = EndDate.AddMonths(-1);
                        break;
                    default:
                        StartDate = EndDate.AddHours(-1);
                        break;
                }

            }
        }
/*
       [Display(Name = "Show Tickers")]
        public EnableFinance EnableFinance { get; set; }

        #region Select Lists
        public SelectList TimeWindows
        {
            get
            {
                SelectList sl = new SelectList(new[]{
                new SelectListItem{ Text="Last Hour", Value="h"},
                new SelectListItem{ Text="Last 12 Hours", Value="h12"},
                new SelectListItem{ Text="Last Day", Value="d"},
                new SelectListItem{ Text="Last 2 Days", Value="d2"},
                new SelectListItem{ Text="Last Week", Value="d7"},
                new SelectListItem{ Text="Last Month", Value="d31"},
                new SelectListItem{ Text="Custom Range", Value="custom"}
                    }, "Value", "Text", "h");
                return sl;
            }
        }

        public SelectList MaxResultsOptions
        {
            get
            {
                SelectList sl = new SelectList(new[]{
                new SelectListItem{ Text="1", Value="5"},
                new SelectListItem{ Text="3", Value="3"},
                new SelectListItem{ Text="5", Value="5"},
                new SelectListItem{ Text="10", Value="10"},
                new SelectListItem{ Text="30", Value="30"},
                new SelectListItem{ Text="50", Value="50"},
                new SelectListItem{ Text="100", Value="100"},
                new SelectListItem{ Text="500", Value="500"},
                new SelectListItem{ Text="1000", Value="1000"},
                    }, "Value", "Text");
                return sl;
            }
        }

        public SelectList PageSizeOptions
        {
            get
            {
                SelectList sl = new SelectList(new[]{
                new SelectListItem{ Text="5", Value="5"},
                new SelectListItem{ Text="10", Value="10"},
                new SelectListItem{ Text="50", Value="50"},
                new SelectListItem{ Text="100", Value="100"},
                    }, "Value", "Text");
                return sl;
            }
        }
        #endregion
*/
    }

}