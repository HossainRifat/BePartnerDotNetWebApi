using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class IdeaRepo : In_IRepo<Idea, int>, In_IdeaIRepo<Idea, string>
    {
        bePartnerCentralDatabaseEntities db;

        public IdeaRepo(bePartnerCentralDatabaseEntities db)
        {
            this.db = db;
        }

        public bool Create(Idea obj)
        {
            db.Ideas.Add(obj);
            var l = db.SaveChanges();
            if(l > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var idea = Get(id);
            db.Ideas.Remove(idea);
            var l = db.SaveChanges();
            if( l > 0)
            {
                return true;
            }
            return false;
        }

        public List<Idea> Get()
        {
            var data = (from I in db.Ideas where !I.Status.Equals("Confirmed") select I).ToList();
            return data;
        }

        public Idea Get(int id)
        {
            return db.Ideas.FirstOrDefault(s => s.PostId == id);
        }

        public List<Idea> GetByConfirmed()
        {
            var En = (from I in db.Ideas where I.Status.Equals("Confirmed") select I).ToList();
            return En;
        }

        public Idea GetByEnEmail(string email)
        {
            return db.Ideas.FirstOrDefault(s => s.En_Post_Email.Equals(email));
        }

        public Idea GetByName(string name)
        {
            return db.Ideas.FirstOrDefault(s => s.Company_Name.Equals(name));
        }

        public List<Idea> GetMyInvestment(string email)
        {
            var En = (from I in db.Ideas where I.In_Asp_Email.Equals(email) select I).ToList();
            return En;
        }

        public List<Idea> SearchIdea(string CompanyName)
        {
            var data = (from I in db.Ideas where !I.Status.Equals("Confirmed") && I.Company_Name.Contains(CompanyName) select I).ToList();
            return data;
        }

        public List<Idea> SortCAZ()
        {
            var data = (from I in db.Ideas where !I.Status.Equals("Confirmed") orderby I.Company_Name ascending select I).ToList();
            return data;
        }

        public List<Idea> SortCZA()
        {
            var data = (from I in db.Ideas where !I.Status.Equals("Confirmed") orderby I.Company_Name descending select I).ToList();
            return data;
        }

        public List<Idea> SortS19()
        {
            var data = (from I in db.Ideas where !I.Status.Equals("Confirmed") orderby I.Valuation ascending select I).ToList();
            return data;
        }

        public List<Idea> SortS91()
        {
            var data = (from I in db.Ideas where !I.Status.Equals("Confirmed") orderby I.Valuation descending select I).ToList();
            return data;
        }

        public List<Idea> SortV19()
        {
            var data = (from I in db.Ideas where !I.Status.Equals("Confirmed") orderby I.Asking_Share ascending select I).ToList();
            return data;
        }

        public List<Idea> SortV91()
        {
            var data = (from I in db.Ideas where !I.Status.Equals("Confirmed") orderby I.Asking_Share descending select I).ToList();
            return data;
        }

        public bool Update(Idea obj)
        {
            var idea = db.Ideas.FirstOrDefault(s => s.Company_Name.Equals(obj.Company_Name));

            idea.Status = obj.Status;
            idea.In_Asp_Email = obj.In_Asp_Email;

            idea.Asking_Amount = obj.Asking_Amount;
            idea.Asking_Share = obj.Asking_Share;
            
            idea.Offer_Amount = obj.Offer_Amount;
            idea.Offer_Share = obj.Offer_Share;
            idea.Message = obj.Message;
            
            idea.Company_Name = obj.Company_Name;
            idea.Moto = obj.Moto;
            idea.Description = obj.Description;
            idea.Post_Time = DateTime.Now;
            
            
            idea.Last_Month_profit = obj.Last_Month_profit;
            idea.Last_Year_Profit = obj.Last_Year_Profit;
            idea.Total_Profit = obj.Total_Profit;
            idea.Valuation = obj.Valuation;

            idea.Feature1_Title = obj.Feature1_Title;
            idea.Feature2_Title = obj.Feature2_Title;
            idea.Feature3_Title = obj.Feature3_Title;
            idea.Feature4_Title = obj.Feature4_Title;
            idea.Feature1_Des = obj.Feature1_Des;
            idea.Feature2_Des = obj.Feature2_Des;
            idea.Feature3_Des = obj.Feature3_Des;
            idea.Feature4_Des = obj.Feature4_Des;

            var l = db.SaveChanges();
            if (l > 0)
            {
                return true;
            }
            return false;
        }
    }
}
