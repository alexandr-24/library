//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace library
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fine
    {
        public int ID_Book { get; set; }
        public int ID_Reader { get; set; }
        public System.DateTime Date_of_issue { get; set; }
        public Nullable<System.DateTime> Return_date { get; set; }
        public string Status { get; set; }
        public bool Book_is_lost { get; set; }
        public decimal Fine1 { get; set; }
    
        public virtual Subscription Subscription { get; set; }
    }
}
