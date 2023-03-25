using CourseApplicationWithWebApi.Context;
using CourseApplicationWithWebApi.Model;

namespace CourseApplicationWithWebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        UserDbContext _userDbContext;
        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public void AddUser(User user)
        {
            _userDbContext.Users.Add(user);
            _userDbContext.SaveChanges();


        }

        public bool Delete(int id)
        {
            _userDbContext.Users.Remove(GetUserById(id));
            return _userDbContext.SaveChanges() == 1 ? false : true;

        }

        public int EditUser(User user)
        {
         
            _userDbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
       return _userDbContext.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _userDbContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _userDbContext.Users.Where(p => p.Id == id).FirstOrDefault();
        }

        public User GetUserByName(string name)
        {
            return _userDbContext.Users.Where(u => u.Name == name).FirstOrDefault();
        }
        public User Login(UserLogin userLogin)
        {
            return _userDbContext.Users.Where(u => u.Name == userLogin.Name && u.Password == userLogin.Password).FirstOrDefault();
        }

    }
}
