using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cs = " "; // DB connection string here
            string sql = ""; // sql selections here
            SqlDataAdapter sda = new SqlDataAdapter(sql, cs);
            DataTable dt1 = new DataTable();
            sda.Fill(dt1);

            string mailBody = "";
            foreach (DataRow item in dt1.Rows)
            {
                mailBody += item["OrderData"] + " " + item["CustomerID"]; // rows in db

            }

            MailGonder(mailBody);
        }

        private static void MailGonder(string mailBody)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress(""); // ur mail
            ePosta.To.Add(""); // target email
            ePosta.Subject = ""; // Subject
            ePosta.Body = mailBody;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("",""); // your mail and pass
            smtp.Port = 587;
            smtp.Host = ""; // host
            smtp.EnableSsl = true;
            smtp.Send(ePosta);
        }
    }
}
