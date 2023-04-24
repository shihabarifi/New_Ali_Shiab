//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;
//using POS.Models.DB;

//namespace POS.Data
//{
//    public partial class FinContext : DbContext
//    {
//        public FinContext()
//        {
//        }

//        public FinContext(DbContextOptions<FinContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<AccountingManual> AccountingManuals { get; set; } = null!;
//        public virtual DbSet<AccountsCurrency> AccountsCurrencies { get; set; } = null!;
//        public virtual DbSet<ActivityType> ActivityTypes { get; set; } = null!;
//        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
//        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
//        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
//        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
//        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
//        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
//        public virtual DbSet<Bank> Banks { get; set; } = null!;
//        public virtual DbSet<CheckExpensVoucher> CheckExpensVouchers { get; set; } = null!;
//        public virtual DbSet<CheckPaycheckVoucher> CheckPaycheckVouchers { get; set; } = null!;
//        public virtual DbSet<CompanyProfile> CompanyProfiles { get; set; } = null!;
//        public virtual DbSet<CurrenciesExchangeRate> CurrenciesExchangeRates { get; set; } = null!;
//        public virtual DbSet<Currency> Currencies { get; set; } = null!;
//        public virtual DbSet<DetailedExpensVoucher> DetailedExpensVouchers { get; set; } = null!;
//        public virtual DbSet<DetailedJournalEntery> DetailedJournalEnteries { get; set; } = null!;
//        public virtual DbSet<DetailedPayCheck> DetailedPayChecks { get; set; } = null!;
//        public virtual DbSet<FinalAccountType> FinalAccountTypes { get; set; } = null!;
//        public virtual DbSet<FiscalYear> FiscalYears { get; set; } = null!;
//        public virtual DbSet<Fund> Funds { get; set; } = null!;
//        public virtual DbSet<GeneralLedger> GeneralLedgers { get; set; } = null!;
//        public virtual DbSet<JournalEnterieType> JournalEnterieTypes { get; set; } = null!;
//        public virtual DbSet<MainExpensVoucher> MainExpensVouchers { get; set; } = null!;
//        public virtual DbSet<MainJournalEntery> MainJournalEnteries { get; set; } = null!;
//        public virtual DbSet<MainPayCheck> MainPayChecks { get; set; } = null!;
//        public virtual DbSet<TransactionsActivity> TransactionsActivities { get; set; } = null!;
//        public virtual DbSet<VwUser> VwUsers { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-D1HB3FK\\SHIHAB;Initial Catalog=Fin;Integrated Security=True");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<AccountingManual>(entity =>
//            {
//                entity.HasOne(d => d.FinalAccountTypeNavigation)
//                    .WithMany(p => p.AccountingManuals)
//                    .HasForeignKey(d => d.FinalAccountType)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Accounting_Manual_Final_Account_Type");

//                entity.HasOne(d => d.FiscalYearNavigation)
//                    .WithMany(p => p.AccountingManuals)
//                    .HasForeignKey(d => d.FiscalYear)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Accounting_Manual_Fiscal_Year");

//                entity.HasOne(d => d.ParentAccNumberNavigation)
//                    .WithMany(p => p.InverseParentAccNumberNavigation)
//                    .HasForeignKey(d => d.ParentAccNumber)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Accounting_Manual_Accounting_Manual");
//            });

//            modelBuilder.Entity<AccountsCurrency>(entity =>
//            {
//                entity.HasOne(d => d.AccountingManualNavigation)
//                    .WithMany(p => p.AccountsCurrencies)
//                    .HasForeignKey(d => d.AccountingManual)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Accounts_Currencies_Accounting_Manual");

//                entity.HasOne(d => d.CurrenciesNavigation)
//                    .WithMany(p => p.AccountsCurrencies)
//                    .HasForeignKey(d => d.Currencies)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Accounts_Currencies_Currencies");
//            });

//            modelBuilder.Entity<ActivityType>(entity =>
//            {
//                entity.Property(e => e.ActivitTypeId).ValueGeneratedNever();
//            });

