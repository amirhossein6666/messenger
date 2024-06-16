using Microsoft.EntityFrameworkCore;

namespace messenger.PVAccountMessage;

public class PVAccountMessageService
{
    private readonly PVAccountMessageDbContext _pvAccountMessageDbContext;

    public PVAccountMessageService(PVAccountMessageDbContext pvAccountMessageDbContext)
    {
        _pvAccountMessageDbContext = pvAccountMessageDbContext;
    }

    public async Task<PVAccountMessage> Create(PVAccountMessage pvAccountMessage)
    {
        _pvAccountMessageDbContext.PvAccountMessage.Add(pvAccountMessage);
        await _pvAccountMessageDbContext.SaveChangesAsync();
        return pvAccountMessage;
    }

    public async Task<List<PVAccountMessage>> FindAll()
    {
        return await _pvAccountMessageDbContext.PvAccountMessage.ToListAsync();
    }

    public async Task<PVAccountMessage> FindOne(int PVID, int AccountID, int MessageID)
    {
        return await _pvAccountMessageDbContext.PvAccountMessage.FindAsync(PVID, AccountID, MessageID);
    }

    public async Task<PVAccountMessage> Update(PVAccountMessage updatedPVAccountMessage)
    {
        _pvAccountMessageDbContext.PvAccountMessage.Update(updatedPVAccountMessage);
        await _pvAccountMessageDbContext.SaveChangesAsync();
        return updatedPVAccountMessage;
    }
}