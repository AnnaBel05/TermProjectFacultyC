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
    using System.Collections.Generic;
    
    public partial class userrole
    {
        public userrole()
        {
            this.userinfo = new HashSet<userinfo>();
        }
    
        public int id { get; set; }
        public string rolename { get; set; }
    
        public virtual ICollection<userinfo> userinfo { get; set; }
    }
}
