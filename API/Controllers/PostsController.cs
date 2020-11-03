using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Posts;
using Domain;
using Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly DataContext context;

        public PostsController(IMediator mediator, DataContext context)
        {
            this.mediator = mediator;
            this.context = context;
        }

        // public async Task<ActionResult<List<Post>>> List()
        // {
        //     return await this.mediator.Send(new List.Query());
        // }

        /// <summary>
        /// GET api/posts
        /// </summary>
        /// <returns>A list of posts</returns>
        [HttpGet]
        public ActionResult<List<Post>> Get()
        {
            return this.context.Posts.ToList();
        }

        /// <summary>
        /// GET api/post/[id]
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns>A single post</returns>
        [HttpGet("{id}")]
        public ActionResult<Post> GetById(Guid id)
        {
            return this.context.Posts.Find(id);
        }

        /// <summary>
        /// POST api/post
        /// </summary>
        /// <param name="request">JSON request containing post fields</param>
        /// <returns>A new post</returns>
        [HttpPost]
        public ActionResult<Post> Create([FromBody]Post request)
        {
            var post = new Post 
            {
                Id = request.Id,
                Title = request.Title,
                Body = request.Body,
                Date = request.Date
            };

            this.context.Posts.Add(post);
            var success = this.context.SaveChanges() > 0;
            if(success)
            {
                return post;
            }
            throw new Exception("Error creating post");
        }





    }
}
