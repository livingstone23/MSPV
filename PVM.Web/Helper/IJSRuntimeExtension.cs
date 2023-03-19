using Microsoft.JSInterop;

namespace PVM.Web.Helper;

/// <summary>
/// Clase para Llamar el toaster y utilizar JavaScript en la aplicacion.
/// </summary>
public static class IJSRuntimeExtension
{
    public static async ValueTask ToastrSuccess(this IJSRuntime JSRuntime, string message)
    {
        await JSRuntime.InvokeVoidAsync("ShowToastr", "success", message);
    }
    public static async ValueTask ToastrError(this IJSRuntime JSRuntime, string message)
    {
        await JSRuntime.InvokeVoidAsync("ShowToastr", "error", message);
    }
}