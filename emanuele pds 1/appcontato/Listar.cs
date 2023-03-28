using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppContatoForm
{
    public partial class Listar : Form
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;

        public Listar()
        {
            InitializeComponent();
            Conexao();
            CarregarDados();
            CarregarComboBox();

        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=bd_pds;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void CarregarDados()
        {
            DataTable tabela = new DataTable();


            string query = "select * from contato_con";
            var comando = new MySqlCommand(query, conexao);
            var adapter = new MySqlDataAdapter(comando);


            adapter.Fill(tabela);
          //  tabela.Columns["id_con"].ColumnName = "Id";
            tabela.Columns["nome_con"].ColumnName = "Nome";
            tabela.Columns["data_con"].ColumnName = "Data";
            tabela.Columns["sexo_con"].ColumnName = "Sexo";
            tabela.Columns["email_con"].ColumnName = "Email";
            tabela.Columns["telefone_con"].ColumnName = "Telefone";

            dgvContato.DataSource = tabela;

        }
        private void CarregarComboBox()
        {
            DataTable tabela = new DataTable();


            string query = "select * from contato_con";
            var comando = new MySqlCommand(query, conexao);
            var adapter = new MySqlDataAdapter(comando);


            adapter.Fill(tabela);          
            cbListar.DataSource = tabela;
            cbListar.DisplayMember = "nome_con";

        }
    }
}
