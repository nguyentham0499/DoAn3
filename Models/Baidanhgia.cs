using System;
using System.Collections.Generic;

namespace DoAn3.Models
{
    public partial class Baidanhgia
    {
        public Baidanhgia()
        {
            Baivietdulich = new HashSet<Baivietdulich>();
        }

        public string BdgMa { get; set; }
        public string BdgNoidung { get; set; }
        public int? BdgLuotthich { get; set; }
        public string BdgTk { get; set; }

        public virtual Taikhoan BdgTkNavigation { get; set; }
        public virtual ICollection<Baivietdulich> Baivietdulich { get; set; }
    }
}
