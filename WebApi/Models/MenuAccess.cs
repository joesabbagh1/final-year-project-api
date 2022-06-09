using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    [Keyless]
    public class MenuAccess
    {
        public string NodeID { get; set; }
        public int MenuID { get; set; }
        public int CompNo { get; set; }

    }
}
