//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AIS_DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Part : Product
    {
        public int PaTypeID { get; set; }
    
        public virtual PaType PaType { get; set; }
    }
}
