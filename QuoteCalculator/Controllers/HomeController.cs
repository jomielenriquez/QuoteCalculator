using QuoteCalculator.Controllers.Repository;
using QuoteCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualBasic;

namespace QuoteCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(string mess)
        {
            ViewBag.Message = mess;

            return View();
        }
        public ActionResult Success()
        {
            ViewBag.Message = "Successful";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult APITester()
        {
            return View();
        }
        public ActionResult QuoteList()
        {
            CalcuRepository calcuRepository = new CalcuRepository();

            Quotelist QL = new Quotelist();

            QL.QL = calcuRepository.GetQuote();

            return View(QL);
        }
        public ActionResult QuoteCalculator(
            string AmountRequired="",
            string Term="", 
            string Title = "", 
            string FirstName = "", 
            string LastName = "", 
            string DateOfBirth = "", 
            string Mobile = "", 
            string Email = "",
            string Product= "")
        {
            ViewBag.Message = "QuoteCalculator";
            Quote quote = new Quote();
            quote.AmountRequired = AmountRequired;
            quote.Term = Term;
            quote.Title = Title;
            quote.FirstName= FirstName;
            quote.LastName = LastName;
            quote.DateOfBirth = DateOfBirth;
            quote.Mobile = Mobile;
            quote.Email = Email;
            quote.QID = "";

            if (FirstName != "" && LastName!="" && Title!="") //check the name
            {
                quote.QID = InsertQuote(AmountRequired,
                            Term,
                            Title,
                            FirstName,
                            LastName,
                            DateOfBirth,
                            Mobile,
                            Email,
                            Product);

                quote.Weekly = Convert.ToString(GetWeekly(0.02, Convert.ToDouble(Term) * 4, Convert.ToDouble(AmountRequired), 0));
            }

            return View(quote);
        }

        public ActionResult Quote(
            string AmountRequired = "",
            string Term = "",
            string Title = "",
            string FirstName = "",
            string LastName = "",
            string DateOfBirth = "",
            string Mobile = "",
            string Email = "",
            string Product = "",
            string QID = ""
            
            )
        {
            ViewBag.Message = "QuoteCalculator";
            Quote quote = new Quote();
            quote.AmountRequired = AmountRequired;
            quote.Term = Term;
            quote.Title = Title;
            quote.FirstName = FirstName;
            quote.LastName = LastName;
            quote.DateOfBirth = DateOfBirth;
            quote.Mobile = Mobile;
            quote.Email = Email;
            quote.QID = QID;
            quote.Product= Product;
            quote.Weekly = Convert.ToString(GetWeekly(0.02, Convert.ToDouble(Term) * 4, Convert.ToDouble(AmountRequired), 0));
            
            return View(quote);
        }

        public string GetProduct()
        {
            CalcuRepository calcuRepository = new CalcuRepository();
            string product = calcuRepository.GetProduct();
            return product;
        }
        public string InsertQuote(
            string AmountRequired,
            string Term          ,
            string Title         ,
            string FirstName     ,
            string LastName      ,
            string DateOfBirth   ,
            string Mobile        ,
            string Email         ,
            string Product       
            )
        {
            CalcuRepository calcuRepository = new CalcuRepository();
            return calcuRepository.InsertQuote(AmountRequired,
                                                        Term          ,
                                                        Title         ,
                                                        FirstName     ,
                                                        LastName      ,
                                                        DateOfBirth   ,
                                                        Mobile        ,
                                                        Email         ,
                                                        Product);
        }

        public double GetWeekly(double rate, double nper, double pv, double fv)
        {
            double PMT = rate * (fv + pv * Math.Pow(1 + rate, nper)) / ((Math.Pow(1 + rate, nper) - 1)); // without interest
            //double PMT = -rate * (fv + pv * Math.Pow(1 + rate, nper)) / ((Math.Pow(1 + rate, nper) - 1));
            //return Financial.Pmt(rate, nper, pv, fv, due);
            return PMT;
        }

        public string strGetWeekly(string strTerm, string  strAmount)
        {
            double nper = Convert.ToDouble(strTerm);
            double pv = Convert.ToDouble(strAmount);

            return Convert.ToString(GetWeekly(0.02, nper * 4, pv, 0));
        }
        public string UpdateQuote(
            string AmountRequired,
            string Term,
            string Title,
            string FirstName,
            string LastName,
            string DateOfBirth,
            string Mobile,
            string Email,
            string Product,
            string Weekly,
            string QID
            )
        {
            CalcuRepository calcuRepository = new CalcuRepository();
            return calcuRepository.UpdateQuote(
                AmountRequired,
                Term,
                Title,
                FirstName,
                LastName,
                DateOfBirth,
                Mobile,
                Email,
                Product,
                Weekly,
                QID);
        }
    }
}