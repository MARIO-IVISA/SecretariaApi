using AutoMapper;
using Secretaria.Application.Models;
using Secretaria.Core.Enums;
using Secretaria.Domain.Entities;

namespace Secretaria.Application.Mappings
{
    public class ModelMap : Profile
    {
        public ModelMap()
        {
            CreateMap<MatriculaCadastroModel, Matricula>()
              .ForMember(dest => dest.Nota, opt => opt.MapFrom(src => 0))
              .ForMember(dest => dest.Status, opt => opt.MapFrom(src => StatusAprovacao.Pendente));
        }
    }
}
