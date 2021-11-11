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
		decimal price;
		public Stock(string symbol) { this.symbol = symbol; }
		public event PriceChangedHandler PriceChanged; //Broadcaster event
		public decimal Price
		{
			get { return price; }
			set
			{
				if (price == value) return;         // Exit if nothing has changed
				decimal oldPrice = price;
				price = value;

				PriceChanged?.Invoke(oldPrice, price); // Invoke if not null
				// Above is excatly the same as
				//if (PriceChanged != null)           
					//PriceChanged(oldPrice, price);  // fire event.
			}
		}
	}
	class Program
    {
        static void Main(string[] args)
        {
			var stock = new Stock("MSFT");
			stock.PriceChanged += ReportPriceChange;
			stock.Price = 123;
			stock.Price = 456;
		}	
		
		static void ReportPriceChange(decimal oldPrice, decimal newPrice) //Subscriber eventhandler implementation
		{
			Console.WriteLine($"Price changed from {oldPrice} to {newPrice}");
		}
	}

	//Exercises
	//1. Add two events that fires if the price increased/decreased more than 20%. These events should fire in addition to PriceChanged event
	//2. Add yet another event that loggs the price change in a file using streams
}
