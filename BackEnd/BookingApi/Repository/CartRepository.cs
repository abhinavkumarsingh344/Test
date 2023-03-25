using BookingApi.Context;
using BookingApi.Migrations;
using BookingApi.Model;
using System.Xml.Linq;

namespace BookingApi.Repository
{
    public class CartRepository : ICartRepository
    {
        CartDbContext _cartDbContext;
        //Constructor
        public CartRepository(CartDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;
        }

        public bool AddCart(CartModel cartt)
        {
            _cartDbContext.Cartes.Add(cartt);
            _cartDbContext.SaveChanges();
            return true;

        }

        public void AddToCart(int id)
        {
            CartModel cart = new CartModel();
            cart.Id = id;
            _cartDbContext.Cartes.Add(cart);
            _cartDbContext.SaveChanges();

        }

        public void DecreaseQuantity(int id)
        {
            CartModel cartobj = _cartDbContext.Cartes.Where(x => x.CartId == id).FirstOrDefault();
            if (cartobj.Quantity > 1)
            {
                cartobj.Quantity = cartobj.Quantity - 1;
            }
            _cartDbContext.Entry<CartModel>(cartobj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _cartDbContext.SaveChanges();

        }

        public bool DeleteFromCart(int id)
        {
            _cartDbContext.Cartes.Remove(_cartDbContext.Cartes.Where(x => x.CartId == id).FirstOrDefault());
            _cartDbContext.SaveChanges();
            return true;

        }

        public CartModel FindFromcart(int id1, int id2)
        {
            return _cartDbContext.Cartes.Where(x => x.Id == id1 && x.CourseId == id2).FirstOrDefault();
        }

        public User GetUserByName(string name)
        {
            return _cartDbContext.Users.Where(u => u.Name == name).FirstOrDefault();
        }

        public void IncreaseQuantity(int cartId)
        {
            CartModel cartobj = _cartDbContext.Cartes.Where(x => x.CartId == cartId).FirstOrDefault();
            cartobj.Quantity = cartobj.Quantity + 1;
            _cartDbContext.Entry<CartModel>(cartobj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _cartDbContext.SaveChanges();

        }
    }
}
