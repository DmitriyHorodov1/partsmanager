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
    
    public partial class Продаж_товарів
    {
        public int code { get; set; }
        public Nullable<System.DateTime> Дата_продажу { get; set; }
        public Nullable<int> Код_контрагента { get; set; }
        public Nullable<int> Код_працівника { get; set; }
        public Nullable<int> Код_товару { get; set; }
        public Nullable<int> Кількість { get; set; }
        public string Cтатус_проплати { get; set; }
        public Nullable<double> Вартість_купленого { get; set; }
        public string Cтатус_доставки { get; set; }
        public Nullable<int> Знижка { get; set; }
        public string Коментар { get; set; }
    
        public virtual Контер_агенти Контер_агенти { get; set; }
        public virtual Найменування_товарів Найменування_товарів { get; set; }
        public virtual Працівники Працівники { get; set; }
    }
}
