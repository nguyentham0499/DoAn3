using System;
using System.Collections.Generic;

namespace DoAn3.Models
{
    public partial class Tinhthanh
    {
        public Tinhthanh()
        {
            Baivietdulich = new HashSet<Baivietdulich>();
        }

        public string TtMa { get; set; }
        public string TtTen { get; set; }

        public virtual ICollection<Baivietdulich> Baivietdulich { get; set; }
    }
}
