﻿using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace BulkyBookWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
       

        public HomeController(IUnitOfWork UnitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _UnitOfWork = UnitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
           

            IEnumerable<Product> productList = _UnitOfWork.Product.GetAll(includeProperties: "Category,CoverType");

            return View(productList);
        }
        public IActionResult Details(int productId)
        {
			ShoppingCart cart = new()
			{
				Product = _UnitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category"),
				Count = 1,
				ProductId = productId
			};
			return View(cart);
		}

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

			//_UnitOfWork.ShoppingCart.Add(shoppingCart);
			ShoppingCart cartFromDb = _UnitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId &&
			u.ProductId == shoppingCart.ProductId);

			if (cartFromDb != null)
			{
				//shopping cart exists
				cartFromDb.Count += shoppingCart.Count;
				_UnitOfWork.ShoppingCart.Update(cartFromDb);
                _UnitOfWork.Save();
            }
			else
			{
				//add cart record
				_UnitOfWork.ShoppingCart.Add(shoppingCart);
                _UnitOfWork.Save();
                HttpContext.Session.SetInt32(SD.SessionCart,
                _UnitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count());
            }
			TempData["success"] = "Cart updated successfully";

			_UnitOfWork.Save();


			return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}