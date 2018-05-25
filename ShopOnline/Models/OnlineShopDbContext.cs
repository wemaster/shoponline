namespace ShopOnline.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext()
            : base("name=OnlineShopDbContext")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TblAbout> TblAbouts { get; set; }
        public virtual DbSet<TblAccount> TblAccounts { get; set; }
        public virtual DbSet<TblBanner> TblBanners { get; set; }
        public virtual DbSet<TblCategory> TblCategories { get; set; }
        public virtual DbSet<TblContact> TblContacts { get; set; }
        public virtual DbSet<TblFeedback> TblFeedbacks { get; set; }
        public virtual DbSet<TblFooter> TblFooters { get; set; }
        public virtual DbSet<TblNote> TblNotes { get; set; }
        public virtual DbSet<TblOderDetail> TblOderDetails { get; set; }
        public virtual DbSet<TblOrder> TblOrders { get; set; }
        public virtual DbSet<TblPer> TblPers { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }
        public virtual DbSet<TblSystemconfig> TblSystemconfigs { get; set; }
        public virtual DbSet<TblTag> TblTags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCategory>()
                .Property(e => e.NameCate)
                .IsFixedLength();

            modelBuilder.Entity<TblCategory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<TblFooter>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<TblOderDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TblProduct>()
                .Property(e => e.Promotion)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TblProduct>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);
        }
    }
}
