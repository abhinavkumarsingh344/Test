using BookingApi.Model;
using BookingApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;

        }

        [HttpPost]
        [Route("AddToCart")]
        public ActionResult AddToCart(int id)
        {
           
            User user = new User();
            CartModel alreadypresent = _cartService.FindFromcart(user.Id, id);
            if (alreadypresent != null)
            {
                _cartService.IncreaseQuantity(alreadypresent.CartId);

                return Ok();
            }
            else
            {
                CartModel cartt = new CartModel()
                {
                    CourseId = id,
                    Id = user.Id,
                    DateCreated = System.DateTime.Now,
                    Quantity = 1
                };
                bool status = _cartService.AddCart(cartt);
                if (status)
                {

                    return Ok();
                }

            }
            return Ok();


        }
        [Route("DecreaseQuantity")]
        [HttpPost]
        public ActionResult DecreaseQuantity(int id)
        {
            _cartService.DecreaseQuantity(id);
            return Ok();

        }
        [Route("DeleteFromCart")]
        [HttpDelete]
        public ActionResult DleteFromCart(int id)
        {
            _cartService.DleteFromCart(id);
            return Ok();
        }
        [Route("IncreaseQuantity")]
        [HttpPost]
        public ActionResult IncreaseQuantity(int id)
        {
            _cartService.IncreaseQuantity(id);
            return Ok();
        }


    }





}

