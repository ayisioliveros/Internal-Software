using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackerModuleV1._0.Models.PTM
{
    public class Part
    {
        public int PartId { get; set; }
        [Required]
        public string PartName { get; set; }
        public string PartDescription { get; set; }
        public string NovenaTecPartNumber { get; set; }
        public string SwissRanksPartNumber { get; set; }
        public string OEMPartNumber { get; set; }
        public string VendorPartNumber { get; set; }
        public int StockQuantity { get; set; }
        public string Status { get; set; }
        public int CreatedUserId{get; set;}
        public User CreatedBy { get; set; }
        public User ApproveBy { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}