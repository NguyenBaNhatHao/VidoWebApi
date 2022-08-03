using VidoWebApi.Data;
using VidoWebApi.Dtos;
using VidoWebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace VidoWebApi.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhvienController : ControllerBase{
        private readonly VidoWebDbContext _context;
        private readonly IMapper _mapper;

        public SinhvienController(VidoWebDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<SinhvienReadDto> Getsinhvien()
        {
            var dataMessage = _context.tb_sinhvien.FromSqlRaw("select * from tb_sinhvien").ToList();
            return Ok(dataMessage);
        }
        [HttpPost]
        public ActionResult<SinhvienReadDto> CreateSinhvien(SinhvienSendDto sinhvienSendDto){
            var subscription = _mapper.Map<Sinhvien>(sinhvienSendDto);
            try
            {
                var sv_id = new SqlParameter("@sv_id", subscription.sv_id);
                var sv_name = new SqlParameter("@sv_name", subscription.sv_name);
                var sv_ngaysinh = new SqlParameter("@sv_ngaysinh", subscription.sv_ngaysinh);
                var sv_nganh = new SqlParameter("@sv_nganh", subscription.sv_nganh);
                var sv_hedaotao = new SqlParameter("@sv_hedaotao", subscription.sv_hedaotao);
                var sv_ketqua = new SqlParameter("@sv_ketqua", subscription.sv_ketqua);
                var sv_hinhthuc = new SqlParameter("@sv_hinhthuc", subscription.sv_hinhthuc);
                var sv_tinhtrang = new SqlParameter("@sv_tinhtrang", subscription.sv_tinhtrang);
                var sv_email = new SqlParameter("@sv_email", subscription.sv_email);

                _context.Database.ExecuteSqlRaw("InsertStudent {0},{1},{2},{3},{4},{5},{6},{7},{8}", parameters: new[] {sv_id.Value,sv_name.Value,sv_ngaysinh.Value,sv_nganh.Value,sv_hedaotao.Value,sv_ketqua.Value,sv_hinhthuc.Value,sv_tinhtrang.Value,sv_email.Value});
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            var messageReadDto = _mapper.Map<SinhvienReadDto>(subscription);
            
            return Ok(messageReadDto);
        }
        [HttpPut("{id}")]
        public ActionResult<SinhvienReadDto> UpdateSinhvien(int id ,SinhvienSendDto sinhvienSendDto){
            var subscription = _mapper.Map<Sinhvien>(sinhvienSendDto);
            
            try
            {
                if(id != sinhvienSendDto.id){
                    return BadRequest("sv_id mismatch");
                }
                _context.tb_sinhvien.Update(subscription);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            var messageReadDto = _mapper.Map<SinhvienReadDto>(subscription);
            
            return Ok(messageReadDto);
        }
    }
}