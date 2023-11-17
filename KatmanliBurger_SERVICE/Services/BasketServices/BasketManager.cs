using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.DomainModels;
using KatmanliBurger_SERVICE.Services.ByProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBurger_SERVICE.Services.BasketServices
{
	public class BasketManager : IBasketService
	{
		private IByProductService _byProductService;

		public BasketManager(IByProductService byProductService)
		{
			_byProductService = byProductService;
		}

		public void AddToBasket(Basket basket, ByProduct? product, Menu? menu, Burger? burger)
		{

			if (product != null)
			{
				BasketLine productBasketLine = basket.BasketLines.FirstOrDefault(c => c.ByProduct != null && c.ByProduct.Id == product?.Id);


				if (productBasketLine != null)
				{
					productBasketLine.ByProductQuantity++;

				}
				else
				{
					basket.BasketLines.Add(new BasketLine { ByProduct = product, ByProductQuantity = 1 });
				}
			}
			if (menu != null)
			{
				BasketLine menuBasketLine = basket.BasketLines.FirstOrDefault(c => c.Menu != null && c.Menu.Id == menu.Id);
				if (menuBasketLine != null)
				{
					menuBasketLine.MenuQuantity++;
				}
				else
				{
					basket.BasketLines.Add(new BasketLine { Menu = menu, MenuQuantity = 1 });
				}
			}
			if (burger != null)
			{
				BasketLine burgerBasketLine = basket.BasketLines.FirstOrDefault(c => c.Burger != null && c.Burger.Id == burger.Id);
				if (burgerBasketLine != null)
				{
					burgerBasketLine.BurgerQuantity++;

				}
				else
				{
					basket.BasketLines.Add(new BasketLine { Burger = burger, BurgerQuantity = 1 });
				}

			}
		}

		public ICollection<BasketLine> GetList(Basket basket)
		{
			return basket.BasketLines;
		}

		public void RemoveFromBasket(Basket basket, int? productId, int? menuId, int? burgerId)
		{
			if (productId != 0)
			{
				basket.BasketLines.Remove(basket.BasketLines.FirstOrDefault(x => x.ByProduct.Id == productId));
			}
			if (menuId != 0)
			{
				basket.BasketLines.Remove(basket.BasketLines.FirstOrDefault(x => x.Menu.Id == menuId));
			}
			if (burgerId != 0)
			{
				basket.BasketLines.Remove(basket.BasketLines.FirstOrDefault(x => x.Burger.Id == burgerId));
			}
		}
	}
}
