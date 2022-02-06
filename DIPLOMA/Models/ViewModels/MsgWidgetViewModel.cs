using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Models.ViewModels
{
    public class MsgWidgetViewModel 
    {
        public string Foo { get; set; } = "Hello!";

        public MsgWidget MWidget = new MsgWidget();
        public virtual ICollection<MsgWidgetContent> MsgWidgetContent { get; set; }

        public MsgWidgetViewModel()
        {

        }
    }
}
