namespace GameZone.Controllers;


public class GamesController : Controller
{
	private readonly ApplicationDbContext _context;
	private readonly ICategoriesServices _categoriesService;
	private readonly IDevicesServices _devicesService;
	private readonly IGamesService _gamesServices;

	public int Creatr;
	public GamesController(ApplicationDbContext context, ICategoriesServices categoriesService, IDevicesServices devicesService, IGamesService gamesServices)
	{
		_context = context;
		_categoriesService = categoriesService;
		_devicesService = devicesService;
		_gamesServices = gamesServices;
	}

	public IActionResult Index()
	{
		return View();
	}

	[HttpGet]
	public IActionResult Create()
	{

		CreateGameFormViewModel viewModel = new()
		{
			Categories = _categoriesService.GetSelectList(),

			Devices = _devicesService.GetSelectList()
		};
		return View(viewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]

	public async Task<IActionResult> Create(CreateGameFormViewModel model)
	{

		if (!ModelState.IsValid)
		{
			model.Categories = _categoriesService.GetSelectList();
			model.Devices = _devicesService.GetSelectList();

			return View(model);

		}
		await _gamesServices.Create(model);

		return RedirectToAction(nameof(Index));
	}


}


