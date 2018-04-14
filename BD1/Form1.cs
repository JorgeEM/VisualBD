using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=PracticaVisual; Uid=root; pwd=;");            
            try
            {
                comboBox1.Text = "Nombres";
                comboBox1.Items.Clear();
                conectar.Open();

                MySqlCommand comando = new MySqlCommand("Select nombre from alumno",conectar);
                MySqlDataReader almacena = comando.ExecuteReader();

                while (almacena.Read())
                {
                    comboBox1.Refresh();
                    comboBox1.Items.Add(almacena.GetValue(0).ToString());
                }
                conectar.Close();
            }
            catch(MySqlException r)
            {
                MessageBox.Show(r.Message);
            }
        }
    }
}
