using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; 

namespace DB_Administration
{
    public partial class Form2 : Form
    {
        //
        public static string connectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Администрация.mdb";
        private OleDbConnection myConnection;
        
        public Form2()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //прописываем переменные
            int kod = Convert.ToInt32(textBox1.Text);
            string name = textBox2.Text;
            string surname = textBox3.Text;
            string otchestvo = textBox4.Text;
            string sex = textBox5.Text;
            string hb = textBox6.Text;
            string adress = textBox7.Text;
            string pasport = textBox8.Text;
            string number = textBox9.Text;
            string family = textBox10.Text;
            //создаём запрос на добавление 
            string zapros = "INSERT INTO Сотрудники VALUES (" + kod + ",'" + name + "', '" + surname + "','" + otchestvo + "','" +
               sex + "','" + hb + "','" + adress + "','" + pasport + "','" + number + "', '" + family + "')";
            //команда для выполения запроса
            OleDbCommand command = new OleDbCommand(zapros, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Сотрудник добавлен");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
