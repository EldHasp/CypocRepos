using Common;
using Common.DtoTypes;
using Common.Interfaces;
using Model.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace RepositoryXml
{
    public class QuestsDiaryModel : IQuestsDiaryModel
    {
        public IEnumerable<QuestsDepartamentForDayDto> GetDailyQuests(DateTime date)
        {
            date = date.Date;
            return diary.Quests
                .Where(q => q.Date == date)
                .Where(q => departaments.ContainsKey(q.DepartmentId))
                .Select(q => new QuestsDepartamentForDayDto(q.Id, q.Date, departaments[q.DepartmentId], q.Completed, q.InProgress));
        }

        public IEnumerable<DepartamentDto> GetDepartaments()
            => departaments.Values.GetEnumerable();

        private readonly string xmlFolder;
        private readonly string xmlFile;
        private readonly string xmlFileFullName;
        private static readonly XmlSerializer serializer = new XmlSerializer(typeof(QuestsDiaryXml));

        public QuestsDiaryModel(string xmlFolder, string xmlFile)
        {
            this.xmlFolder = xmlFolder;
            this.xmlFile = xmlFile;
            DirectoryInfo directory = new DirectoryInfo(xmlFolder);
            if (!directory.Exists)
                directory.Create();
            xmlFileFullName = Path.Combine(xmlFolder, xmlFile);
        }


        public QuestsDiaryModel()
            : this("Xml", "QuestsDiary.xml")
        { }

        private QuestsDiaryXml diary;
        private readonly Dictionary<int, DepartamentDto> departaments = new Dictionary<int, DepartamentDto>();

        public void Load()
        {
            try
            {
                using (var file = File.OpenRead(xmlFileFullName))
                    diary = (QuestsDiaryXml)serializer.Deserialize(file);

            }
            catch (Exception)
            {

                diary = new QuestsDiaryXml()
                {
                    Departments = new List<DeparеmentXml>(),
                    Quests = new List<QuestsDayXml>()
                };
            }

            departaments.Clear();
            foreach (DeparеmentXml deparеment in diary.Departments)
            {
                departaments.Add(deparеment.Id, new DepartamentDto(deparеment.Id, deparеment.Title));
            }
        }

        public void Save()
        {
            diary.Quests.RemoveAll(q => q.Completed == 0 && q.InProgress == 0);
            using (var file = File.Create(xmlFileFullName))
                serializer.Serialize(file, diary);
        }
        public void DemoStart()
        {

            DirectoryInfo directory = new DirectoryInfo(xmlFolder);
            if (!directory.Exists)
                directory.Create();
            string fullName = Path.Combine(xmlFolder, xmlFile);

            QuestsDiaryXml diary = new QuestsDiaryXml()
            {
                Departments = new List<DeparеmentXml>()
                {
                    new DeparеmentXml() { Id=1234, Title="Первый отдел"},
                    new DeparеmentXml() { Id=5678, Title="Второй отдел"}
                },

                Quests = new List<QuestsDayXml>()
                {
                    new QuestsDayXml() { Id=12, DepartmentId=1234, Date= new DateTime(2021, 1, 15), Completed=23, InProgress = 45},
                    new QuestsDayXml() { Id=34, DepartmentId=1234, Date= new DateTime(2021, 1, 27), Completed=3, InProgress = 5},
                    new QuestsDayXml() { Id=56, DepartmentId=5678, Date= new DateTime(2021, 1, 15), Completed=11, InProgress = 12},
                    new QuestsDayXml() { Id=78, DepartmentId=5678, Date= new DateTime(2021, 1, 27), Completed=9, InProgress = 8},
                }
            };

            using (var file = File.Create(fullName))
                serializer.Serialize(file, diary);

            QuestsDiaryXml diaryLoad;
            using (var file = File.OpenRead(fullName))
                diaryLoad = (QuestsDiaryXml)serializer.Deserialize(file);

        }// Здесь точка останова и проверка скачанных данных


        public void ChangeDailyQuests(IEnumerable<QuestsDepartamentForDayDto> questsDepartaments)
        {
            foreach (var questsDepartament in questsDepartaments)
            {
                int index = diary.Quests.FindIndex(q => q.Date == questsDepartament.Date && q.DepartmentId == questsDepartament.Departament.Id);
                if (index >= 0)
                {
                    QuestsDayXml questsDiary = diary.Quests[index];
                    questsDiary.Completed = questsDepartament.Completed;
                    questsDiary.InProgress = questsDepartament.InProgress;
                }
                else
                {
                    if (questsDepartament.Completed == 0 && questsDepartament.InProgress == 0)
                        continue;

                    diary.Quests.Add(new QuestsDayXml
                    {
                        Id = GetNewDailyQuestsId(),
                        Date = questsDepartament.Date,
                        DepartmentId = questsDepartament.Departament.Id,
                        Completed = questsDepartament.Completed,
                        InProgress = questsDepartament.InProgress
                    });
                }

            }
        }

        private static Random random = new Random();
        private int GetNewDailyQuestsId()
        {
            int id;
            do
            {
                id = random.Next(int.MaxValue) + 1;
            } while (diary.Quests.Any(q => q.Id == id));
            return id;
        }

    }
}
