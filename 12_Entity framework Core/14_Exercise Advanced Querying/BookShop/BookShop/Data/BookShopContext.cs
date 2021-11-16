using BookShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class BookShopContext :DbContext
    {
        public BookShopContext()
        {

        }

        public BookShopContext(DbContextOptions<BookShopContext> options)
            :base(options)
        {

        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<BookCategory> GetBookCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DANE\SQLEXPRESS;Database=BookShop;Integrated Security=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.AuthorId);
               
                entity
                .Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsRequired(false)
                .IsUnicode();

                entity
               .Property(a => a.LastName)
               .HasMaxLength(50)
               .IsRequired()
               .IsUnicode();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.BookId);

                entity
                .Property(b => b.Title)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();

                entity
                .Property(b => b.Description)
                .HasMaxLength(1000)
                .IsRequired()
                .IsUnicode();


                entity
                .Property(b => b.ReleaseDate)
                .IsRequired();

                entity
                .Property(b => b.Copies)
                .IsRequired();

                entity
                .Property(b => b.Price)
                .IsRequired();

                entity
                .Property(b => b.EditionType)
                .IsRequired();

                entity
                .Property(b => b.AgeRestriction)
                .IsRequired();

                entity
                .Property(b => b.AuthorId)
                .IsRequired();

            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.CategoryId);

                entity
                .Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();
            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.HasKey(bc => new { bc.BookId, bc.CategoryId });
            });
        }
    }
}
