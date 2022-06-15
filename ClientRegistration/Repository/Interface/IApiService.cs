using ClientRegistration.Contract.ServiceContract;

namespace ClientRegistration.Repository.Interface
{
    public interface IApiService
    {
        Task<ResponseModel> MakeCssRequest();
    }
}
