using Star_Wars.DTO;
using System.Threading.Tasks;

namespace Star_Wars.Services
{
    public interface IService
    {
        public Task<ResponseDTO> GetDataAsync(string url);
    }
}
