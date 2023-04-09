using System;
using System.Collections.Generic;
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
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;


namespace WpfApp1.RegrasDeNegocio
{
    /// <summary>
    /// Lógica interna para ContatoForm.xaml
    /// </summary>
    public partial class ContatoForm : Window
    {

        private MySqlConnection conexao;

        private MySqlCommand comando;


        public ContatoForm()
        {
            InitializeComponent();
            Conexao();
        }

            private void Conexao()
            {
                string conexaoString = "server=localhost;database=bd_pds;user=root;password=root;port=3306";
                conexao = new MySqlConnection(conexaoString);
                comando = conexao.CreateCommand();

                conexao.Open();
            }

            private void btnSalvar_Click(object sender, EventArgs e)
            {
                try
                {

                bool masc = Convert.ToBoolean(rdSexo1.IsChecked); 
                bool fem = Convert.ToBoolean(rdSexo2.IsChecked); 

                if (txtNome.Text == string.Empty || txtEmail.Text == string.Empty || txtTelefone.Text == string.Empty)
                {
                    MessageBox.Show(" Termine de preencher todos os campos ♥ ");
                }else 

                    if (!masc && !fem)
                    {
                        MessageBox.Show(" Termine de preencher todos os campos ♥ ");
                    }
                
                else {

                        var nome = txtNome.Text;
                        var data_nasc = dateDataDeNascimento;
                        var sexo = "Feminino";
                        var email = txtEmail.Text;
                        var telefone = txtTelefone.Text;

                            if (masc == true)
                            {
                                sexo = "Masculino";
                            }

                        string query = "insert into contato_con (nome_con, data_con, sexo_con, email_con, telefone_con) VALUES (@_nome, @_data,  @_sexo, @_email, @_telefone)";
                        var comando = new MySqlCommand(query, conexao);

                        comando.Parameters.AddWithValue("@_nome", nome);
                        comando.Parameters.AddWithValue("@_data", data_nasc);
                        comando.Parameters.AddWithValue("@_sexo", sexo);
                        comando.Parameters.AddWithValue("@_email", email);
                        comando.Parameters.AddWithValue("@_telefone", telefone);

                        comando.ExecuteNonQuery();
                        MessageBox.Show("Salvo com sucesso!");
                        conexao.Close();
                        Close();

                            }
                }
                    catch (Exception ex)
                    {
                        conexao.Close();
                        Close();
                        MessageBox.Show($"Erro ocorrido ({ex.GetHashCode()})");
                    }
            }
    }  
}