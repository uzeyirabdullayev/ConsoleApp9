using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        public static object InsertCommand { get; private set; }
        public static object locko = new object();
        static void Main(string[] args)
        {
            SqlConnection conn;
            SqlCommand command;
            SqlDataReader result;
            List<string> StackList = new List<string>();
            StreamReader rd = new StreamReader("stack_items.txt");

            Task t1 = Task.Run(() =>
            {
                while (rd.ReadLine() != null)
                {
                    StackList.Add(rd.ReadLine());
                }
            });

            Task t2 = Task.Run(() =>
            {
                lock (locko)
                {
                    StringBuilder insertcommand = new StringBuilder();

                    foreach (var item in StackList)
                    {
                        insertcommand.Append("INSERT INTO Stackable (items) " + $" values ('{item}');");
                    }

                    conn = new SqlConnection("Data Source=192.168.19.35\\SQLEXPRESS;Initial Catalog=P504;User ID=sa");
                    command = new SqlCommand(insertcommand.ToString(), conn);

                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            });



            Task t3 = Task.Run(() =>
            {
                lock (locko)
                {
                    StringBuilder insertcommand = new StringBuilder();

                    foreach (var item in StackList)
                    {
                        insertcommand.Append("INSERT INTO Stackable (items) " + $" values ('{item}');");
                    }

                    conn = new SqlConnection("Data Source=192.168.19.35\\SQLEXPRESS;Initial Catalog=P504;User ID=sa");
                    command = new SqlCommand(insertcommand.ToString(), conn);

                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            });

            Task t4 = Task.Run(() =>
            {
                lock (locko)
                {
                    StringBuilder insertcommand = new StringBuilder();

                    foreach (var item in StackList)
                    {
                        insertcommand.Append("INSERT INTO Stackable (items) " + $" values ('{item}');");
                    }

                    conn = new SqlConnection("Data Source=192.168.19.35\\SQLEXPRESS;Initial Catalog=P504;User ID=sa");
                    command = new SqlCommand(insertcommand.ToString(), conn);

                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }

            });
            Task.WaitAll(t2, t3, t4);
        }
    }
}