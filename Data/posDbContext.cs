﻿

using POS.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Models.DB;
using POS.Models.DB.Report;

namespace POS.Data
{
   public class posDbContext : IdentityDbContext<ApplicationUser>
    {
        public posDbContext(DbContextOptions<posDbContext> options ) : base (options)
        {

        }
        public virtual DbSet<AccountingManual> AccountingManuals { get; set; } = null!;
        public virtual DbSet<AccountsCurrency> AccountsCurrencies { get; set; } = null!;
        public virtual DbSet<ActivityType> ActivityTypes { get; set; } = null!;
        public virtual DbSet<Bank> Banks { get; set; } = null!;
        public virtual DbSet<BackUpsDb> BackUpsDbs { get; set; } = null!;

        public virtual DbSet<CheckExpensVoucher> CheckExpensVouchers { get; set; } = null!;
        public virtual DbSet<CheckPaycheckVoucher> CheckPaycheckVouchers { get; set; } = null!;
        public virtual DbSet<CompanyProfile> CompanyProfiles { get; set; } = null!;
        public virtual DbSet<CurrenciesExchangeRate> CurrenciesExchangeRates { get; set; } = null!;
        public virtual DbSet<Currency> Currencies { get; set; } = null!;
        public virtual DbSet<DetailedExpensVoucher> DetailedExpensVouchers { get; set; } = null!;
        public virtual DbSet<DetailedJournalEntery> DetailedJournalEnteries { get; set; } = null!;
        public virtual DbSet<DetailedPayCheck> DetailedPayChecks { get; set; } = null!;
        public virtual DbSet<FinalAccountType> FinalAccountTypes { get; set; } = null!;
        public virtual DbSet<FiscalYear> FiscalYears { get; set; } = null!;
        public virtual DbSet<Fund> Funds { get; set; } = null!;
        public virtual DbSet<GeneralLedger> GeneralLedgers { get; set; } = null!;
        public virtual DbSet<JournalEnterieType> JournalEnterieTypes { get; set; } = null!;
        public virtual DbSet<MainExpensVoucher> MainExpensVouchers { get; set; } = null!;
        public virtual DbSet<MainJournalEntery> MainJournalEnteries { get; set; } = null!;
        public virtual DbSet<MainPayCheck> MainPayChecks { get; set; } = null!;
        public virtual DbSet<TransactionsActivity> TransactionsActivities { get; set; } = null!;
        public DbSet<VwUser> VwUsers { get; set; }
        public DbSet<SpGetReport> SpGetReport { get; set; }
        public DbSet<SpGetReport2> SpGetReport2 { get; set; }
        public DbSet<SpGetReport3> SpGetReport3 { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {


            base.OnModelCreating(builder);




            //base.OnModelCreating(modelBuilder);
            builder.Entity<SpGetReport>().HasNoKey().ToSqlQuery("SpGetReport");
            builder.Entity<SpGetReport2>().HasNoKey().ToSqlQuery("SpGetReport2");
            builder.Entity<SpGetReport3>().HasNoKey().ToSqlQuery("SpGetReport3");

            builder.Entity<VwUser>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("VwUsers");
            });

        }
        
       
        
       
    }
}
