using messenger;
using Microsoft.EntityFrameworkCore;

namespace  Message;

public class MessageService
{
    private readonly AppDbContext _appDbContext;

    public MessageService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Message> Create(Message message)
    {
        _appDbContext.Messages.Add(message);
        await _appDbContext.SaveChangesAsync();
        return message;
    }

    public async Task<List<Message>> FindAll()
    {
        return await _appDbContext.Messages.ToListAsync();
    }

    public async Task<Message> FindOne(int ID)
    {
        return await _appDbContext.Messages.FindAsync(ID);
    }

    public async Task<Message> Update(Message updatedMessage)
    {
        _appDbContext.Messages.Update(updatedMessage);
        await _appDbContext.SaveChangesAsync();
        return updatedMessage;
    }
}