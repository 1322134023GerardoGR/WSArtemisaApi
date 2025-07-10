namespace WSArtemisaApi.Models
{
    public class AuthModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }  // Nuevo campo
        public string LastName { get; set; }  // Nuevo campo
        public Guid CardBrandId { get; set; }  // Nuevo campo (relación con CardBrand)
        public decimal Wallet { get; set; }  // Nuevo campo (saldo del usuario)
    }
}
