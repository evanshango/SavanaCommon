using System.ComponentModel.DataAnnotations;

namespace Treasures.Common.Helpers;

public class BaseEntity {
    [Required] public string Id { get; set; } = Guid.NewGuid().ToString();
    [Required] public bool Active { get; set; } = true;
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    [Required] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}