using Optiologicsample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;

namespace Optiologicsample.Controllers
{
    
    public class HomeController : Controller
    {
        public SqlConnection con = new SqlConnection("Data Source=DESKTOP-14TVSBN\\SQLEXPRESS;Initial Catalog=db;Integrated Security=True");
        public SqlCommand cmd = new SqlCommand();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult employee()//Listing employees 
        {
            List<employee> lstemployee = new List<employee>();
            employee prct = new employee();
            cmd.Connection = con;
            cmd.CommandText = "select *from tb_employee where Isactive="+1+"";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lstemployee = (from DataRow dr in dt.Rows select new employee() { empid = int.Parse(dr["empid"].ToString()),empfirstname = dr["empfirstname"].ToString(), emplastname = dr["emplastname"].ToString(), empemail = dr["empemail"].ToString(), empdob = dr["empdob"].ToString(), Gender = dr["Gender"].ToString()}).ToList();
            return View(lstemployee);
           
        }
        public ActionResult Create()//enter creted employee details 
        {
            return View();
        }
        public ActionResult Create1(employee emp)//inserting value to db
        {
            cmd.Connection = con;
            cmd.CommandText = "select *from tb_employee where empemail='" + emp.empemail + "'";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ViewBag.msg = "Sorry the email already exist";
                return View("Create");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    cmd.Connection = con;
                    cmd.CommandText = "insert into tb_employee values('" + emp.empfirstname + "','" + emp.emplastname + "','" + emp.empemail + "','" + emp.empdob + "','" + emp.Gender + "','" + emp.emppassword + "','" + emp.empconfirmpassword + "',1)";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return RedirectToAction("employee");
                }
            }
            return View("Create", emp);
        }
        //public ActionResult pass(int id)
        //{
        //    //Session["id"] = id;
        //    return View(id);
        //}
        public ActionResult Edit(int id)//selecting edited employee
        {
            //employee emp1 = new employee();
            //cmd.Connection = con;
            //cmd.CommandText = "select *from tb_employee where empemail='" + emp1.emppassword + "'";
            //SqlDataAdapter sda1 = new SqlDataAdapter();
            //sda1.SelectCommand = cmd;
            //DataTable dt1 = new DataTable();
            //sda1.Fill(dt1);
            //if (dt1.Rows.Count > 0)
            //{
                employee emp = new employee();

                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "select *from tb_employee where empid=" + id;
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                emp.empid = int.Parse(dt.Rows[0]["empid"].ToString());
                emp.empfirstname = dt.Rows[0]["empfirstname"].ToString();
                emp.emplastname = dt.Rows[0]["emplastname"].ToString();
                emp.empemail = dt.Rows[0]["empemail"].ToString();
                emp.empdob = dt.Rows[0]["empdob"].ToString();
                emp.Gender = dt.Rows[0]["Gender"].ToString();
               // emp.emppassword = dt.Rows[0]["emppassword"].ToString();
               // emp.empconfirmpassword = dt.Rows[0]["empconfirmpassword"].ToString();
                con.Close();
                return View(emp);

            //}
            //else
            //{
            //    ViewBag.msg = "Sorry password donot macth";
            //    return View("employee");
            //}
            
           
            
        }
        public ActionResult Edit1(employee emp)//updating edited employee
        {
            
            cmd.Connection = con;
            cmd.CommandText = "update tb_employee set empfirstname='" + emp.empfirstname + "',emplastname='" + emp.emplastname + "',empemail='" + emp.empemail + "',empdob='" + emp.empdob + "',Gender='" + emp.Gender + "',emppassword='" + emp.emppassword + "',empconfirmpassword='" + emp.empconfirmpassword + "' where empid= "+emp.empid+"";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("employee");

        }
        public ActionResult Delete(int id)//select deleting employee details
        {
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select *from tb_employee where empid =" + id;
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            employee emp = new employee();
            emp.empid = int.Parse(dt.Rows[0]["empid"].ToString());
            emp.empfirstname = dt.Rows[0]["empfirstname"].ToString();
            emp.emplastname = dt.Rows[0]["emplastname"].ToString();
            emp.empemail = dt.Rows[0]["empemail"].ToString();
            emp.empdob = dt.Rows[0]["empdob"].ToString();
            emp.Gender = dt.Rows[0]["Gender"].ToString();
            emp.emppassword = dt.Rows[0]["emppassword"].ToString();
            emp.empconfirmpassword = dt.Rows[0]["empconfirmpassword"].ToString();
            con.Close();
            return View(emp);
        }
        public ActionResult Delete1(employee emp)//deleting employee details from front end
        {
            cmd.Connection = con;
            cmd.CommandText = "update tb_employee set Isactive="+0+" where empid="+emp.empid+"";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("employee");

        }


    }
}