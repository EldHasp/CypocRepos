using Common.DtoTypes;
using Common.Interfaces;
using Common.VmClasses;
using Simplified;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ViewModel
{
    public class QuestsDiaryViewModel : BaseInpc, IQuestsDiaryViewModel
    {
        public ObservableCollection<QuestsRowVM> QuestsRows { get; }
            = new ObservableCollection<QuestsRowVM>();
        private DateTime _selectedDate;
        public DateTime SelectedDate { get => _selectedDate; private set => Set(ref _selectedDate, value); }
        public RelayCommand NextDateCommand { get; }
        public RelayCommand PreviousDateCommand { get; }

        private readonly IQuestsDiaryModel model;

        public QuestsDiaryViewModel(IQuestsDiaryModel model)
        {
            this.model = model;
            model.Rebooted += OnRebooted;
            NextDateCommand = new RelayCommand(() => SelectedDate = SelectedDate.AddDays(1).Date);
            PreviousDateCommand = new RelayCommand(() => SelectedDate = SelectedDate.AddDays(-1).Date);

            SelectedDate = DateTime.Now.Date;
            OnRebooted();
        }

        private void OnRebooted(object sender = null, EventArgs e = null)
        {
            foreach (DepartamentDto departament in model.GetDepartaments())
            {
                QuestsRows.Add(new QuestsRowVM(departament));
            }
            Load(SelectedDate);
        }

        protected override void OnPropertyChanged(string propertyName, object oldValue, object newValue)
        {

            if (propertyName == nameof(SelectedDate))
            {
                Save((DateTime)oldValue);
                Load(SelectedDate);
            }
        }

        public void Save()
            => Save(SelectedDate);

        /// <summary>Сохранение с указанной датой.</summary>
        /// <param name="date">Дата сохраняемых заданий.</param>
        private void Save(DateTime date)
        {
            model.ChangeDailyQuests(QuestsRows.Select(row => row.GetDto(date.Date)));
        }

        /// <summary>Загрузка заданий для указанной даты.</summary>
        /// <param name="date">Дата загружаемых заданий.</param>
        private void Load(DateTime date)
        {
            var newQuests = model.GetDailyQuests(date)
                .Where(q => q.Date == date)
                .ToDictionary(q => q.Departament);

            foreach (QuestsRowVM row in QuestsRows)
            {
                if (!newQuests.TryGetValue(row.Departament, out QuestsDepartamentForDayDto dto))
                    dto = null;

                row.SetDto(dto);
            }

        }
    }
}
