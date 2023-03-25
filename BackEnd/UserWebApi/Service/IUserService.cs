using CourseApplicationWithWebApi.Model;

namespace CourseApplicationWithWebApi.Service
{
    public interface IUserService
    {
        bool AddUser(User user);
        bool Delete(int id);
        bool EditUser(int id, User user);
        List<User> GetAllUsers();
        User GetUserById(int id);
        User Login(UserLogin userLogin);
    }
}
