using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LoteriaMexicana.Models
{
    public class Carta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Image Imagen { get; set; }

        public Carta(int id, string nombre, Image imagen)
        {
            Id = id;
            Nombre = nombre;
            Imagen = imagen;
        }
    }
}