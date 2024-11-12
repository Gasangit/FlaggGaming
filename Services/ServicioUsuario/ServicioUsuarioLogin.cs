using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using FlaggGaming.Model.usuarios;

namespace FlaggGaming.Services.ServicioUsuario;

public class ServicioUsurioLogin
{
    public static int Id { get; set; } = 0;
    public static string nombre { get; set; } = "";
    public string nombreServicio { get; set; } = "";
    public static string apellido { get; set; } = "";
    public static string mail { get; set; } = "";
    public static string password { get; set; } = "";
    public static bool rolTienda { get; set; } = false;
    public event Action OnUsuarioLogin;

    public void setUsuarioLoginData(int idParam, string nombreParam, string apellidoParam, string mailParam, bool rolParam)
    {
        ServicioUsurioLogin.Id = idParam;
        ServicioUsurioLogin.nombre = nombreParam;
        this.nombreServicio = nombreParam;
        ServicioUsurioLogin.apellido = apellidoParam;
        ServicioUsurioLogin.mail = mailParam;
        ServicioUsurioLogin.rolTienda = rolParam;
        OnUsuarioLogin?.Invoke();
    }

    //public void forzarCambio() { OnUsuarioLogin?.Invoke(); }

    public void setUsuarioLogOut()
    {
        ServicioUsurioLogin.Id = 0;
        ServicioUsurioLogin.nombre = "";
        this.nombreServicio = "";
        ServicioUsurioLogin.apellido = "";
        ServicioUsurioLogin.mail = "";
        ServicioUsurioLogin.rolTienda = false;
        OnUsuarioLogin?.Invoke();

    }
}