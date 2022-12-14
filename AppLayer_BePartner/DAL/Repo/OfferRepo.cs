using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class OfferRepo : In_IRepo<Offer, int>, In_OfferIRepo<Offer, string>
    {
        bePartnerCentralDatabaseEntities db;

        public OfferRepo(bePartnerCentralDatabaseEntities db)
        {
            this.db = db;
        }
        public bool Create(Offer obj)
        {
            db.Offers.Add(obj);
            var l = db.SaveChanges();
            if (l > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var offer = Get(id);
            db.Offers.Remove(offer);
            var l = db.SaveChanges();
            if (l > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteByEnEmail(string email)
        {
            var offers = (from I in db.Offers where I.En_Email.Equals(email) select I).ToList();
            foreach (var offer in offers)
            {
                db.Offers.Remove(offer);
            }
            var l = db.SaveChanges();
            if (l > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteByInEmail(string email)
        {
            var offers = (from I in db.Offers where I.In_Email.Equals(email) select I).ToList();
            foreach (var offer in offers)
            {
                db.Offers.Remove(offer);
            }
            var l = db.SaveChanges();
            if (l > 0)
            {
                return true;
            }
            return false;
        }

        public List<Offer> Get()
        {
            return db.Offers.ToList();
        }

        public Offer Get(int id)
        {
            return db.Offers.FirstOrDefault(o => o.Id == id);
        }

        public List<Offer> getByCOmpanyId(string id)
        {
            int id2 = int.Parse(id);
            var offers = (from I in db.Offers where I.Ideas_Id==id2 select I).ToList();
            return offers;
        }

        public List<Offer> MySentOffer(string email)
        {
            var offers = (from I in db.Offers where I.In_Email.Equals(email) select I).ToList();
            return offers;
        }

        public List<Offer> MySentOfferByCompany(string CompanyId, string email)
        {
            int id2 = int.Parse(CompanyId);
            var offers = (from I in db.Offers where I.Ideas_Id == id2 && I.In_Email.Equals(email) select I).ToList();
            return offers;
        }

        public bool Update(Offer obj)
        {
            var offer = db.Offers.FirstOrDefault(o => o.Id == obj.Id);

            offer.En_Email = obj.En_Email;
            offer.In_Email = obj.In_Email;
            offer.Offered_Amount = obj.Offered_Amount;
            offer.Offered_Share = obj.Offered_Share;
            offer.Title = obj.Title;
            offer.Description = obj.Description;
            offer.Ideas_Id = obj.Ideas_Id;

            var l = db.SaveChanges();

            if(l > 0)
            {
                return true;
            }
            return false;
        }
    }
}
