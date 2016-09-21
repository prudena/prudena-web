using System;
using System.Collections.Generic;
using System.Linq;

namespace Prudena.Web.Models
{
    public class ContentCollection
    {
        private static Random _r = new Random();
        public int Ordinal { get; set; } 
        public int TotalCount { get; set; }
        public int PositiveCount { get { return (from p in Items where p.Sentiment.SentimentType ==  SentimentType.Positive select p).Count();}}
        public int NegativeCount { get { return (from p in Items where p.Sentiment.SentimentType == SentimentType.Negative select p).Count();} }
        public int NeutralCount { get {return (from p in Items where p.Sentiment.SentimentType == SentimentType.Neutral select p).Count();} }
        public int UnknownCount { get {return (from p in Items where p.Sentiment.SentimentType == SentimentType.Unknown select p).Count();} }
        
        public List<ContentItem> Items { get; set; }
        
        public DateTime CollectionDateStamp { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan TimeSpan { get; set; }

        public DateTime? EarliestFirstPostDate
        {
            get
            {
                if (Items.Count > 0)
                    return (from p in Items select p.TrackbackDate).Min();
                else
                    return null;
            }
        }
        public DateTime? LatestFirstPostDate
        {
            get
            {
                if (Items.Count > 0)
                    return (from p in Items select p.TrackbackDate).Max();
                else
                    return null;
            }
        } 

        public ContentCollection()
        {
            CollectionDateStamp = DateTime.UtcNow;
            Items = new List<ContentItem>();

        }

        public static ContentCollection GetTestCollection(int Count, DateTime startDate, DateTime endDate)
        {
            int totalCount = _r.Next(10000);
            ContentCollection collection = new ContentCollection();
            for (int i = 0; i < Count; i++)
            {
                ContentItem item = new ContentItem();
                item.PopulateWithDummyContent(startDate);
                collection.Items.Add(item);
                collection.CollectionDateStamp = DateTime.Parse(startDate.ToString("d"));
                collection.StartDate = startDate;
                collection.EndDate = endDate;
                collection.TotalCount = totalCount;
            }
            return collection;
        }
        public double GetAggregateSentimentScore()
        {
            if (Items.Count() > 0)
                return (from x in Items select x.Score).Sum();
            else
                return 0;
                
        }
       
    }
}

