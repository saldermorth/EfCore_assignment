using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment_Dataaccess.Models.Enities
{
    public class OrderItemsEntity
    {
       

        [Key, Column(Order = 0)]      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }      
                
        [Required]
        public int Quantity { get; set; }      
        
        public virtual ProductsEntity Products { get; set; }
       
    }
}
