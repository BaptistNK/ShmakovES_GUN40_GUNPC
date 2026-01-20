using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoGame.Data
{
    public interface ISaveLoadService<T>
    {
        void SaveData(T data, string ID);
        void LoadData<T>(string ID);
    }
}
