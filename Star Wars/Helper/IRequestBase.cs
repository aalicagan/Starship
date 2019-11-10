using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Wars.Helper
{
    public interface IRequestBase<T>
    {
        public T CallApi(string url);
    }
}
