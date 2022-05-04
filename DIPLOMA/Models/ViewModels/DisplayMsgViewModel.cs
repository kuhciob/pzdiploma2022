using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Models.ViewModels
{
    public class MsgWidgetContentViewModel
    {
        public string SoundSrc { get; set; }
        public byte[] SoundData { get; set; }
        public string AnimSrc { get; set; }
    }
    public class DisplayMsgViewModel
    {
        public MsgWidget MWidget { get; set; }
        public TextStyle TextStyle { get; set; }

        public List<MsgWidgetContentViewModel> Content { get; set; }
    }
}
