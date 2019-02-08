using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebApplication.Modules;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    

    public class DataController : Controller
    {
        private ArrayList list;
        [Route("api/Select")]
        [HttpGet]
        public ArrayList Select()
        {
            list = new ArrayList();

            Database db = new Database();
            MySqlDataReader sdr = db.Reader("select * from Notice");

            while (sdr.Read())
            {
                Hashtable ht = new Hashtable();
                //string[] arr = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
                    //arr[i] = sdr.GetValue(i).ToString();
                }

                list.Add(ht);
            }

            return list;
        }

        
    }
}
