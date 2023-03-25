using BookingApi.Model;

namespace BookingApi.Service
{
    public interface ICartService
    {
        bool AddCart(CartModel cartt);
        void DecreaseQuantity(int id);
        bool DleteFromCart(int id);
        CartModel FindFromcart(int id1, int id2);
        User FindUser(string name);

        void IncreaseQuantity(int cartId);
    }
}
