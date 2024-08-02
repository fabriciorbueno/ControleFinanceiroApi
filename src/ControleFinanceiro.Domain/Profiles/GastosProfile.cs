using AutoMapper;
using ControleFinanceiro.Domain.Dtos.Response;
using ControleFinanceiro.Domain.Models.Entities;

namespace ControleFinanceiro.Domain.Profiles
{
    public class GastosProfile : Profile
    {
        public GastosProfile()
        {
            CreateMap<Entity, ResponseBase>().ReverseMap();
        }

    }
}
