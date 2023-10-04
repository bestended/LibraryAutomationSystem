using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LibraryAutomationSystem.Models
{
    public class Dap
    {

        public static string ConnectionString = @"Server=DESKTOP-1PBLKBH\SQLEXPRESS; initial Catalog=LibraryAutomation; user Id=sa; password=12345;";

        public static void ExecuteReturn(string procAdi,DynamicParameters param=null)
        {


            using (SqlConnection con=new SqlConnection (ConnectionString))
            {

                con.Open();
                con.Execute(procAdi,param,commandType:System.Data.CommandType.StoredProcedure);

            }


        }

        public static IEnumerable<T> Listeleme<T>(string procAdi,DynamicParameters param)
        {
            using (SqlConnection con=new SqlConnection (ConnectionString))
            {
              con.Open();
             return   con.Query<T>(procAdi, param, commandType: System.Data.CommandType.StoredProcedure);


            }



        }







    }
}