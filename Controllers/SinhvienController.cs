using VidoWebApi.Data;
using VidoWebApi.Dtos;
using VidoWebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                _context.tb_sinhvien.Add(subscription);
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