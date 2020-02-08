using Newtonsoft.Json;
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
        public List<VirtualList> MyList;
        public Homepage()
        {
            InitializeComponent();
            MyList = new List<VirtualList>();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                if (GetData.Employes != null)
                {
                    Get();
                }
                else
                {
                    Get();
                }
            }
            catch (Exception)
            {

                await GetData.GetEployees();
                OnAppearing();
            }
        }
        private void Get()
        {
            MyList.Clear();
            foreach (var item in GetData.Employes)
            {
                int idPsotion = item.PositionId.Value;
                int idProfile = item.ProfileId.Value;
                foreach (var itemPs in GetData.Positions.Where(x => x.PositionId == idPsotion))
                {
                    foreach (var itemPf in GetData.Profiles.Where(x => x.ProfileId == idProfile))
                    {
                        MyList.Add(new VirtualList { EmployeeId = item.EmployeeId, EmployeeName = item.EmployeeName, PositionId = itemPs.PositionName, ProfileId = itemPf.ProfileName });
                    }
                }
            }
            ListData.ItemsSource = MyList.ToList();
        }
    }
}