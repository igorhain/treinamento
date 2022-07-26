﻿using ConsoleIgor;
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
            //AQUI VOCÊ NÃO VAI MAIS CHAMAR O BANCO DIRETAMENTE, QUEM CHAMA A CLASSE BANCO AGORA É O REPOSITORIO DE ATORES
            //COMENTEI SEU CÓDIGO ABAIXO
            //var banco = new Banco();
            //string sql = "INSERTO INTO atores (nome, idade) VALUES ('" + txtAtor + "' '" + txtIdade + "')";
            //banco.ExecuteNonQuery(sql);

            //CRIEI A CLASSE REPOSITORIO DE ATORES NA PASTA REPOSITORIOS
            var repositorioAtores = new RepositorioAtores();
            var ator = new Ator();
            ator.Nome = txtAtor.Text;
            ator.Idade = Convert.ToInt32(txtIdade.Text);
            //AQUI ESTOU CHAMANDO UM MÉTODO DO REPOSITORIO ONDE PASSANDO O ATOR, ELE VAI INSERIR NO BANCO
            repositorioAtores.GravarAtor(ator);
        }

        private void btn_BuscarAtor_Click(object sender, EventArgs e)
        {
            var repositorioAtores = new RepositorioAtores();
            var dataTable = repositorioAtores.BuscarAtorPorNome(textBox1.Text, true);

            dataGridView2.DataSource = dataTable;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var repositorioFilmes = new RepositorioFilmes();
            var filme = new Filme();
            filme.Titulo = txtNome.Text;
            filme.DataLancamento = Convert.ToDateTime(txtData.Text);
            filme.Estudio = txtEstudio.Text;
            filme.Id = Convert.ToInt32(txtId.Text);
            repositorioFilmes.EditarFilmePorNome(filme);
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Enabled = true;
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtData.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtEstudio.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }
    }
}
