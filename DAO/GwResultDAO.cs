using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TermProjectFacultyC.DAO
{
    public class GwResultDAO : DAO
    {
        public List<gwresult> GetAllRecords()
        {
            Connect();
            List<gwresult> infoList = new List<gwresult>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM gwresult", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    gwresult gwresultObj = new gwresult();
                    gwresultObj.id = Convert.ToInt32(reader["id"]);
                    gwresultObj.eventid = Convert.ToInt32(reader["eventid"]);
                    gwresultObj.gekid = Convert.ToInt32(reader["gekid"]);
                    gwresultObj.gw = Convert.ToInt32(reader["gw"]);
                    gwresultObj.mark = Convert.ToInt32(reader["mark"]);
                    infoList.Add(gwresultObj);

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

        public gwresult GetRecord(int id)
        {
            Connect();
            gwresult gwresultObj = new gwresult();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM gwresult where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                gwresultObj.id = Convert.ToInt32(reader["id"]);
                gwresultObj.eventid = Convert.ToInt32(reader["eventid"]);
                gwresultObj.gekid = Convert.ToInt32(reader["gekid"]);
                gwresultObj.gw = Convert.ToInt32(reader["gw"]);
                gwresultObj.mark = Convert.ToInt32(reader["mark"]);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return gwresultObj;
        }

        public bool UpdateRecord(int id, gwresult gwresultObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE userrole SET " +
                    " eventid = @eventid " +
                    " gekid = @gekid " +
                    " gw = @gw " +
                    " mark = @mark " +
                    " freeGWquantity = @freeGWquantity" +
                    " password = @Password" +
                    " WHERE id = @ID ", Con);

                cmd.Parameters.Add(new SqlParameter("@eventid", gwresultObj.eventid));
                cmd.Parameters.Add(new SqlParameter("@gekid", gwresultObj.gekid));
                cmd.Parameters.Add(new SqlParameter("@gw", gwresultObj.gw));
                cmd.Parameters.Add(new SqlParameter("@mark", gwresultObj.mark));
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

        public bool AddRecord(gwresult gwresultObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " +
                    "gwresult(eventid, gekid, gw, freeGWquantity, password) " +
                    "VALUES (@eventid, @gekid, @gw, @freeGWquantity, @Password )", Con);
                cmd.Parameters.Add(new SqlParameter("@eventid", gwresultObj.eventid));
                cmd.Parameters.Add(new SqlParameter("@gekid", gwresultObj.gekid));
                cmd.Parameters.Add(new SqlParameter("@gw", gwresultObj.gw));
                cmd.Parameters.Add(new SqlParameter("@mark", gwresultObj.mark));                
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

        public bool DeleteRecord(int id, gwresult gwresultObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM gwresult WHERE Id=@ID", Con);
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