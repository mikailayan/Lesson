using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniShopApp.Business.Abstract;
using MiniShopApp.WebUI.Identity;
using MiniShopApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShopApp.WebUI.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        private ICardService _cardService;
        private UserManager<User> _userManager;

        public CardController(ICardService cardService, UserManager<User> userManager)
        {
            _cardService = cardService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var card = _cardService.GetCardByUserId(_userManager.GetUserId(User));
            var model = new CardModel()
            {
                CardId = card.Id,
                CardItems = card.CardItems.Select(i => new CardItemModel()
                { 
                    CardItemId = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Price =(double)i.Product.Price,
                    ImageUrl = i.Product.ImageUrl,
                    Quantity = i.Quantity
                }).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddToCard(int productId, int quantity)
        {
            //User bilgisinden yararlanarak UserId bulunacak.
            //UserId, productId, quantity bilgilerini kullanıp bize karta ürün ekleme işlemini yapıp dönecek bir metot hazırlayalım.
            var userId = _userManager.GetUserId(User);
            _cardService.AddToCard(userId, productId, quantity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteFromCard(int productId)
        {
            var user = _userManager.GetUserId(User);
            var card = _cardService.GetCardByUserId(user);
            if (card.CardItems.Where(i=>i.ProductId == productId)
                .Select(i=>i.Quantity)
                .FirstOrDefault()==1)
            {
                var userId = _userManager.GetUserId(User);
                _cardService.DeleteFromCard(userId, productId);
                return RedirectToAction("Index");
            }
            else
            {
                //quantity'i bir azaltmam gereken yer @@@@@@
                return RedirectToAction("Index");
            }
           
           
        }
        public IActionResult CheckOut()
        {
            return View();
        }
    }
}
