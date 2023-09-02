using Refrigerator.Api.Domain.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Refrigerator.Api.Domain.Models
{
    public class FridgeActivityLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public ActivityType Type { get; set; }
        public DateTime ActivityDate { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}
