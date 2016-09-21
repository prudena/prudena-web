using System;

namespace Prudena.Web.Models
{
    public enum SentimentType
    {
        Positive = 1,
        Negative = -1,
        Neutral = 0,
        Unknown = 2
    }

    public class Sentiment
    {
        static Random _r = new Random();
        public string Text { get; set; }
        public string ScoreText { get; set; }
        public double Score { get; set; }

        public SentimentType SentimentType { get; set; }
        

        public void PopulateWithTestData()
        {
            double n = _r.NextDouble();
            Score = n;
            ScoreText = n.ToString();
            n = ((n*2)-1) ;       
            if (n < -.2)
            {
                Text = "Negative";
                this.SentimentType = SentimentType.Negative;
                    
            }  else if (n > .2) {
                    Text = "Positive";
                    this.SentimentType = SentimentType.Positive;
                
            } else {
            
                Text = "Neutral";
                this.SentimentType = SentimentType.Neutral;
            }

        }
    }
}