using BookingApi.Model;

namespace BookingApi.Repository
{
    public interface ICartRepository
    {
        bool AddCart(CartModel cartt);
        CartModel FindFromcart(int id1, int id2);
        void AddToCart(int id);
        User GetUserByName(string name);
        void IncreaseQuantity(int cartId);
        bool DeleteFromCart(int id);
        void DecreaseQuantity(int id);
    }
}
