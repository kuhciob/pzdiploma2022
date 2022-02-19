using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Models.ViewModels
{
    public class FormUploadFiles
    {
        
    }
    public class MsgWidgetViewModel 
    {
        public MsgWidget MWidget { get; set; }
        public List<MsgWidgetContent> MsgWidgetContent { get; set; }
        //[Display(Name = "Anim")]
        //[NotMapped]
        //public List<FormUploadFiles> AnimFiles { get; set; }



    }
}
