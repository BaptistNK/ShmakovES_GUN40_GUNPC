namespace CasinoGame.Data
{
    public interface ISaveLoadService<T>
    {
        void SaveData(T data, string ID);
        void LoadData<T>(string ID);
    }
}
