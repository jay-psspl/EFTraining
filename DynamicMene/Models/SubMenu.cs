namespace DynamicMene.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubMenu")]
    public partial class SubMenu
    {
        public int id { get; set; }

        public string submenuname { get; set; }

        public string submenuurl { get; set; }

        public int? mainmenuid { get; set; }

        public virtual MainMenu MainMenu { get; set; }
    }
}
