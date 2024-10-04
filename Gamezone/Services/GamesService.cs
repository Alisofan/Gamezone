





namespace GameZone.Services
{
	public class GamesService : IGamesService
	{
		private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly string _imagesPath;

		public GamesService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
			_imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
		}
		public IEnumerable<Game> GetAll()
		{
			return _context.Games
				.Include(g => g.Category)
				.Include(g => g.Devices)
				.ThenInclude(d => d.Device)
				.AsNoTracking()
				.ToList();
		}
		public async Task Create(CreateGameFormViewModel modal)
		{
			var coverName = $"{Guid.NewGuid()}{Path.GetExtension(modal.Cover.FileName)}";

			var path = Path.Combine(_imagesPath, coverName);

			using var stream = File.Create(path);
			await modal.Cover.CopyToAsync(stream);



			Game game = new()
			{
				Name = modal.Name,
				Description = modal.Description,
				CategoryId = modal.CategoryId,
				Cover = coverName,
				Devices = modal.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList(),

			};



			_context.Add(game);
			_context.SaveChanges();
		}


	}
}
