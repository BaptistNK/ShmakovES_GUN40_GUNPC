using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoGame.Data
{
    public interface ISaveLoadService<T>
    {
        void SaveData<T>(T data, string identifier)
        {

        }

        T LoadData(string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
            {
                throw new ArgumentException(
                    "Идентификатор не может быть пустой строкой",
                    nameof(identifier));
            }
            lock
            return data;
        }
    }
}
