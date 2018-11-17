using System;
using System.Collections.Generic;

namespace CoreDriverBackend.Model
{
    public partial class CoreVideo
    {
        public string Prefix { get; set; }
        public long Serial { get; set; }
        public string WholeSerial { get; set; }
        public string ActressId { get; set; }
        public string Tag { get; set; }
        public string MagnetLink { get; set; }
        public string TorrentLink { get; set; }
        public string PictureLink { get; set; }
        public string CompanyName { get; set; }
    }
}
