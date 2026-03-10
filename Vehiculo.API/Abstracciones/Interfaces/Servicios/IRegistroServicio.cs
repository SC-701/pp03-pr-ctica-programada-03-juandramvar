namespace Abstracciones.Interfaces.Servicios
{
    public interface IRegistroServicio
    {
        Task<Revision> Obtener(string placa);
    }
}

