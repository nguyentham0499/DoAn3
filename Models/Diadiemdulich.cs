using System;
using System.Collections.Generic;

namespace DoAn3.Models
{
    public partial class Diadiemdulich
    {
        public Diadiemdulich()
        {
            Baivietdulich = new HashSet<Baivietdulich>();
        }

        public string DddlMa { get; set; }
        public string DddlTen { get; set; }

        public virtual ICollection<Baivietdulich> Baivietdulich { get; set; }
    }
}
