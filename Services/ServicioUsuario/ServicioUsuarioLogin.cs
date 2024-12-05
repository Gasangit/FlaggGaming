using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using FlaggGaming.Model.usuarios;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace FlaggGaming.Services.ServicioUsuario;

public class ServicioUsurioLogin
{
    public UsuarioLogueado usuarioLogueado { get; set; }
    ProtectedSessionStorage _ProtectedSessionStorage;

    public static int Id { get; set; } = 0;
    public int IdServicio { get; set; } = 0;
    public static string nombre { get; set; } = "";
    public string nombreServicio { get; set; } = "";
    public static string apellido { get; set; } = "";
    public string apellidoServicio { get; set; } = "";
    public static string mail { get; set; } = "";
    public string mailServicio { get; set; } = "";
    public static string password { get; set; } = "";
    public string passwordServicio { get; set; } = "";
    public static bool rolTienda { get; set; } = false;
    public bool rolTiendaServicio { get; set; } = false;
    public bool IsPrerendering { get; set; }
    public event Action OnUsuarioLogin;
    //private static int anChange;

    public ServicioUsurioLogin(ProtectedSessionStorage protectedSessionStoreInject)
    {
        _ProtectedSessionStorage = protectedSessionStoreInject;
    }

    public async void setUsuarioLoginData(int idParam, string nombreParam, string apellidoParam, string mailParam, bool rolParam)
    {
        this.IdServicio = idParam;
        this.nombreServicio = nombreParam;
        this.apellidoServicio = apellidoParam;
        this.mailServicio = mailParam;
        this.rolTiendaServicio = rolParam;

        ServicioUsurioLogin.Id = idParam;
        ServicioUsurioLogin.nombre = nombreParam;
        ServicioUsurioLogin.apellido = apellidoParam;
        ServicioUsurioLogin.mail = mailParam;
        ServicioUsurioLogin.rolTienda = rolParam;

        //anChange++;
        usuarioLogueado = new UsuarioLogueado(idParam, nombreParam, apellidoParam, mailParam, rolParam);
        await _ProtectedSessionStorage.SetAsync("usuarioLogueado",usuarioLogueado);
        System.TimeSpan.FromSeconds(3);
        OnUsuarioLogin?.Invoke();
    }

    //public void forzarCambio() { OnUsuarioLogin?.Invoke(); }

    public async void setUsuarioLogOut()
    {
        ServicioUsurioLogin.Id = 0;
        ServicioUsurioLogin.nombre = "";
        this.nombreServicio = "";
        ServicioUsurioLogin.apellido = "";
        ServicioUsurioLogin.mail = "";
        ServicioUsurioLogin.rolTienda = false;

        await _ProtectedSessionStorage.DeleteAsync("usuarioLogueado");
        System.TimeSpan.FromSeconds(3);
        OnUsuarioLogin?.Invoke();

    }

    public void prerenderDetected(bool estado)
    {
        this.IsPrerendering = estado;
        OnUsuarioLogin?.Invoke();
    }
}