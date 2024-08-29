using Form5.Models;
using Microsoft.EntityFrameworkCore;

namespace Form5.Data
{
    public class SafetyService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SafetyService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Safety>> GetAllSafetyForm()
        {
            return await _applicationDbContext.Safety.ToListAsync();
        }
                                                  
        // Add New safety Record
        public async Task<bool> AddNewSafety(Safety safety)
        {
            // Set Id to null to let the database generate it
            //safety.Id = null;

            await _applicationDbContext.Safety.AddAsync(safety);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        //Get safety Record Id

        public async Task<Safety> GetEmployeeById(int id)
        {
            Safety safety = await _applicationDbContext.Safety.FirstOrDefaultAsync(x => x.Id == id);
            return safety;
        }


        //Update safety Data
        public async Task<bool> UpdateSafetyDetails(Safety safety)
        {
            _applicationDbContext.Safety.Update(safety);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        //Delete safety Data
        public async Task<bool> DeleteSafety(Safety safety)
        {
            _applicationDbContext.Safety.Remove(safety);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
      
        public async Task<List<Safety>> SearchSafety(string searchTerm)
        {
            // Perform the search operation based on the searchTerm
            // For example, search by Plant or Department
            return await _applicationDbContext.Safety
                                               .Where(s => s.Plant.Contains(searchTerm))
                                                           //s.Department.Contains(searchTerm)) 
                                               .ToListAsync();
        }

        public async Task<List<Safety>> SearchSafety2(string searchTerm)
        {
            // Perform the search operation based on the searchTerm
            // For example, search by Plant or Department
            return await _applicationDbContext.Safety
                                               .Where(s => //s.Plant.Contains(searchTerm) ||
                                                           s.Department.Contains(searchTerm))
                                               .ToListAsync();
        }

        public async Task<List<Safety>> SearchSafety3(string searchTerm)
        {
            // Perform the search operation based on the searchTerm
            // For example, search by Plant or Department
            return await _applicationDbContext.Safety
    .Where(s => s.ToD.HasValue && EF.Functions.Like(s.ToD.Value.Date.ToString(), $"%{searchTerm}%"))
    .ToListAsync();

        }


        //Search Safety Data

        //    public async Task<bool> SearchSafety(Safety safety)
        //    {

        //    }
    }
}
