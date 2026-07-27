using ix.DataSource.Abstractions;
using ix.DataSource.Context;
using ix.DataSource.Models;
using ix.Domain.Abstractions;
using ix.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ix.DataSource.Repositories;

public class PostgresRepository(
    AppDbContext _context,
    ITimeScaleMapper _mapper
    ) : IRepository
{
    public async Task<bool> AddAsync(string fileName, IEnumerable<TimeScale> timeScalse)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var existingFile = await _context.Files
                .FirstOrDefaultAsync(f => f.FileName == fileName);
            if (existingFile != null)
            {
                _context.Files.Remove(existingFile);
                await _context.SaveChangesAsync();
            }

            FileEntity fileEntity = new (fileName);

            foreach (var domain in timeScalse)
            {
                fileEntity.Values.Add(_mapper.ToDataSource(domain));
            }

            await _context.Files.AddAsync(fileEntity);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }
}
