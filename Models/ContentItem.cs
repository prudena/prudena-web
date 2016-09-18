using System;

namespace Prudena.Web.Models
{
    public class ContentItem
    {
        static Random _r = new Random();
        
        public string TrackbackPermalink { get; set; }
        public int Hits { get; set; }
        public int TrackbackTotal { get; set; }
        public string TopsyTrackbackUrl { get; set; }
        public string Url { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public double Score { get; set; }
        public string Highlight { get; set; }
        public Sentiment Sentiment  { get; set; }
        public DateTime FirstPostDate { get; set; }
        //public string FirstPostDateText { get { return FirstPostDate.ToShortDateString() + " " + FirstPostDate.ToShortTimeString(); } }
        public DateTime TrackbackDate { get; set; }
        //public string TrackbackDateText { get { return TrackbackDate.ToShortDateString() + " " + TrackbackDate.ToShortTimeString(); } }
        
        public ContentItem()
        {
            Sentiment = new Sentiment();
            FirstPostDate = DateTime.UtcNow;
        }

        
        public void PopulateWithDummyContent(DateTime day)
        {
            this.Sentiment.PopulateWithTestData();
            this.TopsyTrackbackUrl = "#";
            this.TrackbackTotal = _r.Next(1000);
            this.Hits = _r.Next(5000);
            this.Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris euismod augue nec ante viverra ultrices.";
            this.Score = _r.NextDouble();
            this.Title = "Lorem ipsum dolor sit amet";
            this.Highlight = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris euismod augue nec ante viverra ultrices.";
            this.FirstPostDate = day; //.AddDays(_r.Next(DaysBack) * -1);
            this.TrackbackDate = FirstPostDate;
            this.TrackbackPermalink = "#";
        }
    }
}