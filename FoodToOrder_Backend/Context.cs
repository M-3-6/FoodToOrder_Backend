using FoodToOrder_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrder_Backend
{
    public class FoodToOrderAppContext : DbContext
    {
        public FoodToOrderAppContext()
        {

        }

        public FoodToOrderAppContext(DbContextOptions<FoodToOrderAppContext> options)
       : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=TJ16AA044-PC,49955;Initial Catalog=FoodToOrder_Maria_Prajith;User=sa;Password=sa@1234;TrustServerCertificate=True;MultipleActiveResultSets=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // user-address : one to one
            modelBuilder.Entity<User>()
                    .HasOne(u => u.address)
                    .WithOne(a => a.User)
                    .HasForeignKey<Address>(a => a.user_id);

            // user-cart : one to one
            modelBuilder.Entity<User>()
                    .HasOne(u => u.cart)
                    .WithOne(c => c.User)
                    .HasForeignKey<Cart>(c => c.user_id);

            // address-restaurant : one to many
            modelBuilder.Entity<Address>()
                    .HasOne<Restaurant>(a => a.Restaurant)
                    .WithMany(r => r.arrAddresses)
                    .HasForeignKey(a => a.restaurant_id);

            // restaurant-dishes : one to many
            modelBuilder.Entity<Dish>()
                    .HasOne<Restaurant>(d => d.Restaurant)
                    .WithMany(r => r.dishes)
                    .HasForeignKey(d => d.restaurant_id);

            // user-order : one to many
            modelBuilder.Entity<Order>()
                    .HasOne<User>(o => o.User)
                    .WithMany(u => u.orders)
                    .HasForeignKey(o => o.user_id);

            // order-dishes : many to many
            modelBuilder.Entity<DishOrder>()
                    .HasKey(od => new { od.DishId, od.OrderId});

            modelBuilder.Entity<DishOrder>()
                    .HasOne<Dish>(od => od.Dish)
                    .WithMany(d => d.dishOrders)
                    .HasForeignKey(od => od.DishId);

            modelBuilder.Entity<DishOrder>()
                    .HasOne<Order>(od => od.Order)
                    .WithMany(d => d.dishOrders)
                    .HasForeignKey(od => od.OrderId);
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<DishOrder> DishOrders { get; set; }
        public DbSet<CartDish> CartDishes { get; set; }
    }
}
