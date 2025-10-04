using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace to_do
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            var mainWindow = Current?.MainWindow as MainWindow;
            if (mainWindow == null)
            {
                return;
            }

            var dataContext = mainWindow.DataContext as Todos;
            if (dataContext != null)
            {
                dataContext.Save();
            }
        }
    }
}
