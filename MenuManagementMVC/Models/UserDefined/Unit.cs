using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MenuManagementMVC.Models.UserDefined
{
    public class Unit
    {
        public int UnitId { get; set; }

        [DisplayName("Unit Type")]
        public string UnitType { get; set; }

        [DisplayName("Unit Measure")]
        public int UnitMeasure { get; set; }

        [DisplayName("Unit Scale")]
        public string UnitScale { get; set; }

        public DateTime? LastUpdatedDate { get; set; }
        public string RecordStatus { get; set; }
    }
}