//            modelBuilder.Entity<AspNetUser>(entity =>
//            {
//                entity.HasMany(d => d.Roles)
//                    .WithMany(p => p.Users)
//                    .UsingEntity<Dictionary<string, object>>(
//                        "AspNetUserRole",
//                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
//                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
//                        j =>
//                        {
//                            j.HasKey("UserId", "RoleId");

//                            j.ToTable("AspNetUserRoles");
//                        });
//            });

//            modelBuilder.Entity<AspNetUserLogin>(entity =>
//            {
//                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
//            });

//            modelBuilder.Entity<AspNetUserToken>(entity =>
//            {
//                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
//            });

//            modelBuilder.Entity<Bank>(entity =>
//            {
//                entity.Property(e => e.BankId).ValueGeneratedNever();

//                entity.HasOne(d => d.SubAccountingManualNavigation)
//                    .WithMany(p => p.Banks)
//                    .HasForeignKey(d => d.SubAccountingManual)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Banks_Accounting_Manual");
//            });

//            modelBuilder.Entity<CheckExpensVoucher>(entity =>
//            {
//                entity.HasOne(d => d.BanksNavigation)
//                    .WithMany(p => p.CheckExpensVouchers)
//                    .HasForeignKey(d => d.Banks)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Check_Expens_Voucher_Banks");

//                entity.HasOne(d => d.CurrenciesNavigation)
//                    .WithMany(p => p.CheckExpensVouchers)
//                    .HasForeignKey(d => d.Currencies)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Check_Expens_Voucher_Currencies");

//                entity.HasOne(d => d.CurrenciesExchangeRateNavigation)
//                    .WithMany(p => p.CheckExpensVouchers)
//                    .HasForeignKey(d => d.CurrenciesExchangeRate)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Check_Expens_Voucher_Currencies_Exchange_Rate");

//                entity.HasOne(d => d.DebitChildAccountNavigation)
//                    .WithMany(p => p.CheckExpensVouchers)
//                    .HasForeignKey(d => d.DebitChildAccount)
//                    .HasConstraintName("FK_Check_Expens_Voucher_Accounting_Manual");

//                entity.HasOne(d => d.FiscalYearNavigation)
//                    .WithMany(p => p.CheckExpensVouchers)
//                    .HasForeignKey(d => d.FiscalYear)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Check_Expens_Voucher_Fiscal_Year");
//            });

//            modelBuilder.Entity<CheckPaycheckVoucher>(entity =>
//            {
//                entity.HasOne(d => d.BanksNavigation)
//                    .WithMany(p => p.CheckPaycheckVouchers)
//                    .HasForeignKey(d => d.Banks)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Check_Paycheck_Voucher_Banks");

//                entity.HasOne(d => d.CreditChildAccountNavigation)
//                    .WithMany(p => p.CheckPaycheckVouchers)
//                    .HasForeignKey(d => d.CreditChildAccount)
//                    .HasConstraintName("FK_Check_Paycheck_Voucher_Accounting_Manual");

//                entity.HasOne(d => d.CurrenciesNavigation)
//                    .WithMany(p => p.CheckPaycheckVouchers)
//                    .HasForeignKey(d => d.Currencies)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Check_Paycheck_Voucher_Currencies");

//                entity.HasOne(d => d.CurrenciesExchangeRateNavigation)
//                    .WithMany(p => p.CheckPaycheckVouchers)
//                    .HasForeignKey(d => d.CurrenciesExchangeRate)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Check_Paycheck_Voucher_Currencies_Exchange_Rate");

//                entity.HasOne(d => d.FiscalYearNavigation)
//                    .WithMany(p => p.CheckPaycheckVouchers)
//                    .HasForeignKey(d => d.FiscalYear)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Check_Paycheck_Voucher_Fiscal_Year");
//            });

//            modelBuilder.Entity<CompanyProfile>(entity =>
//            {
//                entity.Property(e => e.CompanyProfileId).ValueGeneratedNever();
//            });

