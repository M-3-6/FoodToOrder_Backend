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
            modelBuilder.Entity<User>()
                    .HasOne(u => u.address)
                    .WithOne(a => a.User)
                    .HasForeignKey<Address>(a => a.user_id);

            modelBuilder.Entity<Dish>()
                .HasOne<Restaurant>(d => d.Restaurant)
                .WithMany(r => r.dishes)
                .HasForeignKey(d => d.restaurant_id);

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
