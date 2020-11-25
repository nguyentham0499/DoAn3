using System;
using System.Collections.Generic;

namespace DoAn3.Models
{
    public partial class Taikhoan
    {
        public Taikhoan()
        {
            Baidanhgia = new HashSet<Baidanhgia>();
        }

        public string TkMa { get; set; }
        public string TkEmail { get; set; }
        public string TkMatkhau { get; set; }
        public string TkHoten { get; set; }

        public virtual ICollection<Baidanhgia> Baidanhgia { get; set; }
    }
}
