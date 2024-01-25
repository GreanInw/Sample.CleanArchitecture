using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.TableEntities;

[Table(nameof(SalesOrder))]
public class SalesOrder
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(100)]
    public string CustomerCode { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal Amount { get; set; }
    public DateTime OrderDate { get; set; }
    [Required, MaxLength(50)]
    public string OrderStatus { get; set; }
}
