using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_banco_Crude_
{
    public partial class Form1 : Form
    {
        string conexao = ConfigurationManager.ConnectionStrings["bd_loja"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }
      public void listarFornecedores2()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(conexao);

                string sql_select_fornecedores = "select * from tb_fornecedores";

                MySqlCommand executacmdMySql_select = new MySqlCommand(sql_select_fornecedores, con);

                con.Open();
                executacmdMySql_select.ExecuteNonQuery();

                DataTable tabela_fornecedores = new DataTable();

                MySqlDataAdapter da_fornecedores = new MySqlDataAdapter(executacmdMySql_select);

                da_fornecedores.Fill(tabela_fornecedores);

                DgvListarFornecedores.DataSource = tabela_fornecedores;

                con.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Deu um erro" + erro);

            }




        }



        private void listarFornecedores()
        {
            listarFornecedores2();
        }

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    MySqlConnection con = new MySqlConnection(conexao);



                    int codigo;
                    string nome;
                    string cnpj;
                    string email;
                    string telefone;
                    string celular;
                    string cep;
                    string endereco;
                    int numero;
                    string complemento;
                    string bairro;
                    string cidade;
                    string estado;

                    codigo = int.Parse(txtcodigo.Text);
                    nome = txtnome.Text;
                    cnpj = txtcnpj.Text;
                    email = txtemail.Text;
                    telefone = txttel.Text;
                    celular = txtcelular.Text;
                    cep = txtcep.Text;
                    endereco = txtend.Text;
                    numero = int.Parse(txtnumero.Text);
                    complemento = txtcomplemento.Text;
                    bairro = txtbairro.Text;
                    cidade = txtcidade.Text;
                    estado = txtestado.Text;



                    string sql_insert = @"insert into tb_fornecedores
(tb_fornecedores_nome, 
tb_fornecedores_cnpj,
tb_fornecedores_email,
tb_fornecedores_telefone ,
tb_fornecedores_celular,
tb_fornecedores_cep,
tb_fornecedores_endereco,
tb_fornecedores_numero,
tb_fornecedores_complemento,
tb_fornecedores_bairro,
tb_fornecedores_cidade, 
tb_fornecedores_estado)
values (@fornecedores_nome, @fornecedores_cnpj,@fornecedores_email, @fornecedores_telefone, @fornecedores_celular, 
@fornecedores_cep, @fornecedores_endereco, @fornecedores_numero, @fornecedores_complemento, @fornecedores_bairro,
@fornecedores_cidade, @fornecedores_estado)";


                    MySqlCommand executacmdMsql_insert = new MySqlCommand(sql_insert, con);
                    executacmdMsql_insert.Parameters.AddWithValue("@fornecedores_nome", nome);
                    executacmdMsql_insert.Parameters.AddWithValue("@fornecedores_cnpj", cnpj);
                    executacmdMsql_insert.Parameters.AddWithValue("@fornecedores_email", email);
                    executacmdMsql_insert.Parameters.AddWithValue("@fornecedores_telefone", telefone);
                    executacmdMsql_insert.Parameters.AddWithValue("@fornecedores_celular", celular);
                    executacmdMsql_insert.Parameters.AddWithValue("@fornecedores_cep", cep);
                    executacmdMsql_insert.Parameters.AddWithValue("@fornecedores_endereco", endereco);
                    executacmdMsql_insert.Parameters.AddWithValue("@fornecedores_numero", numero);
                    executacmdMsql_insert.Parameters.AddWithValue("@fornecedores_complemento", complemento);
                    executacmdMsql_insert.Parameters.AddWithValue("@fornecedores_bairro", bairro);
                    executacmdMsql_insert.Parameters.AddWithValue("@fornecedores_cidade", cidade);
                    executacmdMsql_insert.Parameters.AddWithValue("@fornecedores_estado", estado);



                    con.Open();


                    executacmdMsql_insert.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("Fornecedor cadastrado com Sucesso!");

                    listarFornecedores2();

                }
                catch (Exception erro)
                {

                    MessageBox.Show("Deu um erro:" + erro);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listarFornecedores();
        }

        private void btnalterar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(conexao);


                int id;
                string nome;
                string cnpj;
                string email;
                string telefone;
                string celular;
                string cep;
                string endereco;
                int numero;
                string complemento;
                string bairro;
                string cidade;
                string estado;

                id = int.Parse(txtcodigo.Text);
                nome = txtnome.Text;
                cnpj = txtcnpj.Text;
                email = txtemail.Text;
                telefone = txttel.Text;
                celular = txtcelular.Text;
                cep = txtcep.Text;
                endereco = txtend.Text;
                numero = int.Parse(txtnumero.Text);
                complemento = txtcomplemento.Text;
                bairro = txtbairro.Text;
                cidade = txtcidade.Text;
                estado = txtestado.Text;



                string sql_update_fornecedores = @"update tb_fornecedores 
