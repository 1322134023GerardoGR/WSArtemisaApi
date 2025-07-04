using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSArtemisaApi.Models
{
    [Table("address")]
    public class Address
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("address_line_1")]
        public string AddressLine1 { get; set; }

        [Column("address_line_2")]
        public string AddressLine2 { get; set; }

        [Column("address_line_3")]
        public string AddressLine3 { get; set; }

        [Column("address_line_4")]
        public string AddressLine4 { get; set; }

        [Column("postal_code")]
        public string PostalCode { get; set; }

        [Column("city_name")]
        public string CityName { get; set; }

        [Column("country_iso_code")]
        public string CountryIsoCode { get; set; }

        [Column("country_name")]
        public string CountryName { get; set; }

        [Column("region_name")]
        public string RegionName { get; set; }

        [Column("region_code")]
        public string RegionCode { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
