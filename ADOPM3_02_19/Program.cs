﻿using System;


namespace ADOPM3_02_19
{
	public class Stock
	{
		public string Symbol { get; set; }
		public Stock(string symbol) { this.Symbol = symbol; }

		public event Action<string, decimal, decimal> PriceChanged;

		decimal _price;
		public decimal Price
		{
			get { return _price; }
			set
			{
				if (_price == value) return;         // Exit if nothing has changed
				decimal oldPrice = _price;
				_price = value;
				PriceChanged?.Invoke(Symbol, oldPrice, _price);
			}
		}
	}
	class Program
    {
        static void Main(string[] args)
        {
			var stock1 = new Stock("MSFT");
			stock1.PriceChanged += Alarm;
			stock1.Price = 1500;
			stock1.Price = 456;
			Console.WriteLine($"{stock1.Symbol, 20}: {stock1.Price}");

			var stock2 = new Stock("SAS");
			stock2.PriceChanged += Alarm;
			stock2.Price = 1;
			stock2.Price = 456;
			Console.WriteLine($"{stock2.Symbol,20}: {stock2.Price}");


			stock1.Price = 5;
		}

		static void Alarm(string symbol, decimal oldprice, decimal newprice)
        {
            Console.WriteLine($"{symbol} Price Changed from {oldprice} to {newprice}");
        }


	}

	//Exercises
	//1. Add two events that fires if the price increased/decreased more than 20%.
	//   These events should fire in addition to PriceChanged event
	//2. Add yet another event that loggs the price change in a file using streams
}
