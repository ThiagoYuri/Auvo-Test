using AutoMapper;
using Auvo.RH.DAL.Models;
using Auvo.RH.Models;
using Auvo.RH.Models.Dto.Analise;

namespace Auvo.RH.Profiles.Analise
{
    public class AnaliseProfile : Profile
    {
        public AnaliseProfile()
        {
            CreateMap<Departamento, AnaliseDepartamentoDto>();
            CreateMap<Colaborador, AnaliseColaboradorDto>();
        }
    }
}
