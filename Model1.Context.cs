//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TermProjectFacultyC
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class facultyEntities1 : DbContext
    {
        public facultyEntities1()
            : base("name=facultyEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<eventlog> eventlog { get; set; }
        public DbSet<gek> gek { get; set; }
        public DbSet<gekmembers> gekmembers { get; set; }
        public DbSet<gwresult> gwresult { get; set; }
        public DbSet<purchaselist> purchaselist { get; set; }
        public DbSet<sciadvisor> sciadvisor { get; set; }
        public DbSet<userinfo> userinfo { get; set; }
        public DbSet<userrole> userrole { get; set; }
    }
}
