using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WSArtemisaApi.Models;

namespace WSArtemisaApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<CardBrand> CardBrands { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("branch");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.BusinessName).HasColumnName("business_name");
                entity.Property(e => e.UniqueID).HasColumnName("unique_id");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<CardBrand>(entity =>
            {
                entity.ToTable("card_brand");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Brand).HasColumnName("brand");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Merchant>(entity =>
            {
                entity.ToTable("merchant");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.SellerID).HasColumnName("seller_id");
                entity.Property(e => e.SellerLegalName).HasColumnName("seller_legal_name");
                entity.Property(e => e.SellerDBAName).HasColumnName("seller_dba_name");
                entity.Property(e => e.SellerMCC).HasColumnName("seller_mcc");
                entity.Property(e => e.SellerURL).HasColumnName("seller_url");
                entity.Property(e => e.SellerBusinessRegistrationNumber).HasColumnName("seller_business_registration_number");
                entity.Property(e => e.SellerBusinessPhoneNumber).HasColumnName("seller_business_phone_number");
                entity.Property(e => e.SellerEmailAddress).HasColumnName("seller_email_address");
                entity.Property(e => e.SellerCurrencyCode).HasColumnName("seller_currency_code");
                entity.Property(e => e.SellerStatus).HasColumnName("seller_status");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transactions");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Account).HasColumnName("account");
                entity.Property(e => e.Issuer).HasColumnName("issuer");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.OperationType).HasColumnName("operation_type");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.ResponseCode).HasColumnName("response_code");
                entity.Property(e => e.Response).HasColumnName("response");
                entity.Property(e => e.Branch).HasColumnName("branch");
                entity.Property(e => e.POS).HasColumnName("pos");
                entity.Property(e => e.Reference).HasColumnName("reference");
                entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
