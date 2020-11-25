using System;
using System.Collections.Generic;

namespace DoAn3.Models
{
    public partial class Quantri
    {
        public Quantri()
        {
            Baivietdulich = new HashSet<Baivietdulich>();
        }

        public string QtEmail { get; set; }
        public string QtMatkhau { get; set; }

        public virtual ICollection<Baivietdulich> Baivietdulich { get; set; }
    }
}
