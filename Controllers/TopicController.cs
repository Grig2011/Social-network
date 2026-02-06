using DevNet.Repasitories.Post;
using DevNet.Repasitories.Topic;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace DevNet.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopic _topicService;
        private readonly IWebHostEnvironment _env;
        public TopicController(ITopic topicService,IWebHostEnvironment env)
        {
            _topicService = topicService;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var topics = await _topicService.GetAllTopicsAsync();
            return View(topics);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Models.Topic model, IFormFile Image)
        {
            if (Image != null)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                string path = Path.Combine(_env.WebRootPath, "Images", "Topic", fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(path)!);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                Console.WriteLine(fileName + " ------");

                model.image = fileName;

                await _topicService.CreateTopic(model);
                return RedirectToAction("Index");


            }
            await _topicService.CreateTopic(model);
            return RedirectToAction("Index");

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _topicService.DeleteTopic(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var topic = await _topicService.GetTopicById(id);
            if (topic == null)
            {
                return NotFound();
            }
            return View(topic);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Models.Topic model, IFormFile Image)
        {
            var currentThopic = await _topicService.GetTopicById(model.Id);
            currentThopic.Title = model.Title;
            currentThopic.Description = model.Description;

            ViewBag.ChangedDate = DateTime.Now;  


            if (Image != null)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                string path = Path.Combine(_env.WebRootPath, "Images", "Topic", fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(path)!);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                Console.WriteLine(fileName + " ------");

                currentThopic.image = fileName;



            }
            await _topicService.UpdateTopic(currentThopic);
            return RedirectToAction("Index");
        }

    }
}
