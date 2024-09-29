using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestWithValue.Application.Services.Services_Interface;
using TestWithValue.Domain.ViewModels.CartItem;
using TestWithValue.Domain.ViewModels.Topic;

namespace TestWithValue.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartItemService _cartItemService;
        private readonly IMapper _mapper;


        public CartController(ICartItemService cartItemService,IMapper mapper)
        {
            _cartItemService = cartItemService;
            _mapper = mapper;
                
        }
        public IActionResult Index()
        {
            return View();
        }
        // افزودن به سبد خرید
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] AddRequestVM addRequest)
        {
            var userId = 1; // در واقع این باید از لاگین کاربر گرفته شود
            var cartItemVM = new CartItemViewModel()
            {
                TopicId = addRequest.TopicId,
                UserId = userId
            };
            await _cartItemService.AddToCart(cartItemVM);
            return RedirectToAction("ShowCart");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            await _cartItemService.RemoveFromCart(cartItemId);
            return RedirectToAction("ShowCart");
        }
        public async Task<IActionResult> ShowCart()
        {
            var userId = 1; // در واقع این باید از لاگین کاربر گرفته شود
            var cartItems = await _cartItemService.GetCartItemsByUserId(userId);
            var cartItemVMs = cartItems.Select(item => new CartItemViewModel
            {
                CartItemId = item.CartItemId,
                     TopicId=item.TopicId ,
                TopicName = item.Topic.TopicName,

                
            }).ToList();
            return View(cartItemVMs);
        }


    }
}
