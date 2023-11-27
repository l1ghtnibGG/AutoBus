using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models;

public class UrlModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    public string LongUrl { get; set; }

    public string ShortUrl { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime CreateDate { get; set; } = DateTime.Now;

    public uint ClickCount { get; set; } = 0;
}