using RepositoryXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        Locator locator;
        QuestsDiaryModel model;
        QuestsDiaryViewModel viewModel;
        private void OnStartup(object sender, StartupEventArgs e)
        {
            locator = (Locator)Resources["locator"];

            model = new QuestsDiaryModel();
            model.Load();
            viewModel = new QuestsDiaryViewModel(model);
            locator.ViewModel = viewModel;
        }

        private void OnExit(object sender, ExitEventArgs e)
        {
            viewModel.NextDateCommand.Execute(null);
            model.Save();
        }
    }
}