//            modelBuilder.Entity<CurrenciesExchangeRate>(entity =>
//            {
//                entity.HasOne(d => d.CurrenciesNavigation)
//                    .WithMany(p => p.CurrenciesExchangeRates)
//                    .HasForeignKey(d => d.Currencies)
//                    .HasConstraintName("FK_Currencies_Exchange_Rate_Currencies");
//            });

//            modelBuilder.Entity<DetailedExpensVoucher>(entity =>
//            {
//                entity.HasOne(d => d.DebitChildAccountNavigation)
//                    .WithMany(p => p.DetailedExpensVouchers)
//                    .HasForeignKey(d => d.DebitChildAccount)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Detailed_Expens_Voucher_Accounting_Manual");

//                entity.HasOne(d => d.MainExpensVoucherNumberNavigation)
//                    .WithMany(p => p.DetailedExpensVouchers)
//                    .HasForeignKey(d => d.MainExpensVoucherNumber)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Detailed_Expens_Voucher_Main_Expens_Voucher");
//            });

//            modelBuilder.Entity<DetailedJournalEntery>(entity =>
//            {
//                entity.HasOne(d => d.CreditChildAccountNavigation)
//                    .WithMany(p => p.DetailedJournalEnteryCreditChildAccountNavigations)
//                    .HasForeignKey(d => d.CreditChildAccount)
//                    .HasConstraintName("FK_Detailed_Journal_Enteries_Accounting_Manual1");

//                entity.HasOne(d => d.CurrenciesNavigation)
//                    .WithMany(p => p.DetailedJournalEnteries)
//                    .HasForeignKey(d => d.Currencies)
//                    .HasConstraintName("FK_Detailed_Journal_Enteries_Currencies");

//                entity.HasOne(d => d.CurrenciesExchangeRateNavigation)
//                    .WithMany(p => p.DetailedJournalEnteries)
//                    .HasForeignKey(d => d.CurrenciesExchangeRate)
//                    .HasConstraintName("FK_Detailed_Journal_Enteries_Currencies_Exchange_Rate");

//                entity.HasOne(d => d.DebitChildAccountNavigation)
//                    .WithMany(p => p.DetailedJournalEnteryDebitChildAccountNavigations)
//                    .HasForeignKey(d => d.DebitChildAccount)
//                    .HasConstraintName("FK_Detailed_Journal_Enteries_Accounting_Manual");

//                entity.HasOne(d => d.MainJournalEnteriesNavigation)
//                    .WithMany(p => p.DetailedJournalEnteries)
//                    .HasForeignKey(d => d.MainJournalEnteries)
//                    .HasConstraintName("FK_Detailed_Journal_Enteries_Main_Journal_Enteries1");
//            });

//            modelBuilder.Entity<DetailedPayCheck>(entity =>
//            {
//                entity.HasOne(d => d.CreditChildAccountNavigation)
//                    .WithMany(p => p.DetailedPayChecks)
//                    .HasForeignKey(d => d.CreditChildAccount)
//                    .HasConstraintName("FK_Detailed_PayCheck_Accounting_Manual");

//                entity.HasOne(d => d.MainPaycheckNavigation)
//                    .WithMany(p => p.DetailedPayChecks)
//                    .HasForeignKey(d => d.MainPaycheck)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Detailed_PayCheck_Detailed_PayCheck");
//            });

//            modelBuilder.Entity<FinalAccountType>(entity =>
//            {
//                entity.Property(e => e.FinalAccountTypeId).ValueGeneratedNever();
//            });

//            modelBuilder.Entity<Fund>(entity =>
//            {
//                entity.Property(e => e.FundsId).ValueGeneratedNever();

//                entity.HasOne(d => d.SubAccountingManualNavigation)
//                    .WithMany(p => p.Funds)
//                    .HasForeignKey(d => d.SubAccountingManual)
//                    .HasConstraintName("FK_Funds_Accounting_Manual");
//            });

