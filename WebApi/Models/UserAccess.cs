using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    [Keyless]
    public class UserAccess
    {
        public string AccessType { get; set; }
        public int UserId { get; set; }
        public string AccessVariable1 { get; set; }
        //public string AccessVariable2 { get; set; }
        //public string AccessVariable3 { get; set; }
        //public string AccessVariable4 { get; set; }

    }
}
