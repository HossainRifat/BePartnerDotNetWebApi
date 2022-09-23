using Entity;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using System.Data;
using ClosedXML.Excel;

using System.Web.Mvc;

namespace BLL.Services
{
    public class InvestorService
    {
        public static List<InvestorModel> Get()
        {
            var data = DataAccessFactory.InvestorDataAccess().Get();
            var investors = new List<InvestorModel>();

            foreach(var item in data)
            {
                InvestorModel In = new InvestorModel()
                {
                    In_Email = item.In_Email,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Dob = item.Dob,
                    Gender = item.Gender,
                    Address = item.Address,
                    Phone = item.Phone,
                    Nid = item.Nid,

                    OrgName = item.OrgName,
                    OrgEstablished = item.OrgEstablished,
                    OrgLocation = item.OrgLocation,
                    OrgEmail = item.OrgEmail,
                    OrgPhone = item.OrgPhone,
                    OrgLicense = item.OrgLicense,
                    Tin = item.Tin,
                    OrgSite = item.OrgSite,

                    Password = PassSecurity.DecryptString(item.Password),
                    
                    Status = item.Status,
                    EmailValidation = item.EmailValidation,
                    Img = item.Img

                };
                investors.Add(In);
                
            }

            return investors;
        }

        public static InvestorModel Get(string email)
        {
            //email = email + ".com";
            var item = DataAccessFactory.InvestorDataAccess().Get(email);
            if(item != null)
            {
                InvestorModel In = new InvestorModel()
                {
                    In_Email = item.In_Email,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Dob = item.Dob,
                    Gender = item.Gender,
                    Address = item.Address,
                    Phone = item.Phone,
                    Nid = item.Nid,

                    OrgName = item.OrgName,
                    OrgEstablished = item.OrgEstablished,
                    OrgLocation = item.OrgLocation,
                    OrgEmail = item.OrgEmail,
                    OrgPhone = item.OrgPhone,
                    OrgLicense = item.OrgLicense,
                    Tin = item.Tin,
                    OrgSite = item.OrgSite,

                    Password = PassSecurity.DecryptString(item.Password),

                    Status = item.Status,
                    EmailValidation = item.EmailValidation,
                    Img = item.Img

                };
                return In;
            }
            return null;
        }

        public static bool Create(InvestorModel item)
        {
            Investor In = new Investor()
            {
                In_Email = item.In_Email,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Dob = item.Dob,
                Gender = item.Gender,
                Address = item.Address,
                Phone = item.Phone,
                Nid = item.Nid,

                OrgName = item.OrgName,
                OrgEstablished = item.OrgEstablished,
                OrgLocation = item.OrgLocation,
                OrgEmail = item.OrgEmail,
                OrgPhone = item.OrgPhone,
                OrgLicense = item.OrgLicense,
                Tin = item.Tin,
                OrgSite = item.OrgSite,

                Password = PassSecurity.EnryptString(item.Password),

                Status = "Invalid",
                EmailValidation = "No",
                Img = item.Img

            };

            if (DataAccessFactory.InvestorDataAccess().Create(In))
            {
                var u = new User()
                {
                    Email = item.In_Email,
                    Password = PassSecurity.EnryptString(item.Password)
                };
                return DataAccessFactory.GetUserDataAccess().Create(u);
            }
            return false;
        }

        public static bool Mail(string subject,  string body, string To)
        {

            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("rifat38939@gmail.com", "htmxzvjglnhhecyk");
                    MailMessage msgObj = new MailMessage();
                    msgObj.To.Add(To);
                    msgObj.From = new MailAddress("rifat38939@gmail.com");
                    msgObj.Subject = subject;
                    msgObj.Body = body;
                    client.Send(msgObj);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool DownloadMyInvestment(string email)
        {
            var data = IdeaServices.MyInvestment(email);
            DataTable DT_A_A = new DataTable("Grid");
            DT_A_A.Columns.AddRange(new DataColumn[8]
            {
               new DataColumn("Company Name"),
               new DataColumn("Entrepreneur Email"),
               new DataColumn("Category"),
               new DataColumn("Investment"),
               new DataColumn("Share"),
               new DataColumn("Valuation"),
               new DataColumn("Cumulative Investment"),
               new DataColumn("cumulative Share")
            });
            int investment = 0,share = 0;
            foreach (var In in data)
            {
                var valuation = (Double.Parse(In.Asking_Amount) / Double.Parse(In.Asking_Share)) * 100;
                share += int.Parse(In.Asking_Share);
                investment += int.Parse(In.Asking_Amount);
                DT_A_A.Rows.Add(
                    In.Company_Name,
                    In.En_Post_Email,
                    In.Category,
                    In.Asking_Amount,
                    In.Asking_Share,
                    valuation,
                    investment,
                    share
                    );
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(DT_A_A);

                //using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                //{
                //    wb.SaveAs(stream);
                //    return System.IO.File(stream.ToArray(), "My Investment.xlsx");
                //}
                try
                {
                    wb.SaveAs("E:\\USER\\Downloads\\MyInvestment.xlsx");
                    return true;
                }
                catch
                {
                    return false;
                }
                
            }
        }

        public static bool Update(InvestorModel item)
        {
            Investor In = new Investor()
            {
                In_Email = item.In_Email,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Dob = item.Dob,
                Gender = item.Gender,
                Address = item.Address,
                Phone = item.Phone,
                Nid = item.Nid,

                OrgName = item.OrgName,
                OrgEstablished = item.OrgEstablished,
                OrgLocation = item.OrgLocation,
                OrgEmail = item.OrgEmail,
                OrgPhone = item.OrgPhone,
                OrgLicense = item.OrgLicense,
                Tin = item.Tin,
                OrgSite = item.OrgSite,

                Password = PassSecurity.EnryptString(item.Password),

                Status = item.Status,
                EmailValidation = item.EmailValidation,
                Img = item.Img

            };
            if (DataAccessFactory.InvestorDataAccess().Update(In)){
                var u = new User()
                {
                    Email = item.In_Email,
                    Password = PassSecurity.EnryptString(item.Password)
                };
                return DataAccessFactory.GetUserDataAccess().Update(u);
            }
            else
            {
                return true;
            }
        }

        public static bool Delete(string email)
        {
            //email = email + ".com";
            return DataAccessFactory.InvestorDataAccess().Delete(email);
        }

        public static bool createVarification(VarificationModel V)
        {
            if (DataAccessFactory.InvestorVarificationDataAccess().checkMail(V.Email))
            {
                V.Code = Security.RandomToken.VarificationString();
                if(DataAccessFactory.InvestorVarificationDataAccess().createVar(V.Email, V.Code))
                {
                    var subject = "BePartner Email Verification";
                    var body = "Your Verification code is:" + V.Code;
                    return Mail(subject, body, V.Email);
                }
            }
            return false;
        }

        public static bool checkVarification(VarificationModel V)
        {
            if(DataAccessFactory.InvestorVarificationDataAccess().checkVar(V.Email, V.Code))
            {
                return DataAccessFactory.InvestorVarificationDataAccess().createVar(V.Email, "Yes");
            }
            return false;
        }

    }
}
