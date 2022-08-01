using AutoMapper;
using VidoWebApi.Dtos;
using VidoWebApi.Models;

namespace VidoWebApi.Profiles{
    public class SinhvienProfile : Profile{
        public SinhvienProfile(){
            CreateMap<SinhvienCreateDto,Sinhvien>()
            .ForMember(dest=>dest.sv_id,act=>act.MapFrom(src=>src.sv_id))
            .ForMember(dest=>dest.sv_ngaysinh,act=>act.MapFrom(src=>src.sv_ngaysinh))
            .ForMember(dest=>dest.sv_nganh,act=>act.MapFrom(src=>src.sv_nganh))
            .ForMember(dest=>dest.sv_hedaotao,act=>act.MapFrom(src=>src.sv_hedaotao))
            .ForMember(dest=>dest.sv_ketqua,act=>act.MapFrom(src=>src.sv_ketqua))
            .ForMember(dest=>dest.sv_hinhthuc,act=>act.MapFrom(src=>src.sv_hinhthuc))
            .ForMember(dest=>dest.sv_tinhtrang,act=>act.MapFrom(src=>src.sv_tinhtrang))
            .ForMember(dest=>dest.sv_email,act=>act.MapFrom(src=>src.sv_email));
            CreateMap<Sinhvien,SinhvienReadDto>();
        }
    }
}