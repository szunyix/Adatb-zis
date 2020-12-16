using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adatb_zis.Modell.record;

namespace Adatb_zis.Modell.maneger
{
    class UzletTáblakezelő : dataConnection
    {
        OracleConnection GetOracleConnection()
        {
            OracleConnection oc = new OracleConnection();
            string connectionString = @"Data Source=193.225.33.71;User Id=ORA_S1340;Password=EKE2020;";
            oc.ConnectionString = connectionString;
            return oc;
        }

        public List<Uzletek> Select()
        {
            List<Uzletek> records = new List<Uzletek>();

            OracleCommand command2 = new OracleCommand();
            command2.Connection = connectionopen();

            command2.CommandType = System.Data.CommandType.Text;
            command2.CommandText = "SELECT * FROM uzletek";


            OracleDataReader reader = command2.ExecuteReader();
            while (reader.Read())
            {
                Uzletek uzlet = new Uzletek();
                uzlet.id = int.Parse((string)reader["id"].ToString());
                uzlet.nev = (string)reader["nev"];
                records.Add(uzlet);
            }
            reader.Close();
            return records;
        }
    }
}
