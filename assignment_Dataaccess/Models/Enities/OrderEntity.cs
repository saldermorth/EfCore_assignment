using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment_Dataaccess.Models.Enities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        public DateTime OrderDate { get; set; }


        //[Required]
        //public string OrderStatus { get; set; } = null!;

        public virtual List<OrderItemsEntity> OrderRows { get; set; } = null!;






    }
}
