using AutoMapper;
using Core.Queries.GetAnimes;
using Core.Queries.GetAnimeDescription;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Core.Service;
using Core.Extensions;
using Microsoft.AspNetCore.Http;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace AnimeSearch.Controllers
{
    public class AnimeController : BaseController   
    {
        private readonly IMapper _mapper;
        private readonly ParserService _parserService;


        public AnimeController(IMapper mapper, ParserService parserService) 
        {
            _parserService = parserService;
            _mapper = mapper;
        }


        [HttpGet("api/AllAnimeList")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AnimeVm>> AllAnimeList()
        {
            try
            {
                var query = new GetAnimesQuery();
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch (Exception e)
            {
                return BadRequest(e.GetFullMessage());
            }
        }


        [HttpGet("api/AnimeDescriptionByGuid")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AnimeDescriptionVm>> AnimeDescriptionByGuid(Guid guid)
        {
            try
            {
                var query = new GetAnimesDescriptionQuery
                {
                    Guid = guid 
                };
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch (Exception e)
            {
                return BadRequest(e.GetFullMessage());
            }
        }


        [HttpPost("api/AnimeSync")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> AnimeSync()
        {
            try
            {
                await _parserService.FillDataBaseAniDub();
                return Ok();    
            }
            catch(Exception e)
            {
                return BadRequest(e.GetFullMessage());
            }
        }

    }
}
