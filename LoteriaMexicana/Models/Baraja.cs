using LoteriaMexicana.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoteriaMexicana.Models
{
    public class Baraja
    {
        private List<Carta> _cartas;
        private List<Carta> _cartasRestantes;
        private Random _rng;

        public List<Carta> CartasCantadas { get; private set; }

        public Baraja()
        {
            _rng = new Random();
            CartasCantadas = new List<Carta>();
            _cartas = InicializarCartas();
            _cartasRestantes = new List<Carta>(_cartas);
        }

        private List<Carta> InicializarCartas()
        {
            return new List<Carta>
            {
                new Carta(1,  "El Gallo",        Properties.Resources.gallo),
                new Carta(2,  "El Diablito",     Properties.Resources.diablito),
                new Carta(3,  "La Dama",         Properties.Resources.dama),
                new Carta(4,  "El Catrin",       Properties.Resources.catrin),
                new Carta(5,  "El Paraguas",     Properties.Resources.paraguas),
                new Carta(6,  "La Sirena",       Properties.Resources.sirena),
                new Carta(7,  "La Escalera",     Properties.Resources.escalera),
                new Carta(8,  "La Botella",      Properties.Resources.botella),
                new Carta(9,  "El Barril",       Properties.Resources.barril),
                new Carta(10, "El Arbol",        Properties.Resources.arbol),
                new Carta(11, "El Melon",        Properties.Resources.melon),
                new Carta(12, "El Valiente",     Properties.Resources.valiente),
                new Carta(13, "El Gorrito",      Properties.Resources.gorrito),
                new Carta(14, "La Muerte",       Properties.Resources.muerte),
                new Carta(15, "La Pera",         Properties.Resources.pera),
                new Carta(16, "La Bandera",      Properties.Resources.bandera),
                new Carta(17, "El Bandolon",     Properties.Resources.bandolon),
                new Carta(18, "El Violoncello",  Properties.Resources.violoncello),
                new Carta(19, "La Garza",        Properties.Resources.garza),
                new Carta(20, "El Pajaro",       Properties.Resources.pajaro),
                new Carta(21, "La Mano",         Properties.Resources.mano),
                new Carta(22, "La Bota",         Properties.Resources.bota),
                new Carta(23, "La Luna",         Properties.Resources.luna),
                new Carta(24, "El Cotorro",      Properties.Resources.cotorro),
                new Carta(25, "El Borracho",     Properties.Resources.borracho),
                new Carta(26, "El Negrito",      Properties.Resources.negrito),
                new Carta(27, "El Corazon",      Properties.Resources.corazon),
                new Carta(28, "La Sandia",       Properties.Resources.sandia),
                new Carta(29, "El Tambor",       Properties.Resources.tambor),
                new Carta(30, "El Camaron",      Properties.Resources.camaron),
                new Carta(31, "Las Jaras",       Properties.Resources.jaras),
                new Carta(32, "El Musico",       Properties.Resources.musico),
                new Carta(33, "La Arana",        Properties.Resources.araña),
                new Carta(34, "El Soldado",      Properties.Resources.soldado),
                new Carta(35, "La Estrella",     Properties.Resources.estrella),
                new Carta(36, "El Cazo",         Properties.Resources.cazo),
                new Carta(37, "El Mundo",        Properties.Resources.mundo),
                new Carta(38, "El Apache",       Properties.Resources.apache),
                new Carta(39, "El Nopal",        Properties.Resources.nopal),
                new Carta(40, "El Alacran",      Properties.Resources.alacran),
                new Carta(41, "La Rosa",         Properties.Resources.rosa),
                new Carta(42, "La Calavera",     Properties.Resources.calavera),
                new Carta(43, "La Campana",      Properties.Resources.campana),
                new Carta(44, "El Cantarito",    Properties.Resources.cantarito),
                new Carta(45, "El Venado",       Properties.Resources.venado),
                new Carta(46, "El Sol",          Properties.Resources.sol),
                new Carta(47, "La Corona",       Properties.Resources.corona),
                new Carta(48, "La Chalupa",      Properties.Resources.chalupa),
                new Carta(49, "El Pino",         Properties.Resources.pino),
                new Carta(50, "El Pescado",      Properties.Resources.pescado),
                new Carta(51, "La Palma",        Properties.Resources.palma),
                new Carta(52, "La Maceta",       Properties.Resources.maceta),
                new Carta(53, "El Arpa",         Properties.Resources.arpa),
                new Carta(54, "La Rana",         Properties.Resources.rana),
            };
        }

        public Carta SiguienteCarta()
        {
            if (_cartasRestantes.Count == 0) return null;
            int idx = _rng.Next(_cartasRestantes.Count);
            Carta carta = _cartasRestantes[idx];
            _cartasRestantes.RemoveAt(idx);
            CartasCantadas.Add(carta);
            return carta;
        }

        public bool HayCartasRestantes() => _cartasRestantes.Count > 0;

        public Carta ObtenerCartaPorId(int id)
        {
            return _cartas.Find(c => c.Id == id);
        }

        public void RegistrarCartaCantada(int id)
        {
            Carta carta = ObtenerCartaPorId(id);

            if (carta == null) return;

            if (!CartasCantadas.Exists(c => c.Id == id))
                CartasCantadas.Add(carta);

            _cartasRestantes.RemoveAll(c => c.Id == id);
        }

        public void Reiniciar()
        {
            CartasCantadas.Clear();
            _cartasRestantes = new List<Carta>(_cartas);
        }
    }
}