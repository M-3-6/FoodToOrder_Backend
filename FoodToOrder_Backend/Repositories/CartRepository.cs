using FoodToOrder_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;

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

        public Cart GetCartByUserId(int id)
        {
           return _Context.Carts.Include(c=>c.cartDishes).ThenInclude(cd => cd.Dish).Where(c=>c.user_id==id).First();
        }

        public Cart AddCart(Cart cart)
        {
            _Context.Carts.Add(cart);
            _Context.SaveChanges();
            return cart;
        }


        //public Cart UpdateCart(Cart cart)
        //{
        //    CartDish[] tempDishes = cart.cartDishes.ToArray();
        //    var contextCart = _Context.Carts.Where(cd => cd.id == cart.id).First();
        //    _Context.Entry(contextCart).State = EntityState.Detached;
        //    _Context.Entry(contextCart).State = EntityState.Modified;



        //    contextCart.cartDishes = tempDishes;           

        //    //for below error
        //    //System.InvalidOperationException: 'The instance of entity type 'CartDish' cannot be tracked because another instance with the same key value for {'CartId', 'DishId'}
        //    //is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached.
        //    //Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the conflicting key values.'



        //    _Context.Carts.Update(contextCart);

        //    //_Context.CartDishes.Update(cart.cartDishes);

        //    _Context.SaveChanges();


        //    return cart;
        //}

        public Cart UpdateCart(Cart cart)
        {
            //  CartDish[] tempDishes = cart.cartDishes.ToArray();
            //   var contextCart = _Context.Carts.Where(cd => cd.id == cart.id).First();

            //var tempDishes = new List<CartDish>();

            //var tempCart = _Context.Carts.Where(c=>c.id==cart.id).FirstOrDefault();

            //foreach(var cd in tempCart.cartDishes)
            //{
            //    tempDishes.Add(cd);
            //}


            //var tempCart = _Context.Carts.Include(cd => cd.cartDishes).Where(c => c.id == cart.id).FirstOrDefault();

            ////_Context.Entry(tempCart).State = EntityState.Detached;
            ////_Context.Entry(tempCart).State = EntityState.Modified;

            //foreach (var cd in cart.cartDishes)
            //{
            //    if (!tempCart.cartDishes.Contains(cd))
            //    {
            //        tempCart.cartDishes.Add(cd);
            //    }
            //}

            //foreach (var cd in cart.cartDishes)
            //{
            //    if (cd.quantity == 0)
            //    {
            //        tempCart.cartDishes.Remove(cd);
            //    }
            //}

            //_Context.SaveChanges();



            //_Context.Entry(cart).State = EntityState.Detached;
            //   _Context.Entry(cart).State = EntityState.Modified;


            // contextCart.cartDishes = tempDishes;
            // _Context.CartDishes.UpdateRange(cart.cartDishes);
            var tempCart = _Context.Carts.Include(cd => cd.cartDishes).Where(c => c.id == cart.id).FirstOrDefault();

            foreach (var cdish in cart.cartDishes)
            {
                bool check = tempCart.cartDishes.Where(cd => (cd.DishId == cdish.DishId)).IsNullOrEmpty();
                if (check)
                {
                    _Context.CartDishes.Add(cdish);
                }
            }
            _Context.SaveChanges();

           _Context.Entry(cart).State = EntityState.Detached;
            _Context.Entry(tempCart).State = EntityState.Detached;
         //   _Context.Entry(cart).State = EntityState.Unchanged;
         //   _Context.Entry(tempCart).State = EntityState.Unchanged;

            foreach (var cdish in tempCart.cartDishes)
            {
                bool check = cart.cartDishes.Where(cd => (cd.DishId == cdish.DishId)).IsNullOrEmpty();
                if (check)
                {
                    _Context.CartDishes.Remove(cdish);
                }
            }
            _Context.SaveChanges();

            _Context.Entry(cart).State = EntityState.Detached;
           _Context.Entry(tempCart).State = EntityState.Detached;
        //    _Context.Entry(cart).State = EntityState.Unchanged;
       //    _Context.Entry(tempCart).State = EntityState.Unchanged;

            _Context.Carts.Update(cart);

            //  _Context.CartDishes.UpdateRange(cart.cartDishes);
            _Context.SaveChanges();



            //_Context.CartDishes.Update(cart.cartDishes);



            // _Context.Entry(cart.cartDishes).State = EntityState.Detached;

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
