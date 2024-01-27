using LuftbornTestApplication.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTestApplication.Repositories.HelperModels
{
    public class ReviewViewModel
    {
        public int? ID { set; get; }

        public string? ProductOwnerID { set; get; }

        public string? ReviewerID { set; get; }

        public string? Comment { set; get; }
        public int Stars { set; get; }
        public string token { set; get; }
    }
}
