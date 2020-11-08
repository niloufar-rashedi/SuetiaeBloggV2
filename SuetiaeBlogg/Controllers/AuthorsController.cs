using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SuetiaeBlogg.API.Helpers;
using SuetiaeBlogg.Core.Helpers;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Authors;
using SuetiaeBlogg.Core.Services;
using SuetiaeBlogg.Services.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace SuetiaeBlogg.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private IAuthorService _authorService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AuthorsController(IAuthorService authorService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _authorService = authorService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] GetAuthorDto authorDto)
        {
            var author = _authorService.Authenticate(authorDto.Username, authorDto.Password);

            if (author == null)
                return BadRequest("Authorname or password is incorrect");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, author.AuthorId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic author info (without password) and token to store client side
            return Ok(new
            {
                Id = author.AuthorId,
                author.Username,
                author.FirstName,
                author.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] GetAuthorDto authorDto)
        {
            // map dto to entity
            var author = _mapper.Map<Author>(authorDto);

            try
            {
                // save 
                _authorService.Create(author, authorDto.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var authors = _authorService.GetAll();
        //    var authorDtos = _mapper.Map<IList<GetAuthorDto>>(authors);
        //    return Ok(authorDtos);
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var author = _authorService.GetById(id);
        //    var authorDto = _mapper.Map<GetAuthorDto>(author);
        //    return Ok(authorDto);
        //}

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GetAuthorDto authorDto)
        {
            // map dto to entity and set id
            var author = _mapper.Map<Author>(authorDto);
            author.AuthorId = id;

            try
            {
                // save 
                _authorService.Update(author, authorDto.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }
    }
}
