using NETCoreMVCProject.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCoreMVCProject.Models
{
    public class Club
    {
        [Key]
        public int Id{ get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }

        //참조만 정의할 경우, db에서 생성되는 외래 키 컬럼 이름을 직접 제어할 수 없다.
        public Address? Address { get; set; }

        public ClubCategory ClubCategory { get; set; }

        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }

        public AppUser? AppUser { get; set; }
        
    }
}
