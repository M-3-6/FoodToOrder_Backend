using FoodToOrder_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrder_Backend.Repositories
{
    public class CartRepository : ICartRepository
    {
       
        private readonly FoodToOrderAppContext _Context;

        public CartRepository(FoodToOrderAppContext context)
        {
            _Context = context;
        }

        public IEnumerable<Cart> GetCarts()
        {
            return _Context.Carts.Include(c=>c.cartDishes).ThenInclude(cd=>cd.Dish).ToList();
        }

        public Cart GetCartById(int id)
        {
           return _Context.Carts.Include(c=>c.cartDishes).ThenInclude(cd => cd.Dish).Where(c=>c.id==id).First();
        }

        public Cart AddCart(Cart cart)
        {
            _Context.Carts.Add(cart);
            _Context.SaveChanges();
            return cart;
        }


        public Cart UpdateCart(Cart cart)
        {
            _Context.Carts.Update(cart);
            _Context.SaveChanges();
            return cart;
        }

        public Cart DeleteCart(int id)
        {
            var cartToBeDeleted = _Context.Carts.Where(c=>c.id==id).FirstOrDefault();
            _Context.Carts.Remove(cartToBeDeleted);
            _Context.SaveChanges();
            return cartToBeDeleted;
        }
    }
}
