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
                    " eventdate = @Eventdate " +
                    " eventplace = @Eventplace " +
                    " responsibleprofessor = @Responsibleprofessor " +
                    " eventdescr = @Eventdescr " +
                    " WHERE id = @ID ", Con);

                cmd.Parameters.Add(new SqlParameter("@Eventdate", eventlogObj.eventdate));
                cmd.Parameters.Add(new SqlParameter("@Eventplace", eventlogObj.eventplace));
                cmd.Parameters.Add(new SqlParameter("@Responsibleprofessor", eventlogObj.responsibleprofessor));
                cmd.Parameters.Add(new SqlParameter("@Eventdescr", eventlogObj.eventdescr));
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
                    "eventlog(eventdate, eventplace, responsibleprofessor, eventdescr) " +
                    "VALUES (@Eventdate, @Eventplace, @Responsibleprofessor, @Eventdescr )", Con);
                cmd.Parameters.Add(new SqlParameter("@Eventdate", eventlogObj.eventdate));
                cmd.Parameters.Add(new SqlParameter("@Eventplace", eventlogObj.eventplace));
                cmd.Parameters.Add(new SqlParameter("@Responsibleprofessor", eventlogObj.responsibleprofessor));
                cmd.Parameters.Add(new SqlParameter("@Eventdescr", eventlogObj.eventdescr));
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
                SqlCommand cmd = new SqlCommand("DELETE FROM eventlog WHERE id=@ID", Con);
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