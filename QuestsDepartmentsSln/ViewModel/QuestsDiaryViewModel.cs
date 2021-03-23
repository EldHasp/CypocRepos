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
            NextDateCommand = new RelayCommand(() => SelectedDate = SelectedDate.AddDays(1).Date);
            PreviousDateCommand = new RelayCommand(() => SelectedDate = SelectedDate.AddDays(-1).Date);

            foreach (DepartamentDto departament in model.GetDepartaments())
            {
                QuestsRows.Add(new QuestsRowVM(departament));
            }
            SelectedDate = DateTime.Now.Date;
        }

        protected override void OnPropertyChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnPropertyChanged(propertyName, oldValue, newValue);
            if (propertyName == nameof(SelectedDate))
            {
                var oldDate = (DateTime)oldValue;
                var newDate = (DateTime)newValue;
                model.ChangeDailyQuests(QuestsRows.Select(row => row.GetDto(oldDate)));
                var newQuests = model.GetDailyQuests(newDate).ToDictionary(q => q.Departament);
                foreach (QuestsRowVM row in QuestsRows)
                {
                    if (!newQuests.TryGetValue(row.Departament, out QuestsDepartamentForDayDto dto))
                        dto = null;
                    
                    row.SetDto(dto);
                }
            }
        }
    }
}
