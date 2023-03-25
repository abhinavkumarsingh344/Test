using BookingApi.Migrations;
using BookingApi.Model;
using BookingApi.Repository;

namespace BookingApi.Service
{
    public class CartService : ICartService
    {
        readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public bool AddCart(CartModel cartt)
        {
            _cartRepository.AddCart(cartt);
            return true;

        }

        public void DecreaseQuantity(int id)
        {
            _cartRepository.DecreaseQuantity(id);
        }

        public bool DleteFromCart(int id)
        {
            bool deletestatus = _cartRepository.DeleteFromCart(id);
            return true;

        }

        public CartModel FindFromcart(int id1, int id2)
        {
            return _cartRepository.FindFromcart(id1, id2);
        }

        public User FindUser(string name)
        {
            return _cartRepository.GetUserByName(name);
        }

      

        public void IncreaseQuantity(int cartId)
        {
            _cartRepository.IncreaseQuantity(cartId); 
        }
    }
}
