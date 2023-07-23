using AutoMapper;
using BookWebAPI.DTOs;
using BookWebAPI.Models;

namespace BookWebAPI.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Author?, AuthorDTO>();
            CreateMap<AuthorDTO?, Author>();
            CreateMap<Books?, BookDTO>();
            CreateMap<BookDTO?, Books>();
            CreateMap<Country?, CountryDTO>();
            CreateMap<CountryDTO?, Country>();
            CreateMap<Genre?, GenreDTO>();
            CreateMap<GenreDTO?, Genre>();
            CreateMap<Shop?, ShopsDTO>();
            CreateMap<ShopsDTO?, Shop>();

        }
    }
}
