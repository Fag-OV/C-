using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization; //Para digitar a os valores com "." 2.00! 

namespace COFFE_CET62
{
    public partial class COFFE : Form
    {
        double value = 0;  //Variavel para manipular os valores e ir somando das moedas 
        public COFFE()
        {
            InitializeComponent();

            txt_Total.Focus(); // Inicializa o cursor na Box da moeda.
            txt_Total.Select();


        }



        private void bt_Limpar_Click(object sender, EventArgs e)
        {
            value = 0;  //Esvazia o TXT_TOTAL



            radio_cafe.Checked = false;
            radio_cap.Checked = false;
            radio_choco.Checked = false;
            radio_cha.Checked = false;
            txt_Troco.Text = "";
            txt_Total.Text = "";
            lbl_Moedas.Text = "";


        }

        private void bt_2e_Click(object sender, EventArgs e)
        {

            value += 2.00;

            txt_Total.Text = value.ToString("F2", CultureInfo.InvariantCulture);

        }

        private void bt_1e_Click(object sender, EventArgs e)
        {

            value += 1.00;

            txt_Total.Text = value.ToString("F2", CultureInfo.InvariantCulture);


        }

        private void bt_50c_Click(object sender, EventArgs e)
        {

            value += 0.50;

            txt_Total.Text = value.ToString("F2", CultureInfo.InvariantCulture);

        }

        private void bt_20c_Click(object sender, EventArgs e)
        {

            value += 0.20;

            txt_Total.Text = value.ToString("F2", CultureInfo.InvariantCulture);

        }

        private void bt_10c_Click(object sender, EventArgs e)
        {


            value += 0.10;

            txt_Total.Text = value.ToString("F2", CultureInfo.InvariantCulture);



        }

        private void bt_05c_Click(object sender, EventArgs e)
        {

            value += 0.05;

            txt_Total.Text = value.ToString("F2", CultureInfo.InvariantCulture);


        }

        private void Change(double value)
        {
            double coin1, coin05, coin02, coin01, coin005, rest;
            coin1 = Math.Floor(value / 1.00);
            rest = Math.Round(value % 1.00, 2);

            coin05 = Math.Floor(rest / 0.50);
            rest = Math.Round(rest % 0.50, 2);


            coin02 = Math.Floor(rest / 0.20);
            rest = Math.Round(rest % 0.20, 2);


            coin01 = Math.Floor(rest / 0.10);
            rest = Math.Round(rest % 0.10, 2);

            coin005 = Math.Floor(rest / 0.05);
            rest = Math.Round(rest % 0.05, 2);


            lbl_Moedas.Text = "1€: " + Convert.ToString(coin1) + "\n0.50€: " + Convert.ToString(coin05)
                + "\n0.20€: " + Convert.ToString(coin02) + "\n0.10€: " + Convert.ToString(coin01) + "\n0.05: " +
                Convert.ToString(coin005);
            lbl_Moedas.Visible = true;

        }


        private void Limpa_Moedas()
        {

            bt_2e.Enabled = false;
            bt_1e.Enabled = false;
            bt_50c.Enabled = false;
            bt_20c.Enabled = false;
            bt_10c.Enabled = false;
            bt_05c.Enabled = false;


            radio_cafe.Enabled = false;
            radio_cap.Enabled = false;
            radio_choco.Enabled = false;
            radio_cha.Enabled = false;



        }

        private void bt_Pagar_Click(object sender, EventArgs e)

        {

            try
            {

                double moeda = 0;
                moeda = double.Parse(txt_Total.Text, CultureInfo.InvariantCulture); //Acrecentando o CultureInfo.InvariantCulture
                                                                                    // Ele irá ler usando o "."


                if (radio_cafe.Checked == true)
                {

                    moeda = moeda - 0.25;

                }
                else if (radio_cap.Checked == true)
                {

                    moeda = moeda - 0.30;
                }
                else if (radio_choco.Checked == true)
                {
                    moeda = moeda - 0.35;
                }
                else if (radio_cha.Checked == true)
                {
                    moeda = moeda - 0.20;
                }
                if (moeda < 0)
                {

                    MessageBox.Show("Valor Insuficiente!");

                    txt_Total.Focus();
                    radio_cafe.Checked = false;
                    radio_cap.Checked = false;
                    radio_choco.Checked = false;
                    radio_cha.Checked = false;


                }

                else
                {
                    //O "F2" dilimitador de casas decimais.
                    txt_Troco.Text = moeda.ToString("F2", CultureInfo.InvariantCulture);

                    Change(moeda);


                }

            }
            catch
            {
                MessageBox.Show("Insira moedas na máquina!");



            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }


}
