using System;
using System.Collections.Generic;

namespace CoreDriverBackend.Model
{
    public partial class CoreVideo
    {
        public string Prefix { get; set; }
        public string Serial { get; set; }
        public string WholeSerial { get; set; }
        public string ActressName { get; set; }
        public string Tags { get; set; }
        public string MagnetLink { get; set; }
        public string TorrentLink { get; set; }
        public string PictureLink { get; set; }
        public string CompanyName { get; set; }
    }
}
