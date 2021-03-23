using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace TasksDepartments.Xml
{

    /// <remarks/>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "TasksDepartments")]
    public partial class TasksDepartmentsXml
    {


        /// <remarks/>
        [XmlArrayItem("Deparеment", IsNullable = false)]
        public List<DeparеmentXml> Departments { get; set; }

        /// <remarks/>
        [XmlArrayItem("TasksDay", IsNullable = false)]
        public List<TasksDayXml> Tasks { get; set; }
    }

    /// <remarks/>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class DeparеmentXml
    {

        /// <remarks/>
        [XmlAttribute()]
        public int Id { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string Title { get; set; }
    }

    /// <remarks/>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class TasksDayXml
    {

        /// <remarks/>
        [XmlAttribute()]
        public int Id { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int DepartmentId { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public DateTime Date { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int InProgress { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int Completed { get; set; }
    }


}
