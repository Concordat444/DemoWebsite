using Microsoft.AspNetCore.Mvc;
using DemoWebsite.Models;

namespace DemoWebsite.Controllers
{
    public class OrderController : Controller
    {
        public ViewResult Checkout() => View(new Order());
    }
}
