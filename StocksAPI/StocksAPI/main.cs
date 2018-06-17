using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace StocksAPI
{
    public class Realtime
    {

        private string data { get; set; }
        public void stock(string symbol)
        {
            string[] ua = { "mediapartners-google", "googlebot", "googlebot-news", "adsbot-google", "googlebot-image", "googlebot-mobile", "bingbot", "msnbot", "msnbot-media", "Yahoo-MMCrawler", "DuckDuckBot", "YandexBot" };
            Random random = new Random();
            int x = random.Next(0, 12);

            var client = new WebClient();
            client.Headers.Add("user-agent", ua[x]);
            client.Headers.Add("content-type", "application/x-www-form-urlencoded");

            string URL = "https://www.nasdaq.com/callbacks/NLSHandler2.ashx";
            string postData = "msg=Last&symbol=" + symbol + "&qesymbol=" + symbol;

            data = client.UploadString(URL, postData);

        }
        public double getPrice()
        {
            try
            {
                dynamic json = JObject.Parse(data);
                double price = json.result.Price;

                return price;
            }
            catch
            {
                return -1.0;
            }
        }
        public double getChange()
        {
            try
            {
                dynamic json = JObject.Parse(data);
                double price = json.result.Price;
                double prevClose = json.result.previousclose;

                double value = price - prevClose;

                return value;
            }
            catch
            {
                return -1.0;
            }
        }
        public double getPercentChange()
        {
            try
            {
                dynamic json = JObject.Parse(data);
                double price = json.result.Price;
                double prevClose = json.result.previousclose;

                double change = price - prevClose;
                double value = change / prevClose * 100;

                return value;
            }
            catch
            {
                return -1.0;
            }
        }
        public int getVolume()
        {
            try
            {
                dynamic json = JObject.Parse(data);
                int value = json.result.totVol;

                return value;
            }
            catch
            {
                return -1;
            }
        }
        public int getConsolidatedShares()
        {
            try
            {
                dynamic json = JObject.Parse(data);
                int value = json.result.ConsolidatedShares;

                return value;
            }
            catch
            {
                return -1;
            }
        }
        public double getTodaysHigh()
        {
            try
            {
                dynamic json = JObject.Parse(data);
                double value = json.result.high;

                return value;
            }
            catch
            {
                return -1.0;
            }
        }
        public double getTodaysLow()
        {
            try
            {
                dynamic json = JObject.Parse(data);
                double value = json.result.low;

                return value;
            }
            catch
            {
                return -1.0;
            }
        }
        public double getPreviousClose()
        {
            try
            {
                dynamic json = JObject.Parse(data);
                double value = json.result.previousclose;

                return value;
            }
            catch
            {
                return -1.0;
            }
        }
        public string getMarketCloseTime()
        {
            try
            {
                dynamic json = JObject.Parse(data);
                string value = json.result.MarketCloseTime;

                return value;
            }
            catch
            {
                return "-";
            }
        }
        public string getMarketStatus()
        {
            try
            {
                dynamic json = JObject.Parse(data);
                string value = json.result.MarketStatus;

                if (value == "O")
                {
                    return "Open";
                }
                else
                {
                    return "Close";
                }
            }
            catch
            {
                return "-";
            }
        }
        public string getServerTime()
        {
            try
            {
                dynamic json = JObject.Parse(data);
                string value = json.result.ServerTime;

                return value;
            }
            catch
            {
                return "-";
            }
        }
        public string getTradeDate()
        {
            try
            {
                dynamic json = JObject.Parse(data);
                string value = json.result.tradedate;

                return value;
            }
            catch
            {
                return "-";
            }
        }

    }

    public class AboutAPI
    {
        public string getVersion()
        {
            return "2.0";
        }

        public string getCreator()
        {
            return "Michal Zavadil";
        }
    }
}
