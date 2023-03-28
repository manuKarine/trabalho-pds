﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppContatoForm.Properties;
using MySql.Data.MySqlClient;

namespace AppContatoForm
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();

        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            var form = new ContatoForm();
            form.ShowDialog();
        }

        private void btListar_Click(object sender, EventArgs e)
        {
            var form = new Listar();
            form.ShowDialog();
        }
    }
}
