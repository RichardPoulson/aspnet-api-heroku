using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspnet_api_heroku.Models;

namespace aspnet_api_heroku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleItemsController : ControllerBase
    {
        private readonly ArticleContext _context;

        public ArticleItemsController(ArticleContext context)
        {
            _context = context;
        }

        // GET: api/ArticleItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleItem>>> GetArticleItems()
        {
            return await _context.ArticleItems.ToListAsync();
        }

        // GET: api/ArticleItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleItem>> GetArticleItem(long id)
        {
            var articleItem = await _context.ArticleItems.FindAsync(id);

            if (articleItem == null)
            {
                return NotFound();
            }

            return articleItem;
        }

        // PUT: api/ArticleItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticleItem(long id, ArticleItem articleItem)
        {
            if (id != articleItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(articleItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ArticleItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArticleItem>> PostArticleItem(ArticleItem articleItem)
        {
            _context.ArticleItems.Add(articleItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticleItem", new { id = articleItem.Id }, articleItem);
        }

        // DELETE: api/ArticleItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArticleItem>> DeleteArticleItem(long id)
        {
            var articleItem = await _context.ArticleItems.FindAsync(id);
            if (articleItem == null)
            {
                return NotFound();
            }

            _context.ArticleItems.Remove(articleItem);
            await _context.SaveChangesAsync();

            return articleItem;
        }

        private bool ArticleItemExists(long id)
        {
            return _context.ArticleItems.Any(e => e.Id == id);
        }
    }
}
