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
        public string Band { get; set; }
        public string IELTSRequirment { get; set; } = String.Empty;
        public string ListeningBand { get; set; } = String.Empty;
        public string ReadingBand { get; set; } = String.Empty;
        public string WritingBand { get; set; } = String.Empty;
        public string SpeakingBand { get; set; } = String.Empty;
        public decimal Rank { get; set; }
        public decimal Cost { get; set; }
        public string Duration { get; set; }

    }
}
