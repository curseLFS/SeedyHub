using Microsoft.AspNetCore.Components;
using System.Net;

namespace SeedyHub.Client.Services.ItemService
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ItemService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<ItemDetails> itemDetails { get; set; } =  new List<ItemDetails>();
        public List<Category> categories { get; set; } = new List<Category>();

        public async Task DeleteDetails(int id)
        {
            var result = await _http.DeleteAsync($"api/item/{id}");
            await SetItemDetails(result);
        }

        public async Task GetCategories()
        {
            var result = await _http.GetFromJsonAsync<List<Category>>($"api/item/categories");
            if (result != null)
                categories = result;
        }

        public async Task GetDetails()
        {
            var result = await _http.GetFromJsonAsync<List<ItemDetails>>("api/item");
            if (result != null)
                itemDetails = result;
        }

        public async Task<ItemDetails> GetSingleDetails(int id)
        {
            var result = await _http.GetFromJsonAsync<ItemDetails>($"api/item/{id}");
            if (result != null)
                return result;
            throw new Exception("Item not found!");
        }

        public async Task ItemRegistration(ItemDetails items)
        {
            if (string.IsNullOrEmpty(items.ItemName)) 
            {
                throw new Exception("No item name being input!");
            }
            //items.ItemName = items.ItemName.Substring(0, 1).ToUpper() + items.ItemName.Substring(1);
            items.ItemName = String.Join(" ", items.ItemName.Split(' ').ToList()
                                   .ConvertAll(w => w.Substring(0, 1).ToUpper() + w.Substring(1)));

            var result = await _http.PostAsJsonAsync("api/item", items);
            await SetItemDetails(result);
        }

        private async Task SetItemDetails(HttpResponseMessage result)
        {
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var response = await result.Content.ReadFromJsonAsync<List<ItemDetails>>();
                itemDetails = response;
                _navigationManager.NavigateTo("inventory");
            }
            else 
            {
                var response = ((uint)result.StatusCode);
                _navigationManager.NavigateTo("inventory");
            }
        }

        public async Task UpdateDetails(ItemDetails items)
        {
            var result = await _http.PutAsJsonAsync($"api/item/{items.ItemId}", items);
            await SetItemDetails(result); 
        }
    }
}
