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
    using System.Collections.Generic;
    
    public partial class Найменування_товарів
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Найменування_товарів()
        {
            this.Поставки_товарів = new HashSet<Поставки_товарів>();
            this.Продаж_товарів = new HashSet<Продаж_товарів>();
        }
    
        public int code { get; set; }
        public Nullable<int> Код_товару { get; set; }
        public string Назва { get; set; }
        public Nullable<int> Каталожний_номер { get; set; }
        public Nullable<double> Ціна { get; set; }
        public string Одиниця_виміру { get; set; }
        public Nullable<double> Вага { get; set; }
        public string Країна_виробник { get; set; }
        public string Бренд { get; set; }
        public Nullable<int> Кількість_товарів { get; set; }
        public Nullable<int> Код_постачальника { get; set; }
        public string Примітка { get; set; }
    
        public virtual Контер_агенти Контер_агенти { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Поставки_товарів> Поставки_товарів { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Продаж_товарів> Продаж_товарів { get; set; }
    }
}
