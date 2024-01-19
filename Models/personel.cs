using System.ComponentModel.DataAnnotations;

namespace WebDepartment.Models
{
    public class personel
    {
        [Key]
        public int perid { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string sehir { get; set; }





    }
}
