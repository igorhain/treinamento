using ConsoleIgor;
using ConsoleIgor.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var repositorioFilmes = new RepositorioFilmes();
            var dataTable = repositorioFilmes.BuscarFilmePorNome(txtFilme.Text, true);

            dataGridView1.DataSource = dataTable;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var banco = new Banco();
            string sql = "INSERTO INTO atores (nome, idade) VALUES ('" + txtAtor + "' '" + txtIdade + "')";
            banco.ExecuteNonQuery(sql);




        }
    }
}
