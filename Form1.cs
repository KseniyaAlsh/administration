using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; //подключаем модуль, который позволяет использовать ф-ции, команды и методы для работы с базой данных 
namespace DB_Administration
{
    public partial class Form1 : Form
    {
        //строка подключения к базе данных
        public static string connectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Администрация.mdb";
        //создаём переменную для соединения с базой данных
        private OleDbConnection myConnection;
        public Form1()
        
        {
            InitializeComponent();
            //объект, который отвечает за соединение 
            myConnection = new OleDbConnection(connectString);
            myConnection.Open(); //метод Open, которрый отвечает за подключение к базе данных
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "администрацияDataSet.Сотрудники". При необходимости она может быть перемещена или удалена.
            this.сотрудникиTableAdapter.Fill(this.администрацияDataSet.Сотрудники);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ф-ция, которая разрывает соединение с базой данных
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //создаём переменную, которая берёт значение из textbox1 
            int kod = Convert.ToInt32(textBox1.Text);
            //строка с запросом для удаления
            string zapros = "DELETE FROM Сотрудники WHERE [Код сотрудника] = " + kod;
            //для выполнения запроса прописываем команду
            OleDbCommand command = new OleDbCommand(zapros, myConnection);
            command.ExecuteNonQuery();//исполнение запроса
            MessageBox.Show("Данные о сотруднике удалены"); 
            this.сотрудникиTableAdapter.Fill(this.администрацияDataSet.Сотрудники);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox2.Text);
            // строка с запросом для обновления 
            string zapros = "UPDATE Сотрудники SET Телефон = ' " + textBox3.Text + "' WHERE [Код сотрудника] = " + kod;
            OleDbCommand command = new OleDbCommand(zapros, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Номер обновлен");
            this.сотрудникиTableAdapter.Fill(this.администрацияDataSet.Сотрудники);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //связываем form1 c form2
            Form2 f2 = new Form2(); 
            f2.Owner = this;
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //обновляем данные 
            this.сотрудникиTableAdapter.Fill(this.администрацияDataSet.Сотрудники);
        }
    }
}
