using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.DomainModels;

namespace KatmanliBurger_SERVICE.Services.BasketServices
{
	public class BasketManager : IBasketService
	{
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

		public void RemoveFromBasket(Basket basket, int? productId, int? menuId, int? burgerId, int? removeAll)
		{
			if (productId != 0)
			{
				var result = basket.BasketLines.FirstOrDefault(x => x.ByProductQuantity > 0 && x.ByProduct.Id == productId);
				if (removeAll == 1)
				{
					basket.BasketLines.Remove(result);
				}
				else
				{
					if (result.ByProductQuantity > 1)
					{
						result.ByProductQuantity--;
					}
					else
					{
						basket.BasketLines.Remove(result);
					}
				}

			}
			if (menuId != 0)
			{
				var result = basket.BasketLines.FirstOrDefault(x => x.MenuQuantity > 0 && x.Menu.Id == menuId);
				if (removeAll == 1)
				{
					basket.BasketLines.Remove(result);
				}
				else
				{
					if (result.MenuQuantity > 1)
					{
						result.MenuQuantity--;
					}
					else
					{
						basket.BasketLines.Remove(result);
					}
				}

			}
			if (burgerId != 0)
			{
				var result = basket.BasketLines.FirstOrDefault(x => x.BurgerQuantity > 0 && x.Burger.Id == burgerId);
				if (removeAll == 1)
				{
					basket.BasketLines.Remove(result);
				}
				else
				{
					if (result.BurgerQuantity > 1)
					{
						result.BurgerQuantity--;
					}
					else
					{
						basket.BasketLines.Remove(result);
					}
				}


			}
		}
	}
}
