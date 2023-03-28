﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppContatoForm
{
    public partial class ContatoForm : Form
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
            string conexaoString = "server=localhost;database=bd_pds;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Conexao();

                if ((!rdSexo1.Checked && !rdSexo2.Checked) || txtNome.Text == string.Empty || txtEmail.Text == string.Empty || txtTelefone.Text == string.Empty)
                {
                    MessageBox.Show(" Termine de preencher todos os campus ♥ ");

                    if (!rdSexo1.Checked && !rdSexo2.Checked)
                    {
                        MessageBox.Show(" Certifique-se de ter marcado todos os campos (sexo) ♥ ");
                    }

                }
                else
                {
                    var nome = txtNome.Text;
                    var data_nasc = dateDataNascimento.Text;
                    var sexo = "Feminino";
                    var email = txtEmail.Text;
                    var telefone = txtTelefone.Text;

                    if (rdSexo1.Checked)
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
            }catch (Exception ex)
            {
                conexao.Close();
                Close();
                MessageBox.Show($"Erro ocorrido ({ex.GetHashCode()})");
            }
        }
    } 
}