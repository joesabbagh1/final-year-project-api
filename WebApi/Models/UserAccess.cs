using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class UserAccess
    {
        public string AccessType { get; set; }
        public int UserID { get; set; }
        public string AccessVariable1 { get; set; }
        public int CompNo { get; set; }
        //public string AccessVariable2 { get; set; }
        //public string AccessVariable3 { get; set; }
        //public string AccessVariable4 { get; set; }

    }
}
