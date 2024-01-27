using System.ComponentModel.DataAnnotations.Schema;

namespace LuftbornTestApplication.Data
{
    public class Review
    {
        public int ID { set; get; }
        [ForeignKey("ProductOwnerID")]

        public string? ProductOwnerID { set; get; }
        public virtual MarketPlaceUser ProductOwner { set; get; }

        [ForeignKey("ReviewerID")]

        public string? ReviewerID { set; get; }
        public virtual MarketPlaceUser Reviewer { set; get; }



        public string? Comment { set; get; }
        public int Stars { set; get; }  
    }
}