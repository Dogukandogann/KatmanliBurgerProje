﻿using Microsoft.AspNetCore.Mvc;

namespace KatmanliBurger_WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultBookATableComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
