using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Adatb_zis.Modell.record;

namespace Adatb_zis.Modell.maneger
{
    class NovenyekTabla : dataConnection 
    {
        OracleConnection GetOracleConnection()
        {
            OracleConnection oc = new OracleConnection();
            string connectionString = @"Data Source=193.225.33.71;User Id=ORA_S1340;Password=EKE2020;";
            oc.ConnectionString = connectionString;
            return oc;
        }

        public List<Novenyek> Select()
        {
            List<Novenyek> records = new List<Novenyek>();

            OracleCommand command = new OracleCommand();
            command.Connection = connectionopen();

            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT id_noveny, viragzas, kor, fajta, ar, uzletek_Id FROM novenyek";


            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Novenyek noveny = new Novenyek();
                noveny.Id_noveny = (string)reader["id_noveny"];
                noveny.Viragzas = (string)reader["viragzas"];
                noveny.Kor = (string)reader["kor"];
                noveny.Fajta = (string)reader["fajta"];
                noveny.Ar = int.Parse(reader["ar"].ToString());
                noveny.Uzletek_id = int.Parse(reader["uzletek_Id"].ToString());
                
                records.Add(noveny);
            }
            reader.Close();
            return records;
        }

        public int Delete(Novenyek record)
        {
            OracleConnection oc = GetOracleConnection();
            oc.Open();

            OracleTransaction ot = oc.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            OracleCommand command = new OracleCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "DELETE FROM novenyek WHERE id_noveny = :id_noveny"
            };

            OracleParameter idszamParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":p_id_noveny",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Id_noveny
            };
            command.Parameters.Add(idszamParameter);

            command.Connection = oc;
            command.Transaction = ot;

            int affectedRows = 0;
            try
            {
                affectedRows = command.ExecuteNonQuery();
                ot.Commit();
            }
            catch (Exception)
            {
                ot.Rollback();
            }
            return affectedRows;
        }

        public int Insert(Novenyek record)
        {
            OracleCommand command = new OracleCommand();
            command.Connection = connectionopen();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO novenyek(id_noveny, viragzas, kor, fajta, ar, uzletek_Id) VALUES(:id_noveny, :viragzas, :kor, :fajta, :ar, :uzletek_Id)";

            OracleParameter pid = new OracleParameter();
            pid.ParameterName = ":id_noveny";
            pid.OracleDbType = OracleDbType.Varchar2;
            pid.Direction = System.Data.ParameterDirection.Input;
            pid.Value = record.Id_noveny;

            OracleParameter pviragzas = new OracleParameter();
            pviragzas.ParameterName = ":viragzas";
            pviragzas.OracleDbType = OracleDbType.Varchar2;
            pviragzas.Direction = System.Data.ParameterDirection.Input;
            pviragzas.Value = record.Viragzas;

            OracleParameter pkor = new OracleParameter();
            pkor.ParameterName = ":kor";
            pkor.OracleDbType = OracleDbType.Varchar2;
            pkor.Direction = System.Data.ParameterDirection.Input;
            pkor.Value = record.Kor;

            OracleParameter petfajta = new OracleParameter();
            petfajta.ParameterName = ":fajta";
            petfajta.OracleDbType = OracleDbType.Varchar2;
            petfajta.Direction = System.Data.ParameterDirection.Input;
            petfajta.Value = record.Fajta;

            OracleParameter par = new OracleParameter();
            par.ParameterName = ":ar";
            par.OracleDbType = OracleDbType.Varchar2;
            par.Direction = System.Data.ParameterDirection.Input;
            par.Value = record.Ar;

            OracleParameter puzletid = new OracleParameter();
            puzletid.ParameterName = ":uzletek_Id";
            puzletid.OracleDbType = OracleDbType.Long;
            puzletid.Direction = System.Data.ParameterDirection.Input;
            puzletid.Value = record.Uzletek_id;

            command.Parameters.Add(pid);
            command.Parameters.Add(pviragzas);
            command.Parameters.Add(pkor);
            command.Parameters.Add(petfajta);
            command.Parameters.Add(par);
            command.Parameters.Add(puzletid);

            return command.ExecuteNonQuery();

        }
            

        public bool CheckIdszam(string idszam)
        {
            OracleConnection oc = GetOracleConnection();
            oc.Open();

            OracleCommand command = new OracleCommand()
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "sfcheck_id_noveny"
            };

            OracleParameter correct = new OracleParameter()
            {
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.ReturnValue
            };

            OracleParameter idszamParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "id_noveny",
                Direction = System.Data.ParameterDirection.Input,
                Value = idszam
            };
            command.Parameters.Add(idszamParameter);
            command.Connection = oc;

            try
            {
                int succesful = int.Parse(correct.Value.ToString());
                return succesful != 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
