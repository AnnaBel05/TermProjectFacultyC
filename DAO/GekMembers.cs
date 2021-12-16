using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TermProjectFacultyC.DAO
{
    public class GekMembers : DAO
    {
        public List<gekmembers> GetAllRecords()
        {
            Connect();

            List<gekmembers> gekmemberss = new List<gekmembers>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM gekmembers", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    gekmembers gekmembersObj = new gekmembers();
                    gekmembersObj.id = Convert.ToInt32(reader["id"]);
                    gekmembersObj.secretary = Convert.ToInt32(reader["secretary"]);
                    gekmembersObj.president = Convert.ToInt32(reader["president"]);
                    gekmembersObj.membersciadv = Convert.ToInt32(reader["membersciadv"]);
                    gekmembersObj.member2 = Convert.ToInt32(reader["member2"]);
                    gekmembersObj.member3 = Convert.ToInt32(reader["member3"]);
                    gekmembersObj.member4 = Convert.ToInt32(reader["member4"]);

                    gekmemberss.Add(gekmembersObj);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                Disconnect();
            }
            return gekmemberss;
        }

        public gekmembers GetRecord(int id)
        {
            Connect();
            gekmembers gekmembersObj = new gekmembers();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM gekmembers where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                gekmembersObj.id = Convert.ToInt32(reader["id"]);
                gekmembersObj.secretary = Convert.ToInt32(reader["secretary"]);
                gekmembersObj.president = Convert.ToInt32(reader["president"]);
                gekmembersObj.membersciadv = Convert.ToInt32(reader["membersciadv"]);
                gekmembersObj.member2 = Convert.ToInt32(reader["member2"]);
                gekmembersObj.member3 = Convert.ToInt32(reader["member3"]);
                gekmembersObj.member4 = Convert.ToInt32(reader["member4"]);

                reader.Close();


            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return gekmembersObj;
        }

        public bool UpdateRecord(int id, gekmembers gekmembersObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE gekmembers SET " +
                    " secretary = @secretary " +
                    " president = @president" +
                    " membersciadv = @membersciadv" +
                    " member2 = @member2 " +
                    " member3 = @member3 " +
                    " member4 = @member4 " +
                    " ifapproved = @Ifapproved " +
                    " WHERE id = @ID ", Con);

                cmd.Parameters.Add(new SqlParameter("@secretary", gekmembersObj.secretary));
                cmd.Parameters.Add(new SqlParameter("@president", gekmembersObj.president));
                cmd.Parameters.Add(new SqlParameter("@membersciadv", gekmembersObj.membersciadv));
                cmd.Parameters.Add(new SqlParameter("@member2", gekmembersObj.member2));
                cmd.Parameters.Add(new SqlParameter("@member3", gekmembersObj.member3));
                cmd.Parameters.Add(new SqlParameter("@member4", gekmembersObj.member4));
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

        public bool AddRecord(gekmembers gekmembersObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " +
                    "gekmembers(secretary, president, membersciadv, " +
                    "member2, member3, member4, ifapproved) " +
                    "VALUES (@secretary, @president, @membersciadv, " +
                    "@member2, @member3, @member4, @Ifapproved)", Con);
                cmd.Parameters.Add(new SqlParameter("@secretary", gekmembersObj.secretary));
                cmd.Parameters.Add(new SqlParameter("@president", gekmembersObj.president));
                cmd.Parameters.Add(new SqlParameter("@membersciadv", gekmembersObj.membersciadv));
                cmd.Parameters.Add(new SqlParameter("@member2", gekmembersObj.member2));
                cmd.Parameters.Add(new SqlParameter("@member3", gekmembersObj.member3));
                cmd.Parameters.Add(new SqlParameter("@member4", gekmembersObj.member4));
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

        public bool DeleteRecord(int id, gekmembers gekmembersObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM gekmembers WHERE Id=@ID", Con);
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