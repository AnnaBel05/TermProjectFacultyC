using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TermProjectFacultyC.DAO
{
    public class EventLogDAO : DAO
    {
        public List<eventlog> GetAllRecords()
        {
            Connect();
            List<eventlog> infoList = new List<eventlog>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM eventlog", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    eventlog eventlogObj = new eventlog();
                    eventlogObj.id = Convert.ToInt32(reader["id"]);
                    eventlogObj.eventdate = Convert.ToDateTime(reader["eventdate"]);
                    eventlogObj.eventplace = Convert.ToInt32(reader["eventplace"]);
                    eventlogObj.responsibleprofessor = Convert.ToInt32(reader["responsibleprofessor"]);
                    eventlogObj.eventdescr = Convert.ToString(reader["eventdescr"]);
                    infoList.Add(eventlogObj);

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

        public eventlog GetRecord(int id)
        {
            Connect();
            eventlog eventlogObj = new eventlog();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM eventlog where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                eventlogObj.id = Convert.ToInt32(reader["id"]);
                eventlogObj.eventdate = Convert.ToDateTime(reader["eventdate"]);
                eventlogObj.eventplace = Convert.ToInt32(reader["eventplace"]);
                eventlogObj.responsibleprofessor = Convert.ToInt32(reader["responsibleprofessor"]);
                eventlogObj.eventdescr = Convert.ToString(reader["eventdescr"]);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return eventlogObj;
        }

        public bool UpdateRecord(int id, eventlog eventlogObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE userrole SET " +
                    " eventdate = @eventdate " +
                    " eventplace = @eventplace " +
                    " responsibleprofessor = @responsibleprofessor " +
                    " eventdescr = @eventdescr " +
                    
                    " password = @Password" +
                    " WHERE id = @ID ", Con);

                cmd.Parameters.Add(new SqlParameter("@eventdate", eventlogObj.eventdate));
                cmd.Parameters.Add(new SqlParameter("@eventplace", eventlogObj.eventplace));
                cmd.Parameters.Add(new SqlParameter("@responsibleprofessor", eventlogObj.responsibleprofessor));
                cmd.Parameters.Add(new SqlParameter("@eventdescr", eventlogObj.eventdescr));
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

        public bool AddRecord(eventlog eventlogObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " +
                    "eventlog(eventdate, eventplace, responsibleprofessor, password) " +
                    "VALUES (@eventdate, @eventplace, @responsibleprofessor, @Password )", Con);
                cmd.Parameters.Add(new SqlParameter("@eventdate", eventlogObj.eventdate));
                cmd.Parameters.Add(new SqlParameter("@eventplace", eventlogObj.eventplace));
                cmd.Parameters.Add(new SqlParameter("@responsibleprofessor", eventlogObj.responsibleprofessor));
                cmd.Parameters.Add(new SqlParameter("@eventdescr", eventlogObj.eventdescr));
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

        public bool DeleteRecord(int id, eventlog eventlogObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM eventlog WHERE Id=@ID", Con);
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