using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Linq;

namespace Listas_Edades
{
    internal class Acciones
    {
        private readonly List<int> edades = new List<int>();

        public void AgregarEdad(int edad)
        {
            edades.Add(edad);
        }

        public bool EliminarPorIndice(int indice)
        {
            if (indice >= 0 && indice < edades.Count)
            {
                edades.RemoveAt(indice);
                return true;
            }
            return false;
        }

        public bool EliminarPorValor(int valor)
        {
            return edades.Remove(valor);
        }

        public bool ActualizarEdad(int indice, int nuevaEdad)
        {
            if (indice >= 0 && indice < edades.Count)
            {
                edades[indice] = nuevaEdad;
                return true;
            }
            return false;
        }

        public List<int> ObtenerTodas()
        {
            // Devuelve una copia para evitar modificación externa directa
            return new List<int>(edades);
        }

        public void Ordenar()
        {
            edades.Sort();
        }

        public int Sumar()
        {
            return edades.Sum();
        }

        public double Promedio()
        {
            return edades.Count == 0 ? 0.0 : edades.Average();
        }

        // Exportación simplificada: siempre genera un CSV con dos columnas: Índice,Edad
        public void ExportarAArchivo(string ruta)
        {
            var lines = new List<string>();
            lines.Add("Índice,Edad");
            for (int i = 0; i < edades.Count; i++)
            {
                lines.Add(string.Format("{0},{1}", i, edades[i]));
            }

            // Crea/reescribe el archivo (txt o csv según extensión indicada en 'ruta')
            File.WriteAllLines(ruta, lines);
        }
    }
}