//            modelBuilder.Entity<GeneralLedger>(entity =>
//            {
//                entity.HasOne(d => d.AccountingManualNavigation)
//                    .WithMany(p => p.GeneralLedgers)
//                    .HasForeignKey(d => d.AccountingManual)
//                    .HasConstraintName("FK_General_Ledger_Accounting_Manual");

//                entity.HasOne(d => d.CheckExpensVoucherNumberNavigation)
//                    .WithMany(p => p.GeneralLedgers)
//                    .HasForeignKey(d => d.CheckExpensVoucherNumber)
//                    .HasConstraintName("FK_General_Ledger_Check_Expens_Voucher");

//                entity.HasOne(d => d.CheckPayCheckVoucherNumberNavigation)
//                    .WithMany(p => p.GeneralLedgers)
//                    .HasForeignKey(d => d.CheckPayCheckVoucherNumber)
//                    .HasConstraintName("FK_General_Ledger_Check_Paycheck_Voucher");

//                entity.HasOne(d => d.CurrenciesNavigation)
//                    .WithMany(p => p.GeneralLedgers)
//                    .HasForeignKey(d => d.Currencies)
//                    .HasConstraintName("FK_General_Ledger_Currencies");

//                entity.HasOne(d => d.CurrenciesExchangeRateNavigation)
//                    .WithMany(p => p.GeneralLedgers)
//                    .HasForeignKey(d => d.CurrenciesExchangeRate)
//                    .HasConstraintName("FK_General_Ledger_Currencies_Exchange_Rate");

//                entity.HasOne(d => d.FiscalYearNavigation)
//                    .WithMany(p => p.GeneralLedgers)
//                    .HasForeignKey(d => d.FiscalYear)
//                    .HasConstraintName("FK_General_Ledger_Fiscal_Year");

//                entity.HasOne(d => d.MainExpensVoucherNumberNavigation)
//                    .WithMany(p => p.GeneralLedgers)
//                    .HasForeignKey(d => d.MainExpensVoucherNumber)
//                    .HasConstraintName("FK_General_Ledger_Main_Expens_Voucher");

//                entity.HasOne(d => d.MainJournalEnteries)
//                    .WithMany(p => p.GeneralLedgers)
//                    .HasForeignKey(d => d.MainJournalEnteriesId)
//                    .HasConstraintName("FK_General_Ledger_Main_Journal_Enteries");

//                entity.HasOne(d => d.MainPayCheckNumberNavigation)
//                    .WithMany(p => p.GeneralLedgers)
//                    .HasForeignKey(d => d.MainPayCheckNumber)
//                    .HasConstraintName("FK_General_Ledger_Main_PayCheck");
//            });

//            modelBuilder.Entity<JournalEnterieType>(entity =>
//            {
//                entity.Property(e => e.JournalEnterieTypesId).ValueGeneratedNever();
//            });

//            modelBuilder.Entity<MainExpensVoucher>(entity =>
//            {
//                entity.HasKey(e => e.MainExpensVoucherNumber)
//                    .HasName("PK_Main_Expens_Voucher_1");

//                entity.HasOne(d => d.CurrenciesNavigation)
//                    .WithMany(p => p.MainExpensVouchers)
//                    .HasForeignKey(d => d.Currencies)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Main_Expens_Voucher_Currencies");

//                entity.HasOne(d => d.CurrenciesExchangeRateNavigation)
//                    .WithMany(p => p.MainExpensVouchers)
//                    .HasForeignKey(d => d.CurrenciesExchangeRate)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Main_Expens_Voucher_Currencies_Exchange_Rate");

//                entity.HasOne(d => d.FiscalYearNavigation)
//                    .WithMany(p => p.MainExpensVouchers)
//                    .HasForeignKey(d => d.FiscalYear)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Main_Expens_Voucher_Fiscal_Year");

//                entity.HasOne(d => d.FundsNavigation)
//                    .WithMany(p => p.MainExpensVouchers)
//                    .HasForeignKey(d => d.Funds)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Main_Expens_Voucher_Funds");
//            });

