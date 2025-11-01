using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajes1
{
    public enum TipoMensaje
    {
        Informacion,
        Advertencia,
        Error,
        Exito
    }

    public static class GestorMensajes
    {
        public delegate void MensajeHandler(object sender, MensajeEventArgs e);

        public static event MensajeHandler MensajeGenerado;

        public static void LanzarMensaje(string texto, TipoMensaje tipo)
        {
            MensajeGenerado?.Invoke(null, new MensajeEventArgs(texto, tipo));
        }

        public static void Info(string texto) => LanzarMensaje(texto, TipoMensaje.Informacion);
        public static void Advertencia(string texto) => LanzarMensaje(texto, TipoMensaje.Advertencia);
        public static void Error(string texto) => LanzarMensaje(texto, TipoMensaje.Error);
        public static void Exito(string texto) => LanzarMensaje(texto, TipoMensaje.Exito);
    }

    public class MensajeEventArgs : EventArgs
    {
        public string Texto { get; }
        public TipoMensaje Tipo { get; }

        public MensajeEventArgs(string texto, TipoMensaje tipo)
        {
            Texto = texto;
            Tipo = tipo;
        }
    }

}
