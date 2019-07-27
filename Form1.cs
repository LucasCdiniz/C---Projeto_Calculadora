/*Criado e Desenvolvido por Lucas Celestino Diniz
                 lucascelestino.diniz@gmail.com
                 
Windows Form - Calculadora
Operações:
Soma - Subtração - Multiplicação - Divisão - Elevar ao Quadrado - Elevar por um Expoente - Porcentagem - Raiz Quadrada - Troca de Sinal*/

using System;
using System.Windows.Forms;

namespace Projeto_Calculadora
{
    public partial class formCalculadora : Form
    {
        public formCalculadora()
        {
            InitializeComponent();
        }

        private Double numero1;
        private Double numero2;
        private String operacao;
        private Double resultado;
        private Boolean igualPressionado;


        private void formCalculadora_Load(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtbxDisplay.Clear();
            numero1 = 0;
            numero2 = 0;
            operacao = String.Empty;
            igualPressionado = false;
        }

        private void AdicionaCaracterNumerico(String caracter)
        {
            // após realizar a operação igual, ele vai limpar a tela para realizar uma nova operação
            if(igualPressionado == true)
            {
                txtbxDisplay.Clear();
                igualPressionado = false;
            }

            if (txtbxDisplay.Text.Trim().Equals("0"))
            {
                txtbxDisplay.Text = caracter;
            }
            else
            {
                txtbxDisplay.Text = txtbxDisplay.Text + caracter;
            }
        }

        private void GerenciarOperação(String caracter)
        {
            if (!txtbxDisplay.Text.Trim().Equals(String.Empty))
            {
                numero1 = Convert.ToDouble(txtbxDisplay.Text.Trim());
                operacao = caracter;
                txtbxDisplay.Clear();
            }
        }

        private void VerificarZero()
        {
            if(numero2 == 0)
            {
                MessageBox.Show(this.Text, "Erro");
            }
        }


        private void Calcular()
        {
            switch (operacao)
            {
                case "/":
                    VerificarZero();
                    txtbxDisplay.Text = (numero1 / numero2).ToString();
                    break;
                case "X":
                    VerificarZero();
                    txtbxDisplay.Text = (numero1 * numero2).ToString();
                    break;
                case "-":
                    VerificarZero();
                    txtbxDisplay.Text = (numero1 - numero2).ToString();
                    break;
                case "+":
                    VerificarZero();
                    txtbxDisplay.Text = (numero1 + numero2).ToString();
                    break;
                case "^":
                    VerificarZero();
                    txtbxDisplay.Text = CalcularPortencia().ToString();
                    break;
            }
        }

        public Double CalcularPortencia()
        {
            return Math.Pow(numero1,numero2);
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            if (!txtbxDisplay.Text.Trim().Equals("0"))
            {
                txtbxDisplay.Text += "0";
            }
        }

        private void btnUm_Click(object sender, EventArgs e)
        {
            AdicionaCaracterNumerico("1");
        }

        private void btnDois_Click(object sender, EventArgs e)
        {
            AdicionaCaracterNumerico("2");
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            AdicionaCaracterNumerico("3");
        }

        private void btnQuatro_Click(object sender, EventArgs e)
        {
            AdicionaCaracterNumerico("4");
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            AdicionaCaracterNumerico("5");
        }

        private void bnSeis_Click(object sender, EventArgs e)
        {
            AdicionaCaracterNumerico("6");
        }

        private void btnSete_Click(object sender, EventArgs e)
        {
            AdicionaCaracterNumerico("7");
        }

        private void btnOito_Click(object sender, EventArgs e)
        {
            AdicionaCaracterNumerico("8");
        }

        private void btnNove_Click(object sender, EventArgs e)
        {
            AdicionaCaracterNumerico("9");
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            GerenciarOperação("/");
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            GerenciarOperação("X");
        }

        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            GerenciarOperação("-");
        }

        private void btnSoma_Click(object sender, EventArgs e)
        {
            GerenciarOperação("+");
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (igualPressionado)
            {
                txtbxDisplay.Clear();
                igualPressionado = false;
            }
            if (!txtbxDisplay.Text.Trim().Equals(String.Empty))
            {
                numero2 = Convert.ToDouble(txtbxDisplay.Text.Trim());
                Calcular();
                igualPressionado = true;
            }
        }

        private void btnVirgula_Click(object sender, EventArgs e)
        {
            //Verificar se tem algo no Display
            if (txtbxDisplay.Text.Trim().Equals(String.Empty)) txtbxDisplay.Text = "0,";
            //Verifica se já tem uma Vírgula
            if (txtbxDisplay.Text.Trim().Contains(",")) return;
            txtbxDisplay.Text += ",";
            //Após realizar a operação (após clicar no igual) e clicar na vírgula logo em seguida, vai apresentar o 0,
            if (igualPressionado)
            {
                txtbxDisplay.Text = "0,";
                igualPressionado = false;
                return;
            }

        }

        private void btnC_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        //limpar o último valor lido
        private void btnCE_Click(object sender, EventArgs e)
        {
            if (operacao.Equals(String.Empty) || igualPressionado)
            {
                LimparCampos();
            }
            else
            {
                txtbxDisplay.Clear();
            }
        }

        private void btnTrocaDeSinal_Click(object sender, EventArgs e)
        {
            if (!txtbxDisplay.Text.Trim().Equals(String.Empty))
            {
                txtbxDisplay.Text = (Convert.ToDouble(txtbxDisplay.Text.Trim()) * (-1)).ToString();
            }
        }

        private void btnElevaAoQuadrado_Click(object sender, EventArgs e)
        {
            if (!txtbxDisplay.Text.Trim().Equals(String.Empty))
            {
                numero1 = Convert.ToDouble(txtbxDisplay.Text.Trim());
                numero2 = 2;
                resultado = CalcularPortencia();

                txtbxDisplay.Text = resultado.ToString();
                igualPressionado = true;
            }
        }

        private void btnRaizQuadrada_Click(object sender, EventArgs e)
        {
            GerenciarOperação("^");
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            if (!txtbxDisplay.Text.Trim().Equals(String.Empty))
            {
                numero1 = Convert.ToDouble(txtbxDisplay.Text.Trim());
                resultado = Math.Sqrt(numero1);

                txtbxDisplay.Text = resultado.ToString();
                igualPressionado = true;
            }
        }

        private void btnPorcentagem_Click(object sender, EventArgs e)
        {
            if (!txtbxDisplay.Text.Trim().Equals(String.Empty))
            {
                numero1 = Convert.ToDouble(txtbxDisplay.Text.Trim());
                resultado = numero1 / 100;

                txtbxDisplay.Text = resultado.ToString();
                igualPressionado = true;
            }
        }



        /*private void btnRemoveUlimoDigito_Click(object sender, EventArgs e)
         * {
         *    int tamanho = txtDisplay.text.Trim().Length;
         *    String texto = txtDisplay.text.Trim();
         *    txtDisplay.Clear();
         *    for(int i = 0; i < tamanho; i++)
         *    {
         *      txtDisplay.text += texto[i];
         *    }
         * }     
         */

        /*private void btnRemoveUlimoDigito_Click(object sender, EventArgs e)
         * {
                nummero1 = Convert.ToDouble(txtDisplay.Text.Trim());
                if(numero1 == 0)
                {
                    MessageBox.Show("Erro, não é possível realizar divisão por zero");
                    return;

                }
                resultado = 1 / numero1;
                txtbxDisplay.Text = resultado.ToString();
                igualPressionado = true;
           }     */
    }
}
