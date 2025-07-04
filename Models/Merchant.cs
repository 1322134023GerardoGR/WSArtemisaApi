using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSArtemisaApi.Models
{
    [Table("merchant")]
    public class Merchant
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("seller_id")]
        public string SellerID { get; set; }

        [Column("seller_legal_name")]
        public string SellerLegalName { get; set; }

        [Column("seller_dba_name")]
        public string SellerDBAName { get; set; }

        [Column("seller_mcc")]
        public string SellerMCC { get; set; }

        [Column("seller_url")]
        public string SellerURL { get; set; }

        [Column("seller_business_registration_number")]
        public string SellerBusinessRegistrationNumber { get; set; }

        [Column("seller_business_phone_number")]
        public string SellerBusinessPhoneNumber { get; set; }

        [Column("seller_email_address")]
        public string SellerEmailAddress { get; set; }

        [Column("seller_currency_code")]
        public string SellerCurrencyCode { get; set; }

        [Column("seller_status")]
        public string SellerStatus { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
