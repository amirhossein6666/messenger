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
        _appDbContext.PV.Add(pv);
        await _appDbContext.SaveChangesAsync();
        return pv;
    }

    public async Task<List<PV>> FindAll()
    {
        return await _appDbContext.PV.ToListAsync();
    }

    public async Task<PV> FindOne(int ID)
    {
        return await _appDbContext.PV.FindAsync(ID);
    }

    public async Task<PV> Update(PV updatedPV)
    {
        _appDbContext.PV.Update(updatedPV);
        await _appDbContext.SaveChangesAsync();
        return updatedPV;
    }
}