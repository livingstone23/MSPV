using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Context;
using WebApiTemplate.DTOs;
using WebApiTemplate.Models;

namespace WebApiTemplate.Controllers.v1
{

    [ApiController]
    [Route("api/v1/books/{bookId:Int}/comentaries")]
    public class ComentariesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ComentariesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }


        [HttpPost]
        public async Task<ActionResult> Post(int bookId, ComentariesCreationDTO comentariesCreationDTO)
        {

            var bookExist = await _context.Books.AnyAsync(b => b.Id == bookId);

            if (!bookExist)
            {
                return NotFound();
            }

            var comentary = _mapper.Map<Comentary>(comentariesCreationDTO);
            comentary.BookId = bookId;
            _context.Add(comentary);
            await _context.SaveChangesAsync();
            return Ok(comentary);

        }



    }

}
