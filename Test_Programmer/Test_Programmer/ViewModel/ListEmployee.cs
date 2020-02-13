using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Test_Programmer.Models;
using Test_WebAPI.Models;
using Xamarin.Forms;

namespace Test_Programmer.ViewModel
{
    public class ListEmployee : BaseOnPropertyChange
    {
        public ObservableCollection<VirtualList> MyList;
        public static ObservableCollection<Employees> ListEmployees { get; set; }
        public ListEmployee()
        {
            MyList = new ObservableCollection<VirtualList>();
            Init();
        }

        private ObservableCollection<VirtualList> _DataList;

		public ObservableCollection<VirtualList> DataListEmployees
		{
			get { return _DataList; }
			set { _DataList = value; OnPropertyChanged();
			}
		}

        private bool _IsRefresh;

        public bool IsRefresh
        {
            get { return _IsRefresh; }
            set { _IsRefresh = value; OnPropertyChanged(); }
        }


        public async void Init()
        {
            try
            {
                IsRefresh = true;
                await DataEmployeeAccess.GetEployees();
                await GetData.GetPositions();
                await GetData.GetProfiles();
                if (GetData.Positions == null || GetData.Profiles == null || ListEmployees == null)
                {
                    Init();
                }
                else
                {
                    Get();
                }
            }
            catch (Exception)
            {
                Init();
            }
        }
        private void Get()
        {
            MyList.Clear();
            foreach (var item in ListEmployees)
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
            Busy();
            DataListEmployees = MyList;
        }

        private void Busy()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
             {
                 IsRefresh = false;
                 return false;
             });
        }
        public ICommand Update
        {
            get
            {
                return new Command(() =>
                {
                    IsRefresh = true;
                    _ = new ListEmployee();
                });
            }
        }
    }

    public static class DataEmployeeAccess
    {
        public static async Task<ObservableCollection<Employees>> GetEployees()
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    Timeout = TimeSpan.FromSeconds(20)
                };
                var json = await client.GetStringAsync("http://apptests-001-site1.ctempurl.com/api/employees").ConfigureAwait(true);
                ListEmployee.ListEmployees = JsonConvert.DeserializeObject<ObservableCollection<Employees>>(json);
            }
            catch (Exception)
            {

                await App.Current.MainPage.DisplayAlert("Error", "...", "OK");
            }
            return ListEmployee.ListEmployees;
        }
    }
}
