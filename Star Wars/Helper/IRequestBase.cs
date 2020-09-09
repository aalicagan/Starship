namespace Star_Wars.Helper
{
    public interface IRequestBase<T>
    {
        public T CallApi(string url);
    }
}
