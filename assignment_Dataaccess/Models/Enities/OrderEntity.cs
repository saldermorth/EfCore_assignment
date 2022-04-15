using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment_Dataaccess.Models.Enities
{
    public class OrderEntity
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
       // public int CustomerId { get; set; } //Todo FK to CustomerID
        public CustomerEntity? Customers { get; set; } = null!; //FK to Customer table
        [Required]
        public DateTime OrderDate { get; set; }

        
        
        public int? OrderId { get; set; }





    }
}
