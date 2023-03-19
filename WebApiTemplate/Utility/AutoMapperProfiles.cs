using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebApiTemplate.DTOs;
using WebApiTemplate.Models;

namespace WebApiTemplate.Utility
{
    public class AutoMapperProfiles: Profile 
    {
        public AutoMapperProfiles()
        {
            CreateMap<AuthorCreationDTO, Author>();
            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorDTO, Author>();
            //CreateMap<BookCreationDTO, Book>();
            //CreateMap<Book, BookDTO>();
            CreateMap<ComentariesCreationDTO, Comentary>();

            CreateMap<IdentityUser, UserDTO>();
            CreateMap<UserDTO, IdentityUser>();

        }
    }
}
