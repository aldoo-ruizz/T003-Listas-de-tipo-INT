using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;

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

        public void ExportarAArchivo(string ruta)
        {
            var ext = Path.GetExtension(ruta)?.ToLowerInvariant();
            if (ext == ".xlsx")
            {
                // Exportar a Excel usando ClosedXML
                var lista = ObtenerTodas();
                using (var wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Edades");
                    ws.Cell(1, 1).Value = "Índice";
                    ws.Cell(1, 2).Value = "Edad";

                    for (int i = 0; i < lista.Count; i++)
                    {
                        ws.Cell(i + 2, 1).Value = i;
                        ws.Cell(i + 2, 2).Value = lista[i];
                    }

                    // Ajustar anchos y formato básico
                    ws.Columns().AdjustToContents();
                    wb.SaveAs(ruta);
                }
            }
            else
            {
                // Comportamiento por defecto: texto plano (una edad por línea)
                File.WriteAllLines(ruta, edades.Select(e => e.ToString()).ToArray());
            }
        }
    }
}