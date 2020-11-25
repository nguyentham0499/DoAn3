using System;
using System.Collections.Generic;

namespace DoAn3.Models
{
    public partial class Baivietdulich
    {
        public string BvdlMa { get; set; }
        public string BvdlNoidung { get; set; }
        public int? BvdlLuotthich { get; set; }
        public string BvdlEmailqt { get; set; }
        public string BvdlMadddl { get; set; }
        public string BvdlMatt { get; set; }
        public string BvdlMahinhanh { get; set; }
        public string BvdlMabdg { get; set; }

        public virtual Quantri BvdlEmailqtNavigation { get; set; }
        public virtual Baidanhgia BvdlMabdgNavigation { get; set; }
        public virtual Diadiemdulich BvdlMadddlNavigation { get; set; }
        public virtual Hinhanh BvdlMahinhanhNavigation { get; set; }
        public virtual Tinhthanh BvdlMattNavigation { get; set; }
    }
}
