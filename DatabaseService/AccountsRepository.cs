using Data;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService;

public class AccountsRepository(AppContext context) {
    public async Task CreateAccountAsync(Account account, CancellationToken cancellationToken = default) {
        await context.Accounts.AddAsync(account, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Account?> GetAccountAsync(string username, CancellationToken cancellationToken = default) {
        return await context.Accounts.FirstOrDefaultAsync(
            it => it.Username == username,
            cancellationToken
        );
    }
}