namespace WebApi.Models
{
    public class Node
    {
        public string NodeID { get; set; }
        public int? MainNodeID1 { get; set; }
        public int? MainNodeID2 { get; set; }
        public int? MainNodeID3 { get; set; }
        public int? MainNodeID4 { get; set; }
        public int? MainNodeID5 { get; set; }

        public string NodeDescription1 { get; set; }
        public string NodeDescription2 { get; set; }
        public string? CRReportName { get; set; }

        //public string IconImage { get; set; }
        public string? FileName { get; set; }

    }
}
