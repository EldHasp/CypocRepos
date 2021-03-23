using Common.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для QuestsDiaryWindow.xaml
    /// </summary>
    public partial class QuestsDiaryWindow : Window
    {
        public QuestsDiaryWindow()
        {
            InitializeComponent();
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dgQuestsRows.CommitEdit(DataGridEditingUnit.Row, true);
            if (DataContext is IQuestsDiaryViewModel viewModel)
                viewModel.Save();
        }
    }
}
