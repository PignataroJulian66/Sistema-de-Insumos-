using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public interface IABM <T>
    {
        int Agregar(T obj);
        int Eliminar(T obj);
        int Editar(T obj);

        List<T> Listar();
    }
}
