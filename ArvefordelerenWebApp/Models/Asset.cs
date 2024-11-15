using System.ComponentModel.DataAnnotations;

namespace ArvefordelerenWebApp.Models;

public class Asset
{
    public int Id { get; set; }
    [MinLength(1)]
    public string Name { get; set; } = null!;
    public double? Value { get; set; }
    public bool Liquid { get; set; }
}