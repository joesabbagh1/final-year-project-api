using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    [Keyless]
    public class VariableDetails
    {
        public int CompNo { get; set; }
        public string VariableCode { get; set; }
        public string SubVariableCode { get; set; }
        public string Description { get; set; }

    }
}
