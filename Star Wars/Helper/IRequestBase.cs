using System.Threading.Tasks;

namespace Star_Wars.Helper
{
    public interface IRequestBase<T>
    {
        public Task<T> CallApiAsync(string url);
    }
}
