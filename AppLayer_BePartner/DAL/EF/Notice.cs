
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DAL.EF
{

using System;
    using System.Collections.Generic;
    
public partial class Notice
{

    public int Notice_Id { get; set; }

    public string Subject { get; set; }

    public string Description { get; set; }

    public System.DateTime Issue_time { get; set; }

    public System.DateTime Due_time { get; set; }

    public string Status { get; set; }

}

}