set  tb_fornecedores_nome = @fornecedores_nome , 
tb_fornecedores_cnpj = @fornecedores_cnpj ,
tb_fornecedores_email = @fornecedores_email ,
tb_fornecedores_telefone = @fornecedores_telefone ,
tb_fornecedores_celular = @fornecedores_celular,
tb_fornecedores_cep = @fornecedores_cep ,
tb_fornecedores_endereco = @fornecedores_endereco ,
tb_fornecedores_numero = @fornecedores_numero ,
tb_fornecedores_complemento = @fornecedores_complemento ,
tb_fornecedores_bairro = @fornecedores_bairro ,
tb_fornecedores_cidade = @fornecedores_cidade ,  
tb_fornecedores_estado = @fornecedores_estado 

where tb_fornecedores_id = @fornecedores_id";




                MySqlCommand executacmdMsql_update = new MySqlCommand(sql_update_fornecedores, con);
                executacmdMsql_update.Parameters.AddWithValue("@fornecedores_nome", nome);
                executacmdMsql_update.Parameters.AddWithValue("@fornecedores_cnpj", cnpj);
                executacmdMsql_update.Parameters.AddWithValue("@fornecedores_email", email);
                executacmdMsql_update.Parameters.AddWithValue("@fornecedores_telefone", telefone);
                executacmdMsql_update.Parameters.AddWithValue("@fornecedores_celular", celular);
                executacmdMsql_update.Parameters.AddWithValue("@fornecedores_cep", cep);
                executacmdMsql_update.Parameters.AddWithValue("@fornecedores_endereco", endereco);
                executacmdMsql_update.Parameters.AddWithValue("@fornecedores_numero", numero);
                executacmdMsql_update.Parameters.AddWithValue("@fornecedores_complemento", complemento);
                executacmdMsql_update.Parameters.AddWithValue("@fornecedores_bairro", bairro);
                executacmdMsql_update.Parameters.AddWithValue("@fornecedores_cidade", cidade);
                executacmdMsql_update.Parameters.AddWithValue("@fornecedores_estado", estado);
                executacmdMsql_update.Parameters.AddWithValue("@fornecedores_id", id);



                con.Open();


                executacmdMsql_update.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Fornecedor alterado com Sucesso!");

                listarFornecedores2();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Deu um erro:" + erro);
            }



        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(conexao);

                int id = int.Parse(txtcodigo.Text);


                string sql_delete_fornecedores = @"delete from tb_fornecedores where tb_fornecedores_id = @fornecedores_id";


                MySqlCommand executacmdMySql_delete = new MySqlCommand(sql_delete_fornecedores, con);
                executacmdMySql_delete.Parameters.AddWithValue("@fornecedores_id", id);



                con.Open();


                executacmdMySql_delete.ExecuteNonQuery();


                con.Close();
                MessageBox.Show("Fornecedor excluido com Sucesso!");

                listarFornecedores2();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Deu um erro:" + erro);
               
            }
        }

        private void DgvListarFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = DgvListarFornecedores.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = DgvListarFornecedores.CurrentRow.Cells[1].Value.ToString();
            txtcnpj.Text = DgvListarFornecedores.CurrentRow.Cells[2].Value.ToString();
            txtemail.Text = DgvListarFornecedores.CurrentRow.Cells[3].Value.ToString();
            txttel.Text = DgvListarFornecedores.CurrentRow.Cells[4].Value.ToString();
            txtcelular.Text = DgvListarFornecedores.CurrentRow.Cells[5].Value.ToString();
            txtcep.Text=  DgvListarFornecedores.CurrentRow.Cells[6].Value.ToString();
            txtend.Text= DgvListarFornecedores.CurrentRow.Cells[7].Value.ToString();
            txtnumero.Text= DgvListarFornecedores.CurrentRow.Cells[8].Value.ToString();
            txtcomplemento.Text= DgvListarFornecedores.CurrentRow.Cells[9].Value.ToString();
            txtbairro.Text = DgvListarFornecedores.CurrentRow.Cells[10].Value.ToString();
            txtcidade.Text= DgvListarFornecedores.CurrentRow.Cells[11].Value.ToString();
            txtestado.Text= DgvListarFornecedores.CurrentRow.Cells[12].Value.ToString();


        }
    }
}
