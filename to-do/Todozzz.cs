using System.Collections.ObjectModel;
using System.ComponentModel;

namespace to_do
{
    public class Todos : INotifyPropertyChanged
    {
        public Todos() 
        { 
            _allTodos = new ObservableCollection<Todo>()
            {
                new Todo() {Desc = "Удалить после того как скатаю с гопоты"}
            };
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
    }
}
