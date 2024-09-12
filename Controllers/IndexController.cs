using System;
using FlaggGaming.Services.ServiciosAPISteam;
using Microsoft.AspNetCore.Mvc;
using FlaggGaming.Entity;

public class IndexController: Controller
{
    private readonly DatosContext _context;
    public IndexController(DatosContext contextService)
	{
        _context  = contextService;
	}

    public IActionResult Index() {



        return View();
    }

    
}
