using System.ComponentModel.DataAnnotations;
namespace VidoWebApi.Models{
    public class Sinhvien{
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? sv_id { get; set; }
        public string? sv_name { get; set; }
        public string? sv_ngaysinh { get; set; }
        public string? sv_nganh { get; set; }
        public string? sv_hedaotao { get; set; }
        public string? sv_ketqua { get; set; }
        public string? sv_hinhthuc { get; set; }
        public string? sv_tinhtrang { get; set; }
        public string? sv_email { get; set; }

    }
}