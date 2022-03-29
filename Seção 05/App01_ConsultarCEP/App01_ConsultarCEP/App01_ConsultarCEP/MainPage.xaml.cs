using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Services.Model;
using App01_ConsultarCEP.Services;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Button.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            Output.Text = null;
            string cep = Input.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco endereco = ViaCEPServices.BuscarEnderecoViaCEP(cep);
                    if (endereco != null)
                        Output.Text = String.Format($"Endereço: {endereco.logradouro} de {endereco.bairro}, {endereco.localidade}, {endereco.uf}");
                    else
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado.", "OK");

                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO CRÍTICO", ex.Message, "OK");
                }
            }
        }

        private bool isValidCEP(string cep)
        {
            bool isValid = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter 8 caracteres.", "OK");
                isValid = false;
            }

            int novoCEP = 0;
            if (!int.TryParse(cep, out novoCEP))
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve ser composto apenas por números.", "OK");
                isValid = false;
            }

            return isValid;
        }
    }
}
