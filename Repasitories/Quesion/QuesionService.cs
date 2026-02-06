
using Microsoft.EntityFrameworkCore;

namespace DevNet.Repasitories.Quesion
{
    public class QuesionService : IQuesion
    {
        private readonly AppDbContext _context;
        public QuesionService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddQuesion(Models.Quesion model)
        {
            await _context.Quesions.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuesion(int id)
        {
            var model = await _context.Quesions.FindAsync(id);
            _context.Quesions.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Models.Quesion model)
        {
            _context.Quesions.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Models.Quesion>> GetAllQuesions()
        {
            return await _context.Quesions.ToListAsync();
        }

        public async Task<Models.Quesion> GetQuesionById(int id)
        {
            return await _context.Quesions.FindAsync(id);
        }
    }
}
