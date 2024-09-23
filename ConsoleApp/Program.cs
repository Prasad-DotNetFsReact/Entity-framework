// Program.cs
using System;
using System.Threading.Tasks;
using DAL1;
using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("server=DESKTOP-R35ILM0;database=pract1Db; integrated security =true; TrustServerCertificate = True"))
            .AddScoped<BatchRepository>()
            .BuildServiceProvider();

        using var scope = serviceProvider.CreateScope();
        var batchRepo = scope.ServiceProvider.GetRequiredService<BatchRepository>();

        // Create a new batch
        var newBatch = new Batch
        {
            Name = "Batch 1",
            DateOfStart = DateTime.Now,
            DateOfEnd = DateTime.Now.AddMonths(1),
            Capacity = 30,
            Trainer = "Trainer A"
        };
        await batchRepo.AddBatchAsync(newBatch);

        // Read a batch
        var batch = await batchRepo.GetBatchByIdAsync(newBatch.ID);
        Console.WriteLine($"Batch Name: {batch.Name}");

        // Update a batch
        batch.Name = "Updated Batch 1";
        await batchRepo.UpdateBatchAsync(batch);

        // Delete a batch
        await batchRepo.DeleteBatchAsync(batch.ID);

        // List all batches
        var batches = await batchRepo.GetAllBatchesAsync();
        foreach (var b in batches)
        {
            Console.WriteLine($"Batch Name: {b.Name}");
        }
    }
}

