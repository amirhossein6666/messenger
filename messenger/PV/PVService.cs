using Microsoft.EntityFrameworkCore;

namespace messenger.PV;

public class PVService
{
    private readonly PVDbContext _pvDbContext;

    public PVService(PVDbContext pvDbContext)
    {
        _pvDbContext = pvDbContext;
    }

    public async Task<PV> Create(PV pv)
    {
        _pvDbContext.PV.Add(pv);
        await _pvDbContext.SaveChangesAsync();
        return pv;
    }

    public async Task<List<PV>> FindAll()
    {
        return await _pvDbContext.PV.ToListAsync();
    }

    public async Task<PV> FindOne(int ID)
    {
        return await _pvDbContext.PV.FindAsync(ID);
    }

    public async Task<PV> Update(PV updatedPV)
    {
        _pvDbContext.PV.Update(updatedPV);
        await _pvDbContext.SaveChangesAsync();
        return updatedPV;
    }
}