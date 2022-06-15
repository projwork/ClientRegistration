using ClientRegistration.Contract.DataContract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClientRegistration.Repository
{
    public partial class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public virtual DbSet<UserResponseModel>? UserInfo { get; set; }
        public virtual DbSet<Loan>? Loan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserResponseModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("UserInfo");
                entity.Property(e => e.UserName).HasColumnName("UserName");
                entity.Property(e => e.Name).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Surname).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.PersonalNumber).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.DateOfBirth).HasColumnName("DateOfBirth");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("Loan");
                entity.Property(e => e.Id).HasColumnName("LoanId");
                entity.Property(e => e.LoanType).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Amount).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.Currency).IsUnicode(false);
                entity.Property(e => e.Period).IsUnicode(false);
                entity.Property(e => e.Status).IsUnicode(false);

            });

            
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
