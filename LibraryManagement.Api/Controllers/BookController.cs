using LibraryManagement.Business.Interfaces;
using LibraryManagement.Business.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Api.Controllers
{
    [ApiController]
    public class BookController : ControllerBase{

        private readonly IBookService _bookService;

        public BookController(IBookService bookService) {

            _bookService = bookService;

        }

        public async Task<ActionResult<BookDTO>> Create(BookDTO bookDTO) {

            var result = await _bookService.CreateBook(bookDTO);

            if (result) {
                return BadRequest();
            }

            return Ok();

        }
    }
}
