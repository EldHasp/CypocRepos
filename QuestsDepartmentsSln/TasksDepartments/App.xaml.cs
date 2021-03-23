using RepositoryXml;
using System.Windows;

namespace Model
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
           new QuestsDiaryModel().DemoStart();
        }
    }
}
