using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Model.Xml
{

    /// <remarks/>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "QuestsDiary")]
    public partial class QuestsDiaryXml
    {


        /// <remarks/>
        [XmlArrayItem("Deparеment", IsNullable = false)]
        public List<DeparеmentXml> Departments { get; set; }

        /// <remarks/>
        [XmlArrayItem("QuestsDay", IsNullable = false)]
        public List<QuestsDayXml> Quests { get; set; }

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
    public class QuestsDayXml
    {
        private DateTime _date;

        /// <remarks/>
        [XmlAttribute()]
        public int Id { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int DepartmentId { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "date")]
        public DateTime Date { get => _date; set => _date = value.Date; }

        /// <remarks/>
        [XmlAttribute()]
        public int InProgress { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public int Completed { get; set; }
    }


}
