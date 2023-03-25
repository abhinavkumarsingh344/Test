using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CourseApplicationWithWebApi.Model;
using CourseApplicationWithWebApi.Service;

namespace WebApplicationWithApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        readonly IUserService _userservice;
        readonly ITokenGenerator _tokenGenerator;

        public UserController(IUserService userservice, ITokenGenerator tokenGenerator)
        {
            _userservice = userservice;
            _tokenGenerator = tokenGenerator;

        }
        [Route("GetAllUsers")]
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            List<User> allUser = _userservice.GetAllUsers();
            return Ok(allUser);
        }
        [Route("RegisterUser")]
        [HttpPost]
        public ActionResult RegisterUser(User user)
        {

            bool addUserStatus = _userservice.AddUser(user);
            return Created("api/created", addUserStatus);
        }
        [Route("delete")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _userservice.Delete(id);
            return Ok();
        }
        [Route("Login")]
        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
           
                User user = _userservice.Login(userLogin);
               string userToken= _tokenGenerator.GenerateToken(user.Id, user.Name);

              
               return Ok(userToken);
        }
        [Route("GetUserById/{id:int}")]
        [HttpGet]
        public ActionResult GetUserbyId(int id)
        {
            User user = _userservice.GetUserById(id);
            return Ok(user);
        }
        [HttpPut]
        [Route("EditUser/{id:int}")]
        public ActionResult EditUser(int id,User user)
        {
            bool editUserStatus = _userservice.EditUser(id, user);
            return Ok(editUserStatus);
        }
    }
}
