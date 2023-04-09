using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace WpfApp1.RegrasDeNegocio
{
    /// <summary>
    /// Lógica interna para Listar.xaml
    /// </summary>
    public partial class Listar : Window
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
            string conexaoString = "server=localhost;database=bd_pds;user=root;password=root;port=3306";
            //string conexaoString = "server=localhost;database=bd_pds;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void CarregarDados()
        {
            Conexao();

            string sql = "select * from contato_con";
            var comando = new MySqlCommand(sql, conexao);
            var leitor = comando.ExecuteReader();

            var lista = new List<Object>();

            while (leitor.Read())
            {
                var contato_con = new
                {
                    id = leitor.GetInt32("id_con"),
                    Nome = leitor.GetString("nome_con"),
                    Email = leitor.GetString("email_con"),
                    Telefone = leitor.GetString("telefone_con"),
                    sexo = leitor.GetString("sexo_con"),
                    Data_Nascimento = leitor.GetString("data_con")
                };
                lista.Add(contato_con);

            }
            leitor.Close();
            DT.ItemsSource = lista;


        }
        private void CarregarComboBox()
        {
            string query = "SELECT nome_con FROM contato_con";
            var comando = new MySqlCommand(query, conexao);
            var adapter = new MySqlDataAdapter(comando);
            var dataTable = new DataTable();

            adapter.Fill(dataTable);
            cbListar.ItemsSource = dataTable.DefaultView;
            cbListar.DisplayMemberPath = "nome_con";


        }

        private void cbListar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}