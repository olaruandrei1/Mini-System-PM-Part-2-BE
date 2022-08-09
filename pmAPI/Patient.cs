using System.ComponentModel.DataAnnotations;

namespace pmAPI
{
    public class Patient
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string StatusHos { get; set; } = string.Empty;

        [StringLength(50)]
        public string FirstLastNamePatient { get; set; } = string .Empty;

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}
