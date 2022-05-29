using Microsoft.AspNetCore.Components;
using System.Net;

namespace SeedyHub.Client.Services.PeopleService
{
    public class PeopleService : IPeopleService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public PeopleService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Members> members { get; set; } = new List<Members>();
        public List<Role> roles { get; set; } = new List<Role>();

        public async Task DeleteMember(int id)
        {
            var result = await _http.DeleteAsync($"api/people/{id}");            
            await SetMembers(result);
        }

        public async Task GetMembers()
        {
            var result = await _http.GetFromJsonAsync<List<Members>>("api/people");
            if (result != null)
                members = result;
        }

        public async Task GetRoles()
        {
            var result = await _http.GetFromJsonAsync<List<Role>>($"api/people/roles");
            if (result != null)
                roles = result;
        }

        public async Task<Members> GetSingleMember(int id)
        {
            var result = await _http.GetFromJsonAsync<Members>($"api/people/{id}");
            if (result != null)
                return result;
            throw new Exception("Member not found!");
        }

        public async Task MemberRegistration(Members member)
        {
           
            var result = await _http.PostAsJsonAsync("api/people", member);
            await SetMembers(result);            
         
        }

        private async Task SetMembers(HttpResponseMessage result)
        {

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var response = await result.Content.ReadFromJsonAsync<List<Members>>();
                members = response;
                //_navigationManager.NavigateTo("people");
                _navigationManager.NavigateTo("employee");
            }
            else 
            {
                var response = ((uint)result.StatusCode);
               // _navigationManager.NavigateTo("member");
                _navigationManager.NavigateTo("employee");
            }
            
        }

        public async Task UpdateMember(Members member)
        {
            var result = await _http.PutAsJsonAsync($"api/people/{member.MemberId}", member);           
            await SetMembers(result);
        }
    }
}
