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
    
    public partial class Контер_агенти
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Контер_агенти()
        {
            this.Найменування_товарів = new HashSet<Найменування_товарів>();
            this.Поставки_товарів = new HashSet<Поставки_товарів>();
            this.Продаж_товарів = new HashSet<Продаж_товарів>();
        }
    
        public int code { get; set; }
        public string Назва_товариства { get; set; }
        public string Номер_телефону { get; set; }
        public string Фізична_адресса { get; set; }
        public string Юридична_адресса { get; set; }
        public string ЄРДПОУ { get; set; }
        public string ІНН { get; set; }
        public string Єлектронна_пошта { get; set; }
        public string Особливі_примітки { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Найменування_товарів> Найменування_товарів { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Поставки_товарів> Поставки_товарів { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Продаж_товарів> Продаж_товарів { get; set; }
    }
}
