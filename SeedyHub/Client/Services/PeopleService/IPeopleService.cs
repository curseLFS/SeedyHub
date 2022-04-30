
namespace SeedyHub.Client.Services.PeopleService
{
    public interface IPeopleService
    {
        List<Members> members { get; set; }
        List<Role> roles { get; set; }
        Task GetRoles();
        Task GetMembers();
        Task<Members> GetSingleMember(int id);
        Task MemberRegistration(Members members);
        Task UpdateMember(Members members);
        Task DeleteMember(int id);
    }
}
