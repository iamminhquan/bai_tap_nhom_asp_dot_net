using Microsoft.AspNetCore.Mvc;
using BaiTapNhom02_Lan_02.Services;
namespace BaiTapNhom02_Lan_02.BikesViewComponents
{
    public class BikesViewComponent : ViewComponent
    {
        private readonly ProductServices _productsevices;

        public BikesViewComponent (ProductServices productsevices)
        {
            _productsevices = productsevices;
        }

        public IViewComponentResult Invoke()
        {
            var bike = _productsevices.GetRanDomTop6Products();
            return View(bike);
        }
    }
}
