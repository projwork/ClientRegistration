using ClientRegistration.Contract.DataContract;

namespace ClientRegistration.Repository.Interface
{
    public interface IUserRepository
    {
        UserResponseModel GetUser(int Id);
        void AddUser(UserResponseModel result);
        UserResponseModel GetUserForRegistration(int Id);
    }
}
