using KatmanliBurger_DATA.DomainModels;
using KatmanliBurger_UI.Extensions;

namespace KatmanliBurger_UI.Helpers
{
    public class BasketSessionHelper : IBasketSessionHelper
    {
        IHttpContextAccessor _httpContextAccessor;

        public BasketSessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        public Basket GetBasket(string key)
        {
           Basket basketToCheck=_httpContextAccessor.HttpContext.Session.GetObject<Basket>(key); //böyle bir sepet var mı kontrolü
            if (basketToCheck==null)
            {
                SetBasket(key, new Basket());
                basketToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Basket>(key);
            }
            return basketToCheck;
        }

        public void SetBasket(string key, Basket basket)
        {
            _httpContextAccessor.HttpContext.Session.SetObject(key, basket);
        }
    }
}
