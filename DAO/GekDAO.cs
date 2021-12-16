using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TermProjectFacultyC.DAO
{
    public class GekDAO : DAO
    {
        public List<gek> GetAllRecords()
        {
            Connect();
            List<gek> infoList = new List<gek>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM gek", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    gek gekObj = new gek();
                    gekObj.id = Convert.ToInt32(reader["id"]);
                    gekObj.lastname = Convert.ToString(reader["lastname"]);
                    gekObj.firstname = Convert.ToString(reader["firstname"]);
                    gekObj.patronymic = Convert.ToString(reader["patronymic"]);
                    gekObj.placeofwork = Convert.ToString(reader["placeofwork"]);
                    gekObj.position = Convert.ToString(reader["position"]);
                    infoList.Add(gekObj);

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

        public gek GetRecord(int id)
        {
            Connect();
            gek gekObj = new gek();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM gek where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                gekObj.id = Convert.ToInt32(reader["id"]);
                gekObj.lastname = Convert.ToString(reader["lastname"]);
                gekObj.firstname = Convert.ToString(reader["firstname"]);
                gekObj.patronymic = Convert.ToString(reader["patronymic"]);
                gekObj.placeofwork = Convert.ToString(reader["placeofwork"]);
                gekObj.position = Convert.ToString(reader["position"]);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return gekObj;
        }

        public bool UpdateRecord(int id, gek gekObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE userrole SET " +
                    " lastname = @lastname " +
                    " firstname = @firstname " +
                    " patronymic = @patronymic " +
                    " placeofwork = @placeofwork " +
                    " position = @position" +
                    " password = @Password" +
                    " WHERE id = @ID ", Con);

                cmd.Parameters.Add(new SqlParameter("@lastname", gekObj.lastname));
                cmd.Parameters.Add(new SqlParameter("@firstname", gekObj.firstname));
                cmd.Parameters.Add(new SqlParameter("@patronymic", gekObj.patronymic));
                cmd.Parameters.Add(new SqlParameter("@placeofwork", gekObj.placeofwork));
                cmd.Parameters.Add(new SqlParameter("@position", gekObj.position));
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

        public bool AddRecord(gek gekObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " +
                    "gek(lastname, firstname, patronymic, position, password) " +
                    "VALUES (@lastname, @firstname, @patronymic, @position, @Password )", Con);
                cmd.Parameters.Add(new SqlParameter("@lastname", gekObj.lastname));
                cmd.Parameters.Add(new SqlParameter("@firstname", gekObj.firstname));
                cmd.Parameters.Add(new SqlParameter("@patronymic", gekObj.patronymic));
                cmd.Parameters.Add(new SqlParameter("@placeofwork", gekObj.placeofwork));
                cmd.Parameters.Add(new SqlParameter("@position", gekObj.position));
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

        public bool DeleteRecord(int id, gek gekObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM gek WHERE Id=@ID", Con);
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