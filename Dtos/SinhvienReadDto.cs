namespace VidoWebApi.Dtos{
    public class SinhvienReadDto{
        public int id {get;set;}
        public string? sv_id { get; set; }
        public string? sv_name { get; set; }
        public string? sv_ngaysinh { get; set; }
        public string? sv_nganh { get; set; }
        public string? sv_hedaotao { get; set; }
        public string? sv_ketqua { get; set; }
        public string? sv_hinhthuc { get; set; }
        public string? sv_tinhtrang { get; set; }
        public string? sv_email { get; set; }
        public string? img_name { get; set; }
        public DateTime img_time { get; set; }
    }
}