using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Application.Posts;

using Domain;

using MediatR;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PostsController(IMediator mediator) => this.mediator = mediator;

        public async Task<ActionResult<List<Post>>> List()
        {
            return await this.mediator.Send(new List.Query());
        }
    }
}
