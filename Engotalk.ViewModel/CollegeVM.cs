using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.ViewModel
{
    public class CollegeVM
    {
        public string College { get; set; } 
        public string? Band { get; set; }
        public string? IELTSRequirment { get; set; } 
        public string? ListeningBand { get; set; }
        public string? ReadingBand { get; set; } 
        public string? WritingBand { get; set; } 
        public string? SpeakingBand { get; set; } 
        public decimal Rank { get; set; }
        public decimal Cost { get; set; }
        public string? Duration { get; set; }

    }
}
