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
    
    public partial class gekmembers
    {
        public gekmembers()
        {
            this.gwresult = new HashSet<gwresult>();
        }
    
        public int id { get; set; }
        public int secretary { get; set; }
        public int president { get; set; }
        public int membersciadv { get; set; }
        public int member2 { get; set; }
        public int member3 { get; set; }
        public int member4 { get; set; }
    
        public virtual gek gek { get; set; }
        public virtual gek gek1 { get; set; }
        public virtual gek gek2 { get; set; }
        public virtual gek gek3 { get; set; }
        public virtual gek gek4 { get; set; }
        public virtual sciadvisor sciadvisor { get; set; }
        public virtual ICollection<gwresult> gwresult { get; set; }
    }
}