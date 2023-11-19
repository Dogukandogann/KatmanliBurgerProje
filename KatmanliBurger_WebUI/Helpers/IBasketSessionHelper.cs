using KatmanliBurger_DATA.DomainModels;

namespace KatmanliBurger_UI.Helpers
{
    public interface IBasketSessionHelper
    {
        Basket GetBasket(string key);
        void SetBasket(string key, Basket basket);
        void Clear();
    }
}
