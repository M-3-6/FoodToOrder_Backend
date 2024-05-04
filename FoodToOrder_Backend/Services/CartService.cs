using FoodToOrder_Backend.Models;
using FoodToOrder_Backend.Repositories;

namespace FoodToOrder_Backend.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepo;

        public CartService(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }
        public Cart AddCart(Cart cart)
        {
            return _cartRepo.AddCart(cart);
        }

        public Cart DeleteCart(int cartId)
        {
            return _cartRepo.DeleteCart(cartId);
        }

        public Cart GetCartByUserId(int id)
        {
            return _cartRepo.GetCartByUserId(id);
        }

        public IEnumerable<Cart> GetCarts()
        {
            return _cartRepo.GetCarts();
        }

        public Cart UpdateCart(Cart cart)
        {
            return _cartRepo.UpdateCart(cart);
        }
    }
}
