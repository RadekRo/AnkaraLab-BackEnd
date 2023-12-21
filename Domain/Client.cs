using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnkaraLab_BackEnd.WebAPI.Domain
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Surname { get; set; } = string.Empty;
        public double Discount { get; set; }
        public DateTime LastLoginDate { get; set; }
        //[ForeignKey(nameof(DeliveryAdress))]
        //private int DeliveryAdress { get; set; }
        //[ForeignKey(nameof(DeliveryAdress))]
        //private int DeliveryAdress { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool Newsletter { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public bool IsAdmin { get; set; } = false;
        public int Status { get; set; } = 1;
        public string FtpLogin { get; set; } = string.Empty;
        public string FtpPassword { get; set; } = string.Empty;
        public int Epoint { get; set; } = 0;
        public double Deposit { get; set; } = 0;
        public DateTime Deadline { get; set; }
    }
}
