using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSArtemisaApi.Models
{
    [Table("transactions")]
    public class Transaction
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("account")]
        public string Account { get; set; }

        [Column("issuer")]
        public string Issuer { get; set; }

        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("operation_type")]
        public string OperationType { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("response_code")]
        public string ResponseCode { get; set; }

        [Column("response")]
        public string Response { get; set; }

        [Column("branch")]
        public string Branch { get; set; }

        [Column("pos")]
        public string POS { get; set; }

        [Column("reference")]
        public string Reference { get; set; }

        [Column("transaction_date")]
        public DateTime TransactionDate { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
