using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class OffersClass
    {
        DBconnection connect = new DBconnection();


        public bool insertoffer(string name, string disc, string price)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `offers`(`name`,`disc`, `price`)" +
        " VALUES (@name, @disc,@price);", connect.getconnection);
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@disc", MySqlDbType.VarChar).Value = disc;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = price;

            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }



        }


        public DataTable getofferlist()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `offers`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

    }
}
