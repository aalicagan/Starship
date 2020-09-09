using Star_Wars.DTO;
using Star_Wars.Helper;
using Star_Wars.Services;
using System.Threading.Tasks;

namespace Star_Wars
{
    public class StarShipService : IService
    {
        readonly IRequestBase<ResponseDTO> _requestBase;
        public StarShipService(IRequestBase<ResponseDTO> requestBase)
        {
            _requestBase = requestBase;
        }
        public async Task<ResponseDTO> GetDataAsync(string url)
        {
            return await _requestBase.CallApiAsync(url);
        }
    }
}
