using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Domain.Enitities;
using TestWithValue.Domain.ViewModels.CartItem;

namespace TestWithValue.Application.Services.Services_Interface
{
    public interface ICartItemService
    {
        Task AddToCart(CartItemViewModel cartItemViewModel);
        Task RemoveFromCart(int cartItemId);
        Task<IEnumerable<CartItemViewModel>> GetCartItemsByUserId(int userId);


    }
}
