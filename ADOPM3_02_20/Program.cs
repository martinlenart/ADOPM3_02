using System;

namespace ADOPM3_02_20
{
	public class StockEvent : EventArgs
	{
		public decimal oldPrice { get; set; }
		public decimal newPrice { get; set; }
	}
	public class Stock
	{
		string symbol;
		decimal price;
		public Stock(string symbol) { this.symbol = symbol; }

		public event EventHandler PriceChanged; //Broadcaster event
		protected virtual void OnPriceChanged(EventArgs e)
		{
			PriceChanged?.Invoke(this, e); // Invoke if not null
		}
		public decimal Price
		{
			get { return price; }
			set
			{
				if (price == value) return;         // Exit if nothing has changed
				decimal oldPrice = price;
				price = value;

				OnPriceChanged(new StockEvent () {oldPrice = oldPrice, newPrice = price }); // Call the virtual Method
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
		static void ReportPriceChange(object sender, EventArgs e) //Subscriber eventhandler implementation
		{
			var mye = e as StockEvent;
			Console.WriteLine($"Price changed from {mye.oldPrice} to {mye.newPrice}");
		}
	}

	//Exercise:
	//1.	With this pattern, add two events that fires if the price increased/decreased more than 20%. 
	//		These events should fire in addition to PriceChanged event
	//2.	Add yet another event that loggs the price change in a file using streams
}
