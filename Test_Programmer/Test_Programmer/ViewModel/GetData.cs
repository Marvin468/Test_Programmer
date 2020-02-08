using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test_WebAPI.Models;

namespace Test_Programmer.ViewModel
{
    public static class GetData
    {
        public static List<Employees> Employes { get; set; }
        public static List<Positions> Positions { get; set; }
        public static List<Profiles> Profiles { get; set; }
        public static async Task<List<Employees>> GetEployees()
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    Timeout = TimeSpan.FromSeconds(20)
                };
                var json = await client.GetStringAsync("http://apptests-001-site1.ctempurl.com/api/employees").ConfigureAwait(true);
                Employes = JsonConvert.DeserializeObject<List<Employees>>(json);
                if (Employes!=null)
                {
                    await GetPositions();
                }
            }
            catch (Exception)
            {

                await App.Current.MainPage.DisplayAlert("Error", "...", "OK");
            }
            return Employes;

        }
        public static async Task<List<Positions>> GetPositions()
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    Timeout = TimeSpan.FromSeconds(20)
                };
                var json = await client.GetStringAsync("http://apptests-001-site1.ctempurl.com/api/positions").ConfigureAwait(true);
                Positions = JsonConvert.DeserializeObject<List<Positions>>(json);
                if (Positions != null)
                {
                    await GetProfiles();
                }
            }
            catch (Exception)
            {

                await App.Current.MainPage.DisplayAlert("Error", "...", "OK");
            }
            return Positions;

        }
        public static async Task<List<Profiles>> GetProfiles()
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    Timeout = TimeSpan.FromSeconds(20)
                };
                var json = await client.GetStringAsync("http://apptests-001-site1.ctempurl.com/api/profiles").ConfigureAwait(true);
                Profiles = JsonConvert.DeserializeObject<List<Profiles>>(json);
            }
            catch (Exception)
            {

                await App.Current.MainPage.DisplayAlert("Error", "...", "OK");
            }
            return Profiles;

        }
    }
}
