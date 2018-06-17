using StocksAPI;
using System;

namespace StocksAPIExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Realtime realtime = new Realtime();
            AboutAPI api = new AboutAPI();

            Console.WriteLine("Creator: " + api.getCreator());
            Console.WriteLine("Version: " + api.getVersion());

            Console.Write("Symbol: ");
            string symbol = Console.ReadLine();

            realtime.stock(symbol);

            int vol = realtime.getVolume();
            double price = realtime.getPrice();
            double change = realtime.getChange();
            double perChange = realtime.getPercentChange();
            double todaysHigh = realtime.getTodaysHigh();
            double todaysLow = realtime.getTodaysLow();
            double prevClose = realtime.getPreviousClose();
            string serverTime = realtime.getServerTime();
            string marketStatus = realtime.getMarketStatus();
            string tradeDate = realtime.getTradeDate();
            string marketCloseTime = realtime.getMarketCloseTime();

            Console.WriteLine("Volume: " + vol);
            Console.WriteLine("Price: $" + price);
            Console.WriteLine("Change: " + change);
            Console.WriteLine("Percent Change: " + perChange);
            Console.WriteLine("Todays High: $" + todaysHigh);
            Console.WriteLine("Todays Low: $" + todaysLow);
            Console.WriteLine("Previous Close: $" + prevClose);
            Console.WriteLine("Server time: " + serverTime);
            Console.WriteLine("Trade date: " + tradeDate);
            Console.WriteLine("Market status: " + marketStatus);
            Console.WriteLine("Market close time: " + marketCloseTime);

            Console.ReadKey();
        }
    }
}
