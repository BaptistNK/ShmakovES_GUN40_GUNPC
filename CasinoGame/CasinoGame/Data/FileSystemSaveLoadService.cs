namespace CasinoGame.Data
{
    public class FileSystemSaveLoadService : ISaveLoadService<string>
    {
        private readonly string _saveDirectory;

        public FileSystemSaveLoadService(string saveDirectory)
        {
            if (string.IsNullOrWhiteSpace(saveDirectory))
                throw new ArgumentException("Save directory cannot be null or empty", nameof(saveDirectory));

            _saveDirectory = saveDirectory;
        }

        public void SaveData(string data, string identifier)
        {
            EnsureDirectoryExists();
            string filePath = Path.Combine(_saveDirectory, $"{identifier}.txt");
            File.WriteAllText(filePath, data);
        }

        public string LoadData(string identifier)
        {
            EnsureDirectoryExists();
            string filePath = Path.Combine(_saveDirectory, $"{identifier}.txt");

            if (!File.Exists(filePath))
                return null;

            return File.ReadAllText(filePath);
        }

        private void EnsureDirectoryExists()
        {
            if (!Directory.Exists(_saveDirectory))
            {
                Directory.CreateDirectory(_saveDirectory);
            }
        }
    }
}
