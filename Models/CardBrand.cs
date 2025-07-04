using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSArtemisaApi.Models
{
    [Table("card_brand")]
    public class CardBrand
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("brand")]
        public string Brand { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}