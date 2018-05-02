using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Serviço.Modelo;
using App01_ConsultarCEP.Serviço;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Botao.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs args)
        {

            try
            {
                var cep = CEP.Text.Trim();

                if (isValidCep(cep))
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);

                    if(end != null)
                    {
                        Resultado.Text = string.Format("Endereço: {0}, {1} {2}", end.Localidade, end.Uf, end.Logradouro);
                    }
                    else
                    {
                        DisplayAlert("Erro", "O CEP não foi encontrado para o endereço informado: " + cep, "OK");
                    }


                }
            }
            catch(Exception ex)
            {
                DisplayAlert("Erro", "Ocorreu um erro: " + ex.Message, "OK");
            }
        }

        private bool isValidCep(string cep)
        {
            var valido = true;

            //if (cep.Length != 8)
            //{
            //    valido = false;
            //    DisplayAlert("Erro", "O CEP deve conter 8 caracteres", "OK");
            //}

            long cepNovo = 0;

            if (!long.TryParse(cep, out cepNovo))
            {
                valido = false;
                DisplayAlert("Erro", "O CEP deve conter apenas números", "OK");
            }

            return valido;
        }
    }
}
