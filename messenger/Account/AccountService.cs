using messenger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace  Account;

public class AccountService
{
    private readonly AppDbContext _appDbContext;

    public AccountService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Account> Create(Account account)
    {
        _appDbContext.Accounts.Add(account);
        await _appDbContext.SaveChangesAsync();
        return account;
    }

    public async Task<List<Account>> FindAll()
    {
        return await _appDbContext.Accounts.ToListAsync();
    }

    public async Task<Account> FindOne(int ID)
    {
        return await _appDbContext.Accounts.FindAsync(ID);
    }

    public async Task<Account> Update(Account updatedAccount)
    {
        _appDbContext.Accounts.Update(updatedAccount);
        await _appDbContext.SaveChangesAsync();
        return updatedAccount;
    }

}