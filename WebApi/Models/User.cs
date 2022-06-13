using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public record User
    {
        [Required]
        public int UserID { get; set; }
        public string? fullname { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public string? MenuID { get; set; }
        public bool IsActive { get; set; }
        //public string Language { get; set; }
        //public string FTPServerAddress { get; set; }
        //public string FTPServerFolder { get; set; }
        //public string FTPUserName { get; set; }
        //public string FTPPassword { get; set; }
        //public string ScanReader { get; set; }
        //public DateTimeOffset LastLogin { get; set; }
        //public string VersionNo { get; set; }
        //public string HostName { get; set; }
        //public string IPAddress { get; set; }
        //public string UserWindows { get; set; }
        //public int Trx_ID { get; set; }
        //public string FIX_GPS_Level { get; set; }
        //public int New_Customer_Approval_Level { get; set; }

    }
}
