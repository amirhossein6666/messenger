using messenger;
using Microsoft.EntityFrameworkCore;

namespace  PV;

public class PVService
{
    private readonly AppDbContext _appDbContext;

    public PVService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<PV> Create(PV pv)
    {
        _appDbContext.PVs.Add(pv);
        await _appDbContext.SaveChangesAsync();
        return pv;
    }

    public async Task<List<PV>> FindAll()
    {
        return await _appDbContext.PVs.ToListAsync();
    }

    public async Task<PV> FindOne(int ID)
    {
        return await _appDbContext.PVs.FindAsync(ID);
    }

    public async Task<PV> Update(PV updatedPV)
    {
        _appDbContext.PVs.Update(updatedPV);
        await _appDbContext.SaveChangesAsync();
        return updatedPV;
    }
}