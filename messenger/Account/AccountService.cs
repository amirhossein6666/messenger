using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace messenger.Account;

public class AccountService
{
    public readonly AccountDbContext _accountDbContext;

    public AccountService(AccountDbContext accountDbContext)
    {
        _accountDbContext = accountDbContext;
    }

    public async Task<Account> Create(Account account)
    {
        _accountDbContext.Account.Add(account);
        await _accountDbContext.SaveChangesAsync();
        return account;
    }

    public async Task<List<Account>> FindAll()
    {
        return await _accountDbContext.Account.ToListAsync();
    }

    public async Task<Account> FindOne(int ID)
    {
        return await _accountDbContext.Account.FindAsync(ID);
    }

    public async Task<Account> Update(Account updatedAccount)
    {
        _accountDbContext.Account.Update(updatedAccount);
        await _accountDbContext.SaveChangesAsync();
        return updatedAccount;
    }

}