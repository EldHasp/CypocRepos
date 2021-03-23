using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TasksDepartments.Xml
{
    public static class XmlTest
    {
        static string xmlFolder = "Xml";
        static string xmlFile = "TasksDepartments.xml";
        static XmlSerializer serializer = new XmlSerializer(typeof(TasksDepartmentsXml));
        public static void Start()
        {

            DirectoryInfo directory = new DirectoryInfo(xmlFolder);
            if (!directory.Exists)
                directory.Create();
            string fullName = Path.Combine(xmlFolder, xmlFile);

            TasksDepartmentsXml tasksDepartments = new TasksDepartmentsXml()
            {
                Departments = new List<DeparеmentXml>()
                {
                    new DeparеmentXml() { Id=1234, Title="Первый отдел"},
                    new DeparеmentXml() { Id=5678, Title="Второй отдел"}
                },

                Tasks = new List<TasksDayXml>()
                {
                    new TasksDayXml() { Id=12, DepartmentId=1234, Date= new DateTime(2021, 1, 15), Completed=23, InProgress = 45},
                    new TasksDayXml() { Id=34, DepartmentId=1234, Date= new DateTime(2021, 1, 27), Completed=3, InProgress = 5},
                    new TasksDayXml() { Id=56, DepartmentId=5678, Date= new DateTime(2021, 1, 15), Completed=11, InProgress = 12},
                    new TasksDayXml() { Id=78, DepartmentId=5678, Date= new DateTime(2021, 1, 27), Completed=9, InProgress = 8},
                }
            };

            using (var file = File.Create(fullName))
                serializer.Serialize(file, tasksDepartments);

            TasksDepartmentsXml tasksDepartmentsLoad;
            using (var file = File.OpenRead(fullName))
              tasksDepartmentsLoad = (TasksDepartmentsXml)  serializer.Deserialize(file);

        }// Здесь точка останова и проверка скачанных данных
    }
}