//            modelBuilder.Entity<MainJournalEntery>(entity =>
//            {
//                entity.HasKey(e => e.MainJournalEnteriesId)
//                    .HasName("PK_Main_Journal_Enteries_1");

//                entity.HasOne(d => d.FiscalYearNavigation)
//                    .WithMany(p => p.MainJournalEnteries)
//                    .HasForeignKey(d => d.FiscalYear)
//                    .HasConstraintName("FK_Main_Journal_Enteries_Fiscal_Year");

//                entity.HasOne(d => d.JournalEnterieTypesNavigation)
//                    .WithMany(p => p.MainJournalEnteries)
//                    .HasForeignKey(d => d.JournalEnterieTypes)
//                    .HasConstraintName("FK_Main_Journal_Enteries_Journal_Enterie_Types");
//            });

//            modelBuilder.Entity<MainPayCheck>(entity =>
//            {
//                entity.HasKey(e => e.MainPaycheckNumber)
//                    .HasName("PK_Main_PayCheck_1");

//                entity.HasOne(d => d.CurrenciesNavigation)
//                    .WithMany(p => p.MainPayChecks)
//                    .HasForeignKey(d => d.Currencies)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Main_PayCheck_Currencies");

//                entity.HasOne(d => d.CurrenciesExchangeRateNavigation)
//                    .WithMany(p => p.MainPayChecks)
//                    .HasForeignKey(d => d.CurrenciesExchangeRate)
//                    .HasConstraintName("FK_Main_PayCheck_Currencies_Exchange_Rate");

//                entity.HasOne(d => d.FiscalYearNavigation)
//                    .WithMany(p => p.MainPayChecks)
//                    .HasForeignKey(d => d.FiscalYear)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Main_PayCheck_Fiscal_Year");

//                entity.HasOne(d => d.FundsNavigation)
//                    .WithMany(p => p.MainPayChecks)
//                    .HasForeignKey(d => d.Funds)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Main_PayCheck_Funds");
//            });

//            modelBuilder.Entity<TransactionsActivity>(entity =>
//            {
//                entity.Property(e => e.TransactionsActivityId).ValueGeneratedNever();

//                entity.HasOne(d => d.ActivityTypeNavigation)
//                    .WithMany(p => p.TransactionsActivities)
//                    .HasForeignKey(d => d.ActivityType)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Transactions_Activity_Activity_Type");

//                entity.HasOne(d => d.CheckExpensNavigation)
//                    .WithMany(p => p.TransactionsActivities)
//                    .HasForeignKey(d => d.CheckExpens)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Transactions_Activity_Check_Expens_Voucher");

//                entity.HasOne(d => d.CheckPaycheckNavigation)
//                    .WithMany(p => p.TransactionsActivities)
//                    .HasForeignKey(d => d.CheckPaycheck)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Transactions_Activity_Check_Paycheck_Voucher");

//                entity.HasOne(d => d.GeneralLedgerNavigation)
//                    .WithMany(p => p.TransactionsActivities)
//                    .HasForeignKey(d => d.GeneralLedger)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Transactions_Activity_General_Ledger");

//                entity.HasOne(d => d.MainExpensVoucherNavigation)
//                    .WithMany(p => p.TransactionsActivities)
//                    .HasForeignKey(d => d.MainExpensVoucher)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Transactions_Activity_Main_Expens_Voucher");

//                entity.HasOne(d => d.MainJournalEnteriesNavigation)
//                    .WithMany(p => p.TransactionsActivities)
//                    .HasForeignKey(d => d.MainJournalEnteries)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Transactions_Activity_Main_Journal_Enteries");

//                entity.HasOne(d => d.MainPayCheckNavigation)
//                    .WithMany(p => p.TransactionsActivities)
//                    .HasForeignKey(d => d.MainPayCheck)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("FK_Transactions_Activity_Main_PayCheck");
//            });

//            modelBuilder.Entity<VwUser>(entity =>
//            {
//                entity.ToView("VwUsers");
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
