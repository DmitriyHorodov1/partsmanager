//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace manager_parts_0._1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class parts_managerEntities1 : DbContext
    {
        private static parts_managerEntities1 _context;
        public parts_managerEntities1()
            : base("name=parts_managerEntities1")
        {
        }

        public static parts_managerEntities1 GetContext()
        {
            if (_context == null)
            {
                _context = new parts_managerEntities1();
            }

            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Контер_агенти> Контер_агенти { get; set; }
        public virtual DbSet<Митниця> Митниця { get; set; }
        public virtual DbSet<Найменування_товарів> Найменування_товарів { get; set; }
        public virtual DbSet<Поставки_товарів> Поставки_товарів { get; set; }
        public virtual DbSet<Працівники> Працівники { get; set; }
        public virtual DbSet<Продаж_товарів> Продаж_товарів { get; set; }
    }
}
