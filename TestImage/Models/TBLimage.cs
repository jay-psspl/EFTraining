namespace TestImage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("TBLimage")]
    public partial class TBLimage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]


        public int id { get; set; }

        public string Title { get; set; }

        [DisplayName("Upload Image")]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
