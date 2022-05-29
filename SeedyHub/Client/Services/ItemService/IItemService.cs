
namespace SeedyHub.Client.Services.ItemService
{
    public interface IItemService
    {
        List<ItemDetails> itemDetails { get; set; }
        List<Category> categories { get; set; }
        Task GetDetails();
        Task GetCategories();
        Task<ItemDetails> GetSingleDetails(int id);
        Task ItemRegistration(ItemDetails items);
        Task UpdateDetails(ItemDetails items);
        Task DeleteDetails(int id);
    }
}
