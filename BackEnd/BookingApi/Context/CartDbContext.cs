using BookingApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookingApi.Context
{
    public class CartDbContext : DbContext
    {
        public CartDbContext(DbContextOptions<CartDbContext> Context) : base(Context)
        {

        }
        public DbSet<CartModel> Cartes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
