using System;

namespace Common.DtoTypes
{
    public class QuestsDepartamentForDayDto
    {
        public int Id { get; }
        public DateTime Date { get; }
        public DepartamentDto Departament { get; }
        public int Completed { get; }
        public int InProgress { get; }

        public QuestsDepartamentForDayDto(int id, DateTime date, DepartamentDto departament, int completed, int inProgress)
        {
            Id = id;
            Date = date.Date;
            Departament = departament;
            if (completed < 0)
                throw new ArgumentOutOfRangeException(nameof(completed));
            Completed = completed;
            if (inProgress < 0)
                throw new ArgumentOutOfRangeException(nameof(inProgress));
            InProgress = inProgress;
        }
    }

}
