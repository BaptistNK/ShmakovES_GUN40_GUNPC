using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoGame.Data
{
    public class FileSystemSaveLoadService : ISaveLoadService<string>
    {
        private readonly string _path;
        public FileSystemSaveLoadService(string path) 
        {
            if(string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Directory path cannot be empty.", nameof(path));
            }
            _path = path;
            if((!Directory.Exists(path)))
            {
                Directory.CreateDirectory(path);
            }
        }

        private string GetFilePath(string ID)
        {
            string sanitizeIdentifier = ID.Replace("/","_")
                                                      .Replace("\\", "_")
                                                      .Replace(":", "_")
                                                      .Replace("*", "_")
                                                      .Replace("?", "_")
                                                      .Replace("\"", "_")
                                                      .Replace("<", "_")
                                                      .Replace(">", "_")
                                                      .Replace("|", "_");
            return Path.Combine(_path, sanitizeIdentifier + ".txt");
        }

        public string LoadData<T>(string ID)
        {
            if ((string.IsNullOrWhiteSpace(ID)))
            {
                throw new ArgumentException("The ID cannot be empty.", nameof(ID));
            }
            string filePath = GetFilePath(ID);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                throw new IOException($"Couldn't download data from the file {filePath}. Error: {ex.Message}");
            }
        }

        public void SaveData(string data, string ID)
        {
            if (string.IsNullOrWhiteSpace(ID))
            {
                throw new ArgumentException("The ID cannot be empty.", nameof(ID));
            }
            string filePath = GetFilePath(ID);
            try
            {
                File.WriteAllText(filePath, data);
            }
            catch (Exception ex) 
            {
                throw new IOException($"Couldn't save data to file {filePath}. Error: {ex.Message}");
            }
        }

        void ISaveLoadService<string>.LoadData<T>(string ID)
        {
            throw new NotImplementedException();
        }
    }
}
