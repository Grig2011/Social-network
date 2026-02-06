using DevNet.Repasitories.Post;
using Microsoft.AspNetCore.Mvc;
using DevNet.Models;
using static System.Net.Mime.MediaTypeNames;
namespace DevNet.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly IWebHostEnvironment _env;
        public PostController(IPost postService, IWebHostEnvironment env)
        {
            _postService = postService;
            _env = env;
        }
        public async Task< IActionResult> Index()
        {
            var posts  = await _postService.GetAllPosts(); 
            return View(posts);
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Post model, IFormFile Image)
        {
            Console.WriteLine(model.Content + " ------");

            if (Image != null)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                string path = Path.Combine(_env.WebRootPath, "Images", "Posts", fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(path)!);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                Console.WriteLine(fileName + " ------");

                model.image = fileName;
                await _postService.AddPost(model);
                return RedirectToAction("Index");
               

            }
            await _postService.AddPost(model);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await _postService.GetPostById(id);
            return View(post);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Post model, IFormFile Image)
        {
            if (Image != null)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                string path = Path.Combine(_env.WebRootPath, "Images", "Posts", fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(path)!);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                Console.WriteLine(fileName + " ------");

                model.image = fileName;
                await _postService.Edit(model);
                return RedirectToAction("Index");


            }
            await _postService.Edit(model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.DeletePost(id);
            return RedirectToAction("Index");
        }
    }
}
