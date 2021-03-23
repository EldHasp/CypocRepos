using Common.DtoTypes;
using Simplified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.VmClasses
{
    public class QuestsRowVM : BaseInpc
    {
        private QuestsDepartamentForDayDto _dto;
        private int _completed;
        private int _inProgress;
        private int _total;

        public QuestsDepartamentForDayDto Dto { get => _dto; private set => Set(ref _dto, value); }
        public DepartamentDto Departament { get; }
        public int Completed { get => _completed; set => Set(ref _completed, value); }
        public int InProgress { get => _inProgress; set => Set(ref _inProgress, value); }
        public int Total { get => _total; private set => Set(ref _total, value); }

        public QuestsRowVM(DepartamentDto departament)
        {
            Departament = departament;
        }

        protected override void OnPropertyChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnPropertyChanged(propertyName, oldValue, newValue);
            if (propertyName == nameof(Completed) || propertyName == nameof(InProgress))
                Total = Completed + InProgress;
        }

        public void SetDto(QuestsDepartamentForDayDto dto)
        {
            if (dto == null)
            {
                Completed = InProgress = 0;
                return;
            }
            if (Departament != dto.Departament)
                throw new ArgumentException("Это данные не для этой строки", nameof(dto));

            Completed = dto.Completed;
            InProgress = dto.InProgress;
            Dto = dto;
        }

        public QuestsDepartamentForDayDto GetDto(DateTime date)
        {
            if (Completed == Dto?.Completed && InProgress == Dto?.InProgress)
                return Dto;
            return new QuestsDepartamentForDayDto
            (
                Dto?.Id ?? 0,
                date,
                Departament,
                Completed,
                InProgress
            );
        }
    }
}
