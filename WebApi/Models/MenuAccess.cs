using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public record MenuAccess
    {
        public string NodeID { get; set; }
        public int MenuID { get; set; }
        public int CompNo { get; set; }

    }
}
