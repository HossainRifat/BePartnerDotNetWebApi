
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
    
public partial class Idea
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Idea()
    {

        this.Offers = new HashSet<Offer>();

    }


    public int PostId { get; set; }

    public string En_Post_Email { get; set; }

    public string In_Asp_Email { get; set; }

    public string Company_Name { get; set; }

    public string Moto { get; set; }

    public string Description { get; set; }

    public System.DateTime Post_Time { get; set; }

    public string Asking_Amount { get; set; }

    public string Asking_Share { get; set; }

    public string Status { get; set; }

    public string Message { get; set; }

    public string Offer_Amount { get; set; }

    public string Offer_Share { get; set; }

    public string Img { get; set; }

    public string Category { get; set; }

    public string Total_Profit { get; set; }

    public string Last_Month_profit { get; set; }

    public string Last_Year_Profit { get; set; }

    public string Valuation { get; set; }

    public string Feature1_Title { get; set; }

    public string Feature1_Des { get; set; }

    public string Feature2_Title { get; set; }

    public string Feature2_Des { get; set; }

    public string Feature3_Title { get; set; }

    public string Feature3_Des { get; set; }

    public string Feature4_Title { get; set; }

    public string Feature4_Des { get; set; }



    public virtual Entrepreneur Entrepreneur { get; set; }

    public virtual Investor Investor { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Offer> Offers { get; set; }

}

}
