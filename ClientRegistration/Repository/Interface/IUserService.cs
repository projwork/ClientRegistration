using ClientRegistration.Contract.DataContract;
using ClientRegistration.Contract.ServiceContract;

namespace ClientRegistration.Repository.Interface
{
    public interface IUserService
    {
        Task<UserResponseModel> SaveUser();
        UserResponseModel GetUserDetailsById(int userId);
        bool Register(RegisterModel model);
    }
}
