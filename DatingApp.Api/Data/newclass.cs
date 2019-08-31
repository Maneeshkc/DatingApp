using Microsoft.EntityFrameworkCore;

namespace DatingApp.Api.Data
{
    public partial class BlogDbContext: DbContext {  
    public BlogDbContext() {}  
    public BlogDbContext(DbContextOptions < BlogDbContext > options): base(options) {}  
}
}