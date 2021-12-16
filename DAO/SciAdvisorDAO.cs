using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TermProjectFacultyC.DAO
{
    public class SciAdvisorDAO : DAO
    {
        public List<sciadvisor> GetAllRecords()
        {
            Connect();
            List<sciadvisor> infoList = new List<sciadvisor>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM sciadvisor", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sciadvisor sciadvisorObj = new sciadvisor();
                    sciadvisorObj.id = Convert.ToInt32(reader["id"]);
                    sciadvisorObj.professor = Convert.ToInt32(reader["professor"]);
                    sciadvisorObj.hoursGW = Convert.ToInt32(reader["hoursGW"]);
                    sciadvisorObj.hoursperGW = Convert.ToInt32(reader["hoursperGW"]);
                    sciadvisorObj.takenGWquantity = Convert.ToInt32(reader["takenGWquantity"]);
                    sciadvisorObj.freeGWquantity = Convert.ToInt32(reader["freeGWquantity"]);
                    infoList.Add(sciadvisorObj);

                }
                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return infoList;
        }

        public sciadvisor GetRecord(int id)
        {
            Connect();
            sciadvisor sciadvisorObj = new sciadvisor();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM sciadvisor where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                sciadvisorObj.id = Convert.ToInt32(reader["id"]);
                sciadvisorObj.professor = Convert.ToInt32(reader["professor"]);
                sciadvisorObj.hoursGW = Convert.ToInt32(reader["hoursGW"]);
                sciadvisorObj.hoursperGW = Convert.ToInt32(reader["hoursperGW"]);
                sciadvisorObj.takenGWquantity = Convert.ToInt32(reader["takenGWquantity"]);
                sciadvisorObj.freeGWquantity = Convert.ToInt32(reader["freeGWquantity"]);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return sciadvisorObj;
        }

        public bool UpdateRecord(int id, sciadvisor sciadvisorObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE userrole SET " +
                    " professor = @professor " +
                    " hoursGW = @hoursGW " +
                    " hoursperGW = @hoursperGW " +
                    " takenGWquantity = @takenGWquantity " +
                    " freeGWquantity = @freeGWquantity" +
                    " password = @Password" +
                    " WHERE id = @ID ", Con);

                cmd.Parameters.Add(new SqlParameter("@professor", sciadvisorObj.professor));
                cmd.Parameters.Add(new SqlParameter("@hoursGW", sciadvisorObj.hoursGW));
                cmd.Parameters.Add(new SqlParameter("@hoursperGW", sciadvisorObj.hoursperGW));
                cmd.Parameters.Add(new SqlParameter("@takenGWquantity", sciadvisorObj.takenGWquantity));
                cmd.Parameters.Add(new SqlParameter("@freeGWquantity", sciadvisorObj.freeGWquantity));
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }

        public bool AddRecord(sciadvisor sciadvisorObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " +
                    "sciadvisor(professor, hoursGW, hoursperGW, freeGWquantity, password) " +
                    "VALUES (@professor, @hoursGW, @hoursperGW, @freeGWquantity, @Password )", Con);
                cmd.Parameters.Add(new SqlParameter("@professor", sciadvisorObj.professor));
                cmd.Parameters.Add(new SqlParameter("@hoursGW", sciadvisorObj.hoursGW));
                cmd.Parameters.Add(new SqlParameter("@hoursperGW", sciadvisorObj.hoursperGW));
                cmd.Parameters.Add(new SqlParameter("@takenGWquantity", sciadvisorObj.takenGWquantity));
                cmd.Parameters.Add(new SqlParameter("@freeGWquantity", sciadvisorObj.freeGWquantity));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }

        public bool DeleteRecord(int id, sciadvisor sciadvisorObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM sciadvisor WHERE Id=@ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
    }
}