using Common.DtoTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    /// <summary>Интерфейс Модели дневника заданий.</summary>
    public interface IQuestsDiaryModel
    {
        /// <summary>Запрашивает все отделы.</summary>
        /// <returns>Последователность отделов в типе <see cref="DepartamentDto"/>.</returns>
        IEnumerable<DepartamentDto> GetDepartaments();

        /// <summary>Запрашивает все задания на день.</summary>
        /// <param name="date">Дата для которой запрашиваются</param>
        /// <returns>Последователность заданий в типе <see cref="QuestsDepartamentForDayDto"/>.</returns>
        IEnumerable<QuestsDepartamentForDayDto> GetDailyQuests(DateTime date);

        /// <summary>Изменить задания.</summary>
        /// <param name=""></param>
        void ChangeDailyQuests(IEnumerable<QuestsDepartamentForDayDto> questsDepartaments);
    }
}
