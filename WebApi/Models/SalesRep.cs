using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class SalesRep
    {
        [Key]
        public int SR_ID { get; set; }
        public string SR_Code { get; set; }
        public string SR_Description { get; set; }
        public string SR_Alt_Description { get; set; }
        public string? Default_Org_Grp { get; set; }
    }
}
