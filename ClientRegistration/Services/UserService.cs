using ClientRegistration.Contract.DataContract;
using ClientRegistration.Contract.ServiceContract;
using ClientRegistration.Repository.Interface;

namespace ClientRegistration.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IApiService _apiService;

        public UserService(IUserRepository userRepository, IApiService apiService)
        {
            _userRepository = userRepository;
            _apiService = apiService;
        }

        /// <summary>
        /// get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserResponseModel GetUserDetailsById(int userId)
        {
            UserResponseModel user = new UserResponseModel();
            try
            {
                user = _userRepository.GetUser(userId);
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }


        /// <summary>
        /// save user info
        /// </summary>
        /// <returns></returns>
        public async Task<UserResponseModel> SaveUser()
        {
            ResponseModel userInfo = await _apiService.MakeCssRequest();
            UserResponseModel response = new UserResponseModel();
            response = userInfo.Result;
            try
            {
                _userRepository.AddUser(response);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        public bool Register(RegisterModel registerModel)
        {
            UserResponseModel user = new UserResponseModel();
            user = _userRepository.GetUserForRegistration(registerModel.PersonalNumber);
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}
