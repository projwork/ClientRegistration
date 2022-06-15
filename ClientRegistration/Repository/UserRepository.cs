using ClientRegistration.Contract.DataContract;
using ClientRegistration.Repository.Interface;

namespace ClientRegistration.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly DataContext _dbContext;

        public UserRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserResponseModel GetUserForRegistration(int id)
        {
            UserResponseModel user = new UserResponseModel();
            var query = from l in _dbContext.UserInfo
                        where l.PersonalNumber == id
                        select l;
            user = query.FirstOrDefault();
            return user;
        }

        public UserResponseModel GetUser(int id)
        {
            try
            {
                UserResponseModel user = new UserResponseModel();
                user = _dbContext.UserInfo.Find(id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddUser(UserResponseModel user)
        {
            try
            {
                _dbContext.UserInfo.Add(user);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        
    }
}
