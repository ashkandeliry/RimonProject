using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Prototypes;

#nullable disable

namespace UserManagment.Model
{
    public partial class AshkandeliryContext : DbContext
    {
        public AshkandeliryContext()
        {
        }

        public AshkandeliryContext(DbContextOptions<AshkandeliryContext> options)
            : base(options)
        {
        }
        public virtual DbSet<UserData> UserData { get; set; }
        public virtual DbSet<HandledErrorLog> HandledErrorLogs { get; set; }
        public virtual DbSet<LoginTbl> LoginTbls { get; set; }
        public virtual DbSet<OperationLog> OperationLogs { get; set; }
        public virtual DbSet<SeriLog> SeriLogs { get; set; }
        public virtual DbSet<SystemErrorLog> SystemErrorLogs { get; set; }
        public virtual DbSet<TblCityStatus> TblCityStatuses { get; set; }
        public virtual DbSet<UsersTbl> UsersTbls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\;Database=Ashkandeliry;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>().HasNoKey().ToView(null);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<HandledErrorLog>(entity =>
            {
                entity.ToTable("HandledErrorLog");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("کد یکتای جدول");

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("زمان ثبت لاگ");

                entity.Property(e => e.ErrorCode).HasComment("کد خطا");

                entity.Property(e => e.ErrorMessage)
                    .HasMaxLength(300)
                    .HasComment("متن خطا");

                entity.Property(e => e.InnerClassName)
                    .HasMaxLength(300)
                    .HasComment("نام کلاس داخلی");

                entity.Property(e => e.InnerMethodName)
                    .HasMaxLength(300)
                    .HasComment("نام متد داخلی");

                entity.Property(e => e.InnerParameters).HasComment("پارامتر های داخلی");

                entity.Property(e => e.LogMethodId)
                    .HasColumnName("LogMethodID")
                    .HasComment("کد متد - شناسه جدول (LogMethod)");

                entity.Property(e => e.ServiceMethodName)
                    .HasMaxLength(300)
                    .HasComment("استفاده نمی شود");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(300)
                    .HasComment("استفاده نمی شود");

                entity.Property(e => e.ServiceParameters).HasComment("پارامتر ورودی");
            });

            modelBuilder.Entity<LoginTbl>(entity =>
            {
                entity.ToTable("Login_TBL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoginTbls)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Login_TBL_Users_TBL");
            });

            modelBuilder.Entity<OperationLog>(entity =>
            {
                entity.ToTable("OperationLog");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("کد یکتای جدول");

                entity.Property(e => e.Answer).HasComment("جواب متد");

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("زمان ثبت لاگ");

                entity.Property(e => e.ExecuteTime)
                    .HasMaxLength(50)
                    .HasComment("مدت زمان اجرای متد");

                entity.Property(e => e.LogMethodId)
                    .HasColumnName("LogMethodID")
                    .HasComment("کد متد - شناسه جدول (LogMethod)");

                entity.Property(e => e.MethodName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("استفاده نمی شود");

                entity.Property(e => e.Parameters).HasComment("پارامتر داخلی");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("استفاده نمی شود");
            });

            modelBuilder.Entity<SeriLog>(entity =>
            {
                entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<SystemErrorLog>(entity =>
            {
                entity.ToTable("SystemErrorLog");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("کد یکتای جدول");

                entity.Property(e => e.CreateDateTime)
                    .HasColumnType("datetime")
                    .HasComment("زمان ثبت لاگ");

                entity.Property(e => e.ExceptionStr).HasComment("متن خطای سیستمی");

                entity.Property(e => e.InnerClassName)
                    .HasMaxLength(300)
                    .HasComment("نام کلاس داخلی");

                entity.Property(e => e.InnerLineNumber).HasComment("لاین خطا");

                entity.Property(e => e.InnerMethodName)
                    .HasMaxLength(300)
                    .HasComment("نام متد داخلی");

                entity.Property(e => e.InnerParameters).HasComment("پارامتر داخلی");

                entity.Property(e => e.LogMethodId)
                    .HasColumnName("LogMethodID")
                    .HasComment("کد متد - شناسه جدول (LogMethod)");

                entity.Property(e => e.ServiceMethodName)
                    .HasMaxLength(300)
                    .HasComment("استفاده نمی شود");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(300)
                    .HasComment("استفاده نمی شود");

                entity.Property(e => e.ServiceParameters).HasComment("پارامتر ورودی");
            });

            modelBuilder.Entity<TblCityStatus>(entity =>
            {
                entity.ToTable("TBL_CityStatus");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CityStatusNo).HasColumnName("CityStatusNO");
            });

            modelBuilder.Entity<UsersTbl>(entity =>
            {
                entity.ToTable("Users_TBL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.Ssncode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("SSNcode");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
