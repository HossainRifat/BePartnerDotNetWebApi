
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
    
public partial class Offer
{

    public int Id { get; set; }

    public string In_Email { get; set; }

    public string En_Email { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int Ideas_Id { get; set; }

    public string Offered_Share { get; set; }

    public string Offered_Amount { get; set; }



    public virtual Entrepreneur Entrepreneur { get; set; }

    public virtual Idea Idea { get; set; }

    public virtual Investor Investor { get; set; }

}

}
