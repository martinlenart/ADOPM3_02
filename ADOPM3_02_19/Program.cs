using System;
using InADifferentFile;

namespace InADifferentFile
{
    //Delegate Type - Subscriber Eventhandler Type, without EventArgs for this example
    public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);
}

namespace ADOPM3_02_19
{
	public class Stock
	{
		string symbol;
		public Stock(string symbol) { this.symbol = symbol; }
		public event PriceChangedHandler PriceChanged; //Broadcaster event
		public event PriceChangedHandler PriceChangedMoreThan20; //Broadcaster event

		decimal _price;
		public decimal Price
		{
			get { return _price; }
			set
			{
				if (_price == value) return;         // Exit if nothing has changed
				decimal oldPrice = _price;
				_price = value;

				PriceChanged?.Invoke(oldPrice, _price); // Invoke if not null
				// Above is excatly the same as
				//if (PriceChanged != null)           
					//PriceChanged(oldPrice, price);  // fire event.

				if (_price >= oldPrice*1.20M)
                {
					PriceChangedMoreThan20?.Invoke(oldPrice, _price);							
                }
			}
		}
	}
	class Program
    {
        static void Main(string[] args)
        {
			var stock = new Stock("MSFT");
			stock.Price = 123;
			stock.PriceChanged += ReportPriceChange;
			stock.PriceChangedMoreThan20 += ReportPriceChangeMoreThan20;
			stock.Price = 456;
            Console.WriteLine(stock.Price);
		}

		static void ReportPriceChange(decimal oldPrice, decimal newPrice) //Subscriber eventhandler implementation
		{
			Console.WriteLine($"Price changed from {oldPrice} to {newPrice}");
		}
		static void ReportPriceChangeMoreThan20(decimal oldPrice, decimal newPrice) //Subscriber eventhandler implementation
		{
			Console.WriteLine($"Sell");
		}
	}

	//Exercises
	//1. Add two events that fires if the price increased/decreased more than 20%.
	//   These events should fire in addition to PriceChanged event
	//2. Add yet another event that loggs the price change in a file using streams
}
