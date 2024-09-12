using System;
using FlaggGaming.Services.ServiciosAPISteam;
using Microsoft.AspNetCore.Mvc;

public class IndexController: Controller
{
    private readonly JuegosListaTotalService _JuegosListaTotalService;
    public IndexController(JuegosListaTotalService listaJuegosService)
	{
        _JuegosListaTotalService  = listaJuegosService;
	}

    
}
