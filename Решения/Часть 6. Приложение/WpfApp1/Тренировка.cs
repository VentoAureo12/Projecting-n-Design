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
    
    public partial class Тренировка
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Тренировка()
        {
            this.Cпортсмен_Тренировка = new HashSet<Cпортсмен_Тренировка>();
            this.Окончанная_тренировка = new HashSet<Окончанная_тренировка>();
            this.Отчёт_о_тренировке = new HashSet<Отчёт_о_тренировке>();
            this.Результат_тренировки = new HashSet<Результат_тренировки>();
        }
    
        public int Код_тренировки { get; set; }
        public Nullable<System.DateTime> Дата_тренировки { get; set; }
        public Nullable<System.TimeSpan> Время_тренировки { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cпортсмен_Тренировка> Cпортсмен_Тренировка { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Окончанная_тренировка> Окончанная_тренировка { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Отчёт_о_тренировке> Отчёт_о_тренировке { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Результат_тренировки> Результат_тренировки { get; set; }
    }
}
