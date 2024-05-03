using FoodToOrder_Backend.Models;

namespace FoodToOrder_Backend.Services
{
    public interface ICartService
    {
        IEnumerable<Cart> GetCarts();

        Cart GetCartById(int id);

        Cart AddCart(Cart cart);

        Cart UpdateCart(Cart cart);

        Cart DeleteCart(int id);


    }
}
