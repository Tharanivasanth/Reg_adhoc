using Registration.Models;

namespace Registration.Service
    
{
    public interface IRegisterService
    {

        Task <List<Reg>> GetAllSync();

        Task <Reg> GetById (int id);
        Task InsertAsync(Reg reg);
        Task UpdateAsync(Reg reg);
        Task DeleteAsync(int id);

    }
}
