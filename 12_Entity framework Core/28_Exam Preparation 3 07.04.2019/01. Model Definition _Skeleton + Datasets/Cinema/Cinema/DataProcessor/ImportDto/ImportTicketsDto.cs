using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Ticket")]
    public  class ImportTicketsDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ProjectionId { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}
