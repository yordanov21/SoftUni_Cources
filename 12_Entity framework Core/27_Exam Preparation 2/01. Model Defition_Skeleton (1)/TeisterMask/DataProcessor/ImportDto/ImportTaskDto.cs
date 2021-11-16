namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Task")]
    public class ImportTaskDto
    {
        //this is inner DTO (task Dto)

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [Required]
        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        //required by default
        [Range(0,3)]  //range of enum
        [XmlElement("ExecutionType")]
        public int ExecutionType { get; set; }

        //required by default
        [Range(0, 4)]  //range of enum
        [XmlElement("LabelType")]
        public int LabelType { get; set; }
    }
}

