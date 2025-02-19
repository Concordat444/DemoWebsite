using Microsoft.AspNetCore.Mvc;
using DemoWebsite.Models;

namespace DemoWebsite.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IStoreRepository repository;

        public NavigationMenuViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
