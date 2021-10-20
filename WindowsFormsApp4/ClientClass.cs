using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp4
{
   
    class ClientClass
    {
        DBconnection connect = new DBconnection();
        public bool insertclient(string Sur_Name, string First_Name, string Patronymic, string Phon_Num, byte[] Image)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `clients`(`Sur_name`,`First_Name`, `Patronymic`, `Phon_Num`, `Image`)" +
        " VALUES (@Sur_name,@First_Name,@Patronymic,@Phon_Num,@Image);", connect.getconnection);
            command.Parameters.Add("@Sur_Name", MySqlDbType.VarChar).Value = Sur_Name;
            command.Parameters.Add("@First_Name", MySqlDbType.VarChar).Value = First_Name;
            command.Parameters.Add("@Patronymic", MySqlDbType.VarChar).Value = Patronymic;
            command.Parameters.Add("@Phon_Num", MySqlDbType.VarChar).Value = Phon_Num;
            command.Parameters.Add("@Image", MySqlDbType.LongBlob).Value = Image;
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
        public DataTable getclientlist()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `clients`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getregclientlist()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `clients` WHERE  Registered = 'Зарегистрирован'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
