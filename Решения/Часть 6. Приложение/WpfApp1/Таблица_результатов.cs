//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Таблица_результатов
    {
        public int Код_результата { get; set; }
        public Nullable<int> Код_спортсмена { get; set; }
        public Nullable<int> Общее_количество_попаданий { get; set; }
        public Nullable<int> Общее_количество_захваченных_точек { get; set; }
        public Nullable<int> Общее_количество_устранений { get; set; }
    
        public virtual Cпортсмен Cпортсмен { get; set; }
    }
}
