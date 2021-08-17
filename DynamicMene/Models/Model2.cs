using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DynamicMene.Models
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<MainMenu> MainMenus { get; set; }
        public virtual DbSet<SubMenu> SubMenus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainMenu>()
                .Property(e => e.menuname)
                .IsUnicode(false);
        }
    }
}
