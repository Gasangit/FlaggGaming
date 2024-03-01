using System;
using FlaggGaming.Services.APISteam;
using Microsoft.AspNetCore.Mvc;

public class IndexController: Controller
{
    private readonly JuegosListaTotalService _JuegosListaTotalService;
    public IndexController(JuegosListaTotalService listaJuegosService)
	{
        _JuegosListaTotalService  = listaJuegosService;
	}

    
}
