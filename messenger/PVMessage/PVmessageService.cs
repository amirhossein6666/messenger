using Microsoft.EntityFrameworkCore;

namespace messenger.PVMessage;

public class PVmessageService
{
    private readonly PVMessageDbContext _pvMessageDbContext;

    public PVmessageService(PVMessageDbContext pvMessageDbContext)
    {
        _pvMessageDbContext = pvMessageDbContext;
    }

    public async Task<PVMessage> Create(PVMessage pvMessage)
    {
        _pvMessageDbContext.PVMessages.Add(pvMessage);
        await _pvMessageDbContext.SaveChangesAsync();
        return pvMessage;
    }

    public async Task<List<PVMessage>> FindAll()
    {
        return await _pvMessageDbContext.PVMessages.ToListAsync();
    }

    public async Task<PVMessage> FindOne(int PVID, int MessageID)
    {
        return await _pvMessageDbContext.PVMessages.FindAsync(PVID, MessageID);
    }
}