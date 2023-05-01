using POS.Models.DB;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace POS.StoredProcedure
{
    public class Procedures
    {
        public string cnn = "";

        public Procedures()
        {

            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:Connection").Value;
        }

        public List<Currency> GetAccCurrByAccNumber(int accNumber)
        {
            List<Currency> ListOfCities = new List<Currency>();
            using (SqlConnection cn = new SqlConnection(cnn))
            {

                using (SqlCommand cmd = new SqlCommand("GetAccCurrByAccNumber", cn))
                {

                    cmd.Parameters.Add("@AccNumber",SqlDbType.Int);
                    cmd.Parameters["@AccNumber"].Value = accNumber;
                    cmd.CommandType = CommandType.StoredProcedure;


                    if (cn.State == ConnectionState.Closed)
                        cn.Open();

                    IDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        ListOfCities.Add(new Currency

                        {
                            CurrenciesId = int.Parse(reader["currencies"].ToString()),
                            CurrenName = reader["CurrenName"].ToString(),

                        }
                            );
                    }
                }

            }
            return ListOfCities;
        }

        public List<CurrenciesExchangeRate> GetExchangeRateByCurr(int CurrId)
        {
            List<CurrenciesExchangeRate> ListOfCities = new List<CurrenciesExchangeRate>();
            using (SqlConnection cn = new SqlConnection(cnn))
            {

                using (SqlCommand cmd = new SqlCommand("ExchangeRate", cn))
                {

                    cmd.Parameters.Add("@Currencies", SqlDbType.Int);
                    cmd.Parameters["@Currencies"].Value = CurrId;
                    cmd.CommandType = CommandType.StoredProcedure;


                    if (cn.State == ConnectionState.Closed)
                        cn.Open();

                    IDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        ListOfCities.Add(new CurrenciesExchangeRate

                        {
                            CurrenciesExchangeRateId = int.Parse(reader["Currencies_Exchange_Rate_Id"].ToString()),
                            CurreExchangeRate = double.Parse(reader["CurreExchangeRate"].ToString())

                        }
                            ); ;
                    }
                }

            }
            return ListOfCities;
        }
        public string Stages(string StageNo)
        {
            string bb = "";
            using (SqlConnection cn = new SqlConnection(cnn))
            {

                using (SqlCommand cmd = new SqlCommand("Stages", cn))
                {

                    cmd.Parameters.Add("@StageNo", SqlDbType.VarChar);
                    cmd.Parameters["@StageNo"].Value = StageNo;
                    cmd.CommandType = CommandType.StoredProcedure;


                    if (cn.State == ConnectionState.Closed)
                        cn.Open();

                    IDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {

                         bb = reader["Return Value"].ToString();
                     }
                           
                }
            }

            
            return bb;
        }


        public string PayStages(string StageNo)
        {
            string bb = "";
            using (SqlConnection cn = new SqlConnection(cnn))
            {

                using (SqlCommand cmd = new SqlCommand("PayStages", cn))
                {

                    cmd.Parameters.Add("@StageNo", SqlDbType.VarChar);
                    cmd.Parameters["@StageNo"].Value = StageNo;
                    cmd.CommandType = CommandType.StoredProcedure;


                    if (cn.State == ConnectionState.Closed)
                        cn.Open();

                    IDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {

                        bb = reader["Return Value"].ToString();
                    }

                }
            }


            return bb;
        }



        public string ChexStages(string StageNo)
        {
            string bb = "";
            using (SqlConnection cn = new SqlConnection(cnn))
            {

                using (SqlCommand cmd = new SqlCommand("ChexStages", cn))
                {

                    cmd.Parameters.Add("@StageNo", SqlDbType.VarChar);
                    cmd.Parameters["@StageNo"].Value = StageNo;
                    cmd.CommandType = CommandType.StoredProcedure;


                    if (cn.State == ConnectionState.Closed)
                        cn.Open();

                    IDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {

                        bb = reader["Return Value"].ToString();
                    }

                }
            }


            return bb;
        }


        public string ChpyStages(string StageNo)
        {
            string bb = "";
            using (SqlConnection cn = new SqlConnection(cnn))
            {

                using (SqlCommand cmd = new SqlCommand("ChpyStages", cn))
                {

                    cmd.Parameters.Add("@StageNo", SqlDbType.VarChar);
                    cmd.Parameters["@StageNo"].Value = StageNo;
                    cmd.CommandType = CommandType.StoredProcedure;


                    if (cn.State == ConnectionState.Closed)
                        cn.Open();

                    IDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {

                        bb = reader["Return Value"].ToString();
                    }

                }
            }


            return bb;
        }





    }
}
