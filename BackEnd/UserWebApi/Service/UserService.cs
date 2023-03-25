
using CourseApplicationWithWebApi.Model;
using CourseApplicationWithWebApi.Repository;

namespace CourseApplicationWithWebApi.Service
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AddUser(User user) { 
        var userExist = _userRepository.GetUserByName(user.Name);
            if (userExist == null)
            {
                _userRepository.AddUser(user);
                return true;
            }
            else
            {
                return false;
            }
        }

    

    public bool Delete(int id)
        {
            var UserExists = _userRepository.GetUserById(id);
            if (UserExists != null)
            {
                return _userRepository.Delete(id);
            }
            else
            {
                return false;
            }

        }

        public bool EditUser(int id, User user)
        {
            user.Id = id;
            int userEditstatus=_userRepository.EditUser(user);
            if(userEditstatus == 1) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public User Login(UserLogin userLogin)
        {
            User user = _userRepository.Login(userLogin);
            if (user != null)
            {
                return user;
            }

            return user;
            }
            
        }

    }

