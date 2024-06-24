using Microsoft.EntityFrameworkCore;

namespace  Message;

public class MessageService
{
    private readonly MessageDbContext _messageDbContext;

    public MessageService(MessageDbContext messageDbContext)
    {
        _messageDbContext = messageDbContext;
    }

    public async Task<Message> Create(Message message)
    {
        _messageDbContext.Message.Add(message);
        await _messageDbContext.SaveChangesAsync();
        return message;
    }

    public async Task<List<Message>> FindAll()
    {
        return await _messageDbContext.Message.ToListAsync();
    }

    public async Task<Message> FindOne(int ID)
    {
        return await _messageDbContext.Message.FindAsync(ID);
    }

    public async Task<Message> Update(Message updatedMessage)
    {
        _messageDbContext.Message.Update(updatedMessage);
        await _messageDbContext.SaveChangesAsync();
        return updatedMessage;
    }
}