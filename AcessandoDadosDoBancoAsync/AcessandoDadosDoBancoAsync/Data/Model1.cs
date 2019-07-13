namespace AcessandoDadosDoBancoAsync.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Senha)
                .IsUnicode(false);
        }
    }
}
