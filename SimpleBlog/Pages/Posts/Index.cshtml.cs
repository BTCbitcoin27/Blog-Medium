using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Data;
using SimpleBlog.Models;
using SimpleBlog.Utils; // Add this using directive
using System.Threading.Tasks;

namespace SimpleBlog.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Change this to use PaginatedList<BlogPost>
        public PaginatedList<BlogPost> BlogPosts { get; set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            var pageSize = 7; // Number of posts per page
            var posts = _context.BlogPosts
                .Include(b => b.Author) // Include the Author in the query
                .OrderByDescending(b => b.CreatedAt);

            // Use PaginatedList to paginate the results
            BlogPosts = await PaginatedList<BlogPost>.CreateAsync(posts.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}