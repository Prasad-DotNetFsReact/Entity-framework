// DAL1/BatchRepository.cs
using DAL1;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BatchRepository
{
    private readonly ApplicationDbContext _context;

    public BatchRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Create
    public async Task AddBatchAsync(Batch batch)
    {
        _context.Batches.Add(batch);
        await _context.SaveChangesAsync();
    }

    // Read
    public async Task<Batch> GetBatchByIdAsync(int id)
    {
        return await _context.Batches.FindAsync(id);
    }

    public async Task<IEnumerable<Batch>> GetAllBatchesAsync()
    {
        return await _context.Batches.ToListAsync();
    }

    // Update
    public async Task UpdateBatchAsync(Batch batch)
    {
        _context.Batches.Update(batch);
        await _context.SaveChangesAsync();
    }

    // Delete
    public async Task DeleteBatchAsync(int id)
    {
        var batch = await _context.Batches.FindAsync(id);
        if (batch != null)
        {
            _context.Batches.Remove(batch);
            await _context.SaveChangesAsync();
        }
    }
}

