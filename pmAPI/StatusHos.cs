using System.ComponentModel.DataAnnotations;

namespace pmAPI
{
    public class StatusHos
    {
        public int id { get; set; }

        [StringLength(30)]
        public string StatusOption { get; set; } = string .Empty;
    }
}
