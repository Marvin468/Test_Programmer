using Newtonsoft.Json;
using Plugin.Iconize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test_Programmer.Models;
using Test_Programmer.ViewModel;
using Test_WebAPI.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test_Programmer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Homepage : ContentPage
    {
        public Homepage()
        {
            InitializeComponent();
            BindingContext = new AmountToSplit();
        }

        private void TxtAmount_Unfocused(object sender, FocusEventArgs e)
        {
            var amount = Convert.ToDouble(txtAmount.Text);
            var split = Convert.ToDouble(txtDigitAmount.Text);
            var res = split / amount;
            lblresult.Text = "$" + res;
        }
    }
}