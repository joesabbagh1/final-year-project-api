using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    [Keyless]
    public record MenuAccess
    {
        public string NodeID { get; set; }
        public int MenuID { get; set; }
        public int CompNo { get; set; }

    }
}
