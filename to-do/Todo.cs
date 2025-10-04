using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace to_do
{
    public class Todo
    {
        public Todo()
        {
            Desc = string.Empty; 
            Time = string.Empty;
        }
        public string Desc {  get; set; }
        public string Check { get; set; }
        public string Time { get; set; }
    }

    public class Todos : INotifyPropertyChanged
    {
        public Todos() 
        { 
            _allTodos = new ObservableCollection<Todo>();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<Todo> _allTodos;
        public ObservableCollection<Todo> AllTodos
        {
            get { return _allTodos; }
            set
            {
                _allTodos = value;
                OnPropertyChanged(nameof(AllTodos));
            }

        }

        private static string GetStorageDirectory()
        {
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "to-do");
            return dir;
        }

        private static string GetStoragePath()
        {
            return Path.Combine(GetStorageDirectory(), "todos.xml");
        }

        public void Save()
        {
            try
            {
                string dir = GetStorageDirectory();
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                string path = GetStoragePath();
                var serializer = new XmlSerializer(typeof(ObservableCollection<Todo>));
                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    serializer.Serialize(fs, _allTodos);
                }
            }
            catch
            {
                // ыыыыыыыыыыыыыыыыыыыыыыыыыыыыыыыыыы
            }
        }

        public void Load()
        {
            try
            {
                string path = GetStoragePath();
                if (!File.Exists(path))
                {
                    return;
                }

                var serializer = new XmlSerializer(typeof(ObservableCollection<Todo>));
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var loaded = serializer.Deserialize(fs) as ObservableCollection<Todo>;
                    if (loaded != null)
                    {
                        _allTodos = loaded;
                        OnPropertyChanged(nameof(AllTodos));
                    }
                }
            }
            catch
            {
                // я хз почему без этого оно не робит
            }
        }
    }
}
