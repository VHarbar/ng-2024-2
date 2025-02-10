using System.ComponentModel;

namespace MVCWebApp.Models
{
    public record SumModel
    {
        [Description("value not null")]
        public int num1 { get; set; }
        public int num2 { get; set; }
    }
}
