//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TermProjectFacultyC
{
    using System;
    using System.Collections.Generic;
    
    public partial class gwresult
    {
        public int id { get; set; }
        public int eventid { get; set; }
        public int gekid { get; set; }
        public int gw { get; set; }
        public int mark { get; set; }
    
        public virtual eventlog eventlog { get; set; }
        public virtual gekmembers gekmembers { get; set; }
    }
}
