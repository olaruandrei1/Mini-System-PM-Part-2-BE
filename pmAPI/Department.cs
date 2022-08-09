using System.ComponentModel.DataAnnotations;

namespace pmAPI
{
    public class Department
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string DepartamentName { get; set; } = string .Empty;
    }
}
