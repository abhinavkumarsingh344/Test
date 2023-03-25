using CourseApplicationWithWebApi.Model;

namespace CourseApplicationWithWebApi.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        bool Delete(int id);
        int EditUser(User user);
        List<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByName(string name);
        User Login(UserLogin userLogin);
    }
}
