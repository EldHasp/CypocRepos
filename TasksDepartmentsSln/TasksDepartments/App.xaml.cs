using System.Windows;
using TasksDepartments.Xml;

namespace TasksDepartments
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            XmlTest.Start();
        }
    }
}
