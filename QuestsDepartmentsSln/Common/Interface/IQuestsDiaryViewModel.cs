using Common.VmClasses;
using Simplified;
using System;
using System.Collections.ObjectModel;

namespace Common.Interfaces
{
    /// <summary>Интерфейс Модели дневника заданий.</summary>
    public interface IQuestsDiaryViewModel
    {
        /// <summary>Список заданий на выбранный день.</summary>
        ObservableCollection<QuestsRowVM> QuestsRows { get; }

        /// <summary>Выбранный день.</summary>
        DateTime SelectedDate { get; }

        /// <summary>Выбрать следующий день</summary>
        RelayCommand NextDateCommand { get; }

        /// <summary>Выбрать предыдущий день.</summary>
        RelayCommand PreviousDateCommand { get; }
    }
}
