
namespace Prudena.Web.Models
{
    public class AlchemyApiHelper
    {
        public static Sentiment TextGetTextSentiment(ContentItem item)
        {
            Sentiment sentiment = new Sentiment();
            /*          AlchemyAPI.AlchemyAPI alchemyObj = new AlchemyAPI.AlchemyAPI();
                      alchemyObj.SetAPIKey(ConfigurationManager.AppSettings["AlchemyAPIKey"]);

                      try
                      {
                          string xml = alchemyObj.TextGetTextSentiment(item.Content);
                          XmlDocument xmlDoc = new XmlDocument();
                          xmlDoc.LoadXml(xml);

                          sentiment.Text = xmlDoc.SelectSingleNode("/results/docSentiment/type").InnerText;
                          if (sentiment.Text.ToLower().Contains("positive"))
                              sentiment.SentimentType = SentimentType.Positive;
                          else if (sentiment.Text.ToLower().Contains("negative"))
                              sentiment.SentimentType = SentimentType.Negative;
                          else if (sentiment.Text.ToLower().Contains("neutral"))
                              sentiment.SentimentType = SentimentType.Neutral;

                          try
                          {
                              sentiment.Score = double.Parse(xmlDoc.SelectSingleNode("/results/docSentiment/score").InnerText);
                              sentiment.ScoreText = xmlDoc.SelectSingleNode("/results/docSentiment/score").InnerText;
                          }
                          catch
                          {
                              sentiment.Score = 0;
                              sentiment.ScoreText = string.Empty;
                          }

                      }
                      catch (Exception e)
                      {
                          if (e.Message.Contains("unsupported-text-language"))
                          {
                              sentiment.Text = "Not English";
                              sentiment.ScoreText = string.Empty;
                              sentiment.SentimentType = SentimentType.Unknown;
                          }
                          else
                          {
                              throw e;
                          }
                      }
              */                    
            return sentiment;
        }
    }
}