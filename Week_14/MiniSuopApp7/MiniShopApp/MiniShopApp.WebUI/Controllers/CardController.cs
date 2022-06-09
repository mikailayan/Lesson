using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniShopApp.Business.Abstract;
using MiniShopApp.Core;
using MiniShopApp.Entity;
using MiniShopApp.WebUI.Identity;
using MiniShopApp.WebUI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderItem = MiniShopApp.Entity.OrderItem;

namespace MiniShopApp.WebUI.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        private ICardService _cardService;
        private UserManager<User> _userManager;
        private IOrderService _orderService;

        public CardController(ICardService cardService, UserManager<User> userManager, IOrderService orderService)
        {
            _cardService = cardService;
            _userManager = userManager;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            Luhnalgorithm(Kartno);
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
            var userId = _userManager.GetUserId(User);
            var card = _cardService.GetCardByUserId(userId);
            var orderModel = new OrderModel();
            orderModel.CardModel = new CardModel()
            {
                CardId = card.Id,
                CardItems = card.CardItems.Select(i => new CardItemModel() {
                    CardItemId =i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Price = (double)i.Product.Price,
                    ImageUrl = i.Product.ImageUrl,
                    Quantity = i.Quantity
                }).ToList()
            };
            return View(orderModel);
        }
        [HttpPost]
        public IActionResult CheckOut(OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var card = _cardService.GetCardByUserId(userId);
                orderModel.CardModel = new CardModel()
                {
                    CardId = card.Id,
                    CardItems = card.CardItems.Select(i=> new CardItemModel() {
                        CardItemId = i.Id,
                        ProductId = i.ProductId,
                        Name = i.Product.Name,
                        Price = (double)i.Product.Price,
                        ImageUrl = i.Product.ImageUrl,
                        Quantity = i.Quantity
                    }).ToList()
                };
                //ödeme islemine basla 
                var payment = PaymentProcess(orderModel);
                if (payment.Status=="success")
                {
                    SaveOrder(orderModel, userId, payment);
                    //ClearCard();
                    TempData["Message"] = JobManager.CreateMessage("Bilgi", "Ödemeniz başarıyla gerçekleşmiştir", "success");
                    return Redirect("~/");
                }
                else
                {
                    TempData["Message"] = JobManager.CreateMessage("Dikkat!", payment.ErrorMessage , "danger");
                }
            }
            return View(orderModel);
        }

        private void SaveOrder(OrderModel orderModel, string userId, Payment payment)
        {
            var order = new Order();
            order.OrderNumber = new Random().Next(111111111, 999999999).ToString();
            order.OrderState = EnumOrderState.Completed;
            order.PaymentType = EnumPaymentType.CreditCard;
            order.PaymentId = payment.PaymentId;
            order.ConversationId = payment.ConversationId;
            order.OrderDate = new DateTime();
            order.FirstName = orderModel.FirstName;
            order.LastName = orderModel.LastName;
            order.UserId = userId;
            order.Address = orderModel.Address;
            order.City = orderModel.City;
            order.Phone = orderModel.Phone;
            order.Email = orderModel.Email;
            order.Note = orderModel.Note;

            order.OrderItems = new List<OrderItem>();
            foreach (var item in orderModel.CardModel.CardItems)
            {
                var orderItem = new OrderItem()
                {
                    Price = item.Price,
                    Quantity = item.Quantity,
                    ProductId = item.ProductId,
                };
                order.OrderItems.Add(orderItem);
            }
            _orderService.Create(order);
        }

        private Payment PaymentProcess(OrderModel orderModel)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-NBO4zCu0qTHUM2eyRvRq2eOIySD0Q2Tr";
            options.SecretKey = "sandbox-2YybrZVSlLBtAb4u2oWWHv4jyWolJaW5";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(111111111,999999999).ToString();
            request.Price = orderModel.CardModel.TotalPrice().ToString();
            request.PaidPrice = orderModel.CardModel.TotalPrice().ToString();
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard(); //ödeme yapacak kişinin kart bilgileri
            paymentCard.CardHolderName = orderModel.CardName;
            if (Luhnalgorithm(orderModel.CardNumber))
            {
                paymentCard.CardNumber = orderModel.CardNumber;
            }
            //paymentCard.CardNumber = orderModel.CardNumber;
            paymentCard.ExpireMonth = orderModel.ExpirationMonth;
            paymentCard.ExpireYear = orderModel.ExpirationYear;
            paymentCard.Cvc = orderModel.Cvc;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer(); //ödeme yapacak kişinin bilgileri 
            buyer.Id = "BY789";
            buyer.Name = orderModel.FirstName;
            buyer.Surname = orderModel.LastName;
            buyer.GsmNumber = orderModel.Phone;
            buyer.Email = orderModel.Email;
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = orderModel.Address;
            buyer.Ip = "85.34.78.112";
            buyer.City = orderModel.City;
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Mikail ayan";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            foreach (var item in orderModel.CardModel.CardItems)
            {
                BasketItem BasketItem = new BasketItem();
                BasketItem.Id = item.ProductId.ToString();
                BasketItem.Name = item.Name;
                BasketItem.Category1 = "General";
                BasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                BasketItem.Price = (item.Quantity*item.Price).ToString();
                basketItems.Add(BasketItem);
            }
            request.BasketItems = basketItems;

            return Payment.Create(request, options);
        }

        string Kartno = "6242342342423424";
        public bool Luhnalgorithm(string Kartno)
        {
            int toplam = 0;
            if (Kartno.Length % 2 ==0)
            {
                for (int i = 0; i < Kartno.Length; i += 2)
                {
                    int carpım = Convert.ToInt32(Kartno[i].ToString()) * 2;
                    if (carpım >=10)
                    {
                        string buyuk = Convert.ToString(carpım);
                        toplam = toplam + Convert.ToInt32(buyuk[0].ToString());
                        toplam = toplam + Convert.ToInt32(buyuk[1].ToString());

                    }
                    else
                    {
                        toplam = toplam + carpım;
                    }
                }
                for (int i = 1; i < Kartno.Length; i+=2)
                {
                    toplam = toplam + Convert.ToInt32(Kartno[i].ToString());
                }
                if (toplam % 10 ==0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
