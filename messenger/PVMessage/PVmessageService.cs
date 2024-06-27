using Microsoft.EntityFrameworkCore;

namespace messenger.PVMessage;

public class PVmessageService
{
    private readonly AppDbContext _appDbContext;

    public PVmessageService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<PVMessage> Create(PVMessage pvMessage)
    {
        _appDbContext.PVMessages.Add(pvMessage);
        await _appDbContext.SaveChangesAsync();
        return pvMessage;
    }

    public async Task<List<PVMessage>> FindAll()
    {
        return await _appDbContext.PVMessages.ToListAsync();
    }

    public async Task<PVMessage> FindOne(int PVID, int MessageID)
    {
        return await _appDbContext.PVMessages.FindAsync(PVID, MessageID);
    }
}