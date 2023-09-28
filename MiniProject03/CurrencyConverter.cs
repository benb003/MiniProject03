using System;
namespace MiniProject03
{
	public class CurrencyConverter
	{
		internal static double ShowLocalCurrency(Office office, Double price)
		{			
			if (office.Currency == Currency.Kron)
			{
				return (double)price * 11;
			}
			else if(office.Currency==Currency.Pound)
			{
				return (double)price * 0.8;
			}
			else
			{
				return price;
			}
		}
	}
}

