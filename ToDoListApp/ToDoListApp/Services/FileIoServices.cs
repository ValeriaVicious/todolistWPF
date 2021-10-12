using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;
using ToDoListApp.Models;


namespace ToDoListApp.Services
{
    internal sealed class FileIoServices
    {
        #region Fields

        private readonly string _path;

        #endregion


        #region ClassLifeCycles

        public FileIoServices(string path)
        {
            _path = path;
        }

        #endregion


        #region Methods

        public BindingList<ToDoModel> ToDoModelsData()
        {
            return null;
        }

        public void SaveData(object toDoDataList)
        {
            using (StreamWriter writer = File.CreateText(_path))
            {
                var output = JsonConvert.SerializeObject(toDoDataList);
                writer.Write((output));
            }
        }

        public  BindingList<ToDoModel> LoadData()
        {
            var fileExists = File.Exists(_path);
            if (!fileExists)
            {
                File.CreateText(_path).Dispose();
                return new BindingList<ToDoModel>();
            }

            using (var reader = File.OpenText(_path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(fileText);
            }
        }

        #endregion
    }
}
