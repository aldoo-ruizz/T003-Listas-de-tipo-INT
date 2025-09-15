using System;

namespace Listas_Edades
{
    internal class Constructor
    {
        public string Nombre { get; }
        public string Carrera { get; }

        public Constructor(string nombre, string carrera)
        {
            Nombre = nombre;
            Carrera = carrera;
        }

        public override string ToString()
        {
            return $"{Nombre} - {Carrera}";
        }
    }
}