using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models;
using System;

namespace DataFolders.EF
{
    public class FolderContext : DbContext
    {
        private readonly IOptions<RepositoryOptions> _options;
        public FolderContext(IOptions<RepositoryOptions> options)
        {
            _options = options;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_options.Value.DefaultConnectionString);
            //optionsBuilder.UseLazyLoadingProxies();
        }
        public DbSet<Folder> Folders { get; set; }
    }
}
