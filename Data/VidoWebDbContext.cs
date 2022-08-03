using VidoWebApi.Models;
using Microsoft.EntityFrameworkCore;
namespace VidoWebApi.Data{
    public class VidoWebDbContext : DbContext {
        public VidoWebDbContext(DbContextOptions<VidoWebDbContext> opt):base(opt){
            
        }
        public DbSet<Sinhvien>? tb_sinhvien{get;set;}
    }
}