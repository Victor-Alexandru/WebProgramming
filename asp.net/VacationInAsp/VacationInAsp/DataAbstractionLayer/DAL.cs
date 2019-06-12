using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using VacationInAsp.Models;
using MySql.Data.MySqlClient;

namespace VacationInAsp.DataAbstractionLayer
{
    public class DAL
    {      
        SqlConnection conn;

        public List<Student> GetStudentsFromGroup(int group_id)
        {
            List<Student> slist = new List<Student>();
            try
            {
                conn = new SqlConnection(@"Data Source = DESKTOP-GMNU3BC\SQLEXPRESS; Initial Catalog =WP; Integrated Security = true");
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "select * from students where group_id=" + group_id;



                SqlDataReader myreader = cmd.ExecuteReader();



                while (myreader.Read())
                {
                    Student stud = new Student();
                    stud.Id = (int)myreader["id"];
                    stud.Nume = (string)myreader["sname"];
                    stud.Password = (string)myreader["spasword"];
                    stud.Group_id = (int)myreader["group_id"];
                    slist.Add(stud);
                }
                myreader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return slist;
        }

        public string DeleteDestination(long id)
        {
            string result = "";

            conn = new SqlConnection(@"Data Source = DESKTOP-GMNU3BC\SQLEXPRESS; Initial Catalog =WP; Integrated Security = true");
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "select * from destination where destination_id=" + id;

            SqlDataReader myreader = cmd.ExecuteReader();


            if (myreader.HasRows)
            {
                myreader.Close();

                SqlCommand deleteCmd = conn.CreateCommand();

                deleteCmd.CommandText = "delete from destination where destination_id  = " + id + ";";

                deleteCmd.ExecuteNonQuery();

                result += "delete success";

            }
            else
            {
                result += "row inexisted";
            }



                return result;
        }

        public string DeleteTarget(long id)
        {
            string result = "";

            conn = new SqlConnection(@"Data Source = DESKTOP-GMNU3BC\SQLEXPRESS; Initial Catalog =WP; Integrated Security = true");
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "select * from dbo.Target where targetId=" + id;

            SqlDataReader myreader = cmd.ExecuteReader();

            if (myreader.HasRows)
            {

                myreader.Close();

                SqlCommand deleteCmd = conn.CreateCommand();

                deleteCmd.CommandText = "delete from dbo.Target where targetId  = " + id + ";";

                deleteCmd.ExecuteNonQuery();

                result += "delete success";
            }
            else
            {
                result += "row inexisted";

            }
            return result;
        }
        public string AddDestination(Destination d)
        {
            conn = new SqlConnection(@"Data Source = DESKTOP-GMNU3BC\SQLEXPRESS; Initial Catalog =WP; Integrated Security = true");
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "select * from destination where destination_id=" + d.destination_id;

            SqlDataReader myreader = cmd.ExecuteReader();

            string result = "";

            if(myreader.HasRows)
            {
                myreader.Close();

                SqlCommand updateCmd = conn.CreateCommand();

                updateCmd.CommandText = "UPDATE destination SET location_name = '" + d.location_name + "', country_name = '" + d.country_name + "', description = '" + d.description + "', cost_per_day = '" + d.cost_per_day + "' WHERE destination.destination_id = " + d.destination_id + ";";

                updateCmd.ExecuteNonQuery();

                result += "update ";    
            }
            else
            {
                myreader.Close();


                SqlCommand insertcmd = conn.CreateCommand();

                insertcmd.CommandText = "INSERT INTO destination VALUES ("+ d.destination_id+ ", '" + d.location_name + "', '" + d.country_name + "', '" + d.description + "', " + d.cost_per_day + ");";

                insertcmd.ExecuteNonQuery();

                result += "insert ";

                

            }


            return result += " Succes";

        }

        public string ValidateData(string user,string pass)
        {
            string result = "";

            conn = new SqlConnection(@"Data Source = DESKTOP-GMNU3BC\SQLEXPRESS; Initial Catalog =WP; Integrated Security = true");
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "  select * from Users where uname='"+user+"' and upass='"+pass+"';";

            SqlDataReader myreader = cmd.ExecuteReader();


            if (myreader.HasRows)
            {

                result += "success";
            }
            else
            {
                result += "error";
            }

                return result;
        }

        public string AddTarget(long target_id,long destination_id,string target_name)
        {
            string result="";

            conn = new SqlConnection(@"Data Source = DESKTOP-GMNU3BC\SQLEXPRESS; Initial Catalog =WP; Integrated Security = true");
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "select * from dbo.Target where targetId=" + target_id;

            SqlDataReader myreader = cmd.ExecuteReader();

            if (myreader.HasRows)
            {
                myreader.Close();

                SqlCommand updateCmd = conn.CreateCommand();

                updateCmd.CommandText = "update dbo.Target set target_name = '" + target_name + "' where targetId= " +target_id + ";";

                updateCmd.ExecuteNonQuery();

                result += "update ";
            }
            else
            {
                myreader.Close();


                SqlCommand insertcmd = conn.CreateCommand();

                insertcmd.CommandText = "insert into dbo.Target values(" + target_id + ", '" +target_name + "',  " + destination_id + ");";

                insertcmd.ExecuteNonQuery();

                result += "insert ";



            }



            return result += " Succes";
        }



        public List<Destination> GetDestinationsFrom(int start,int end)
        {

            List<Destination> dlist = new List<Destination>();

            try
            {
                conn = new SqlConnection(@"Data Source = DESKTOP-GMNU3BC\SQLEXPRESS; Initial Catalog =WP; Integrated Security = true");
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT   * FROM  destination ORDER BY destination_id OFFSET "+ start +" ROWS FETCH NEXT 4 ROWS ONLY;";

                SqlDataReader myreader = cmd.ExecuteReader();



                while (myreader.Read())
                {
                    Destination stud = new Destination();
                    stud.destination_id= (long)myreader["destination_id"];
                    stud.location_name = (string)myreader["location_name"];
                    stud.country_name = (string)myreader["country_name"];
                    stud.description = (string)myreader["description"];
                    stud.cost_per_day = (long)myreader["cost_per_day"];
                    dlist.Add(stud);
                }
                myreader.Close();

                cmd.CommandText = "SELECT   * FROM  destination ORDER BY destination_id OFFSET " + end+ " ROWS FETCH NEXT 4 ROWS ONLY;";

                SqlDataReader newreader = cmd.ExecuteReader();



                while (newreader.Read())
                {
                    Destination stud = new Destination();
                    stud.destination_id = (long)newreader["destination_id"];
                    stud.location_name = (string)newreader["location_name"];
                    stud.country_name = (string)newreader["country_name"];
                    stud.description = (string)newreader["description"];
                    stud.cost_per_day = (long)newreader["cost_per_day"];
                    dlist.Add(stud);
                }
                newreader.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return dlist;


        }

        public List<Destination> GetCustomFrom(int start, int end,string countryName)
        {

            List<Destination> dlist = new List<Destination>();

            try
            {
                conn = new SqlConnection(@"Data Source = DESKTOP-GMNU3BC\SQLEXPRESS; Initial Catalog =WP; Integrated Security = true");
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "select * from dbo.Destination where country_name = '"+ countryName+"' order by destination_id offset "+ start+" ROWS FETCH NEXT 4 ROWS ONLY;";

                SqlDataReader myreader = cmd.ExecuteReader();




                while (myreader.Read())
                {
                    Destination stud = new Destination();
                    stud.destination_id = (long)myreader["destination_id"];
                    stud.location_name = (string)myreader["location_name"];
                    stud.country_name = (string)myreader["country_name"];
                    stud.description = (string)myreader["description"];
                    stud.cost_per_day = (long)myreader["cost_per_day"];
                    dlist.Add(stud);

                }
                myreader.Close();

                cmd.CommandText = "select * from dbo.Destination where country_name = '"+ countryName +"' order by destination_id offset " + end + " ROWS FETCH NEXT 4 ROWS ONLY;";

                SqlDataReader newreader = cmd.ExecuteReader();



                while (newreader.Read())
                {
                    Destination stud = new Destination();
                    stud.destination_id = (long)newreader["destination_id"];
                    stud.location_name = (string)newreader["location_name"];
                    stud.country_name = (string)newreader["country_name"];
                    stud.description = (string)newreader["description"];
                    stud.cost_per_day = (long)newreader["cost_per_day"];
                    dlist.Add(stud);
                }
                newreader.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return dlist;


        }


    }
}