using messenger;
using Microsoft.EntityFrameworkCore;

namespace  PVAccountMessage;

public class PVAccountMessageService
{
    private readonly AppDbContext _appDbContext;

    public PVAccountMessageService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<PVAccountMessage> Create(PVAccountMessage pvAccountMessage)
    {
        _appDbContext.PVAccountMessages.Add(pvAccountMessage);
        await _appDbContext.SaveChangesAsync();
        return pvAccountMessage;
    }

    public async Task<List<PVAccountMessage>> FindAll()
    {
        return await _appDbContext.PVAccountMessages.ToListAsync();
    }

    public async Task<PVAccountMessage> FindOne(int PVID, int AccountID, int MessageID)
    {
        return await _appDbContext.PVAccountMessages.FindAsync(PVID, AccountID, MessageID);
    }

    public async Task<PVAccountMessage> Update(PVAccountMessage updatedPVAccountMessage)
    {
        _appDbContext.PVAccountMessages.Update(updatedPVAccountMessage);
        await _appDbContext.SaveChangesAsync();
        return updatedPVAccountMessage;
    }
}