using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace LoteriaMexicana.Network
{
    public class ClienteLoteria
    {
        private TcpClient _cliente;
        private StreamWriter _writer;
        private bool _conectado;

        public event Action<string> MensajeRecibido;
        public event Action Desconectado;
        public event Action<string> Error;

        public void Conectar(string ip, int puerto)
        {
            if (_conectado) return;

            _cliente = new TcpClient();
            _cliente.Connect(ip, puerto);

            _writer = new StreamWriter(_cliente.GetStream());
            _writer.AutoFlush = true;

            _conectado = true;
            Task.Run(() => EscucharServidor());
        }

        public void Enviar(string mensaje)
        {
            if (!_conectado || _writer == null) return;

            try
            {
                _writer.WriteLine(mensaje);
            }
            catch (Exception ex)
            {
                Error?.Invoke(ex.Message);
            }
        }

        public void Desconectar()
        {
            _conectado = false;

            try { _writer?.Close(); } catch { }
            try { _cliente?.Close(); } catch { }
        }

        private void EscucharServidor()
        {
            try
            {
                StreamReader reader = new StreamReader(_cliente.GetStream());

                while (_conectado)
                {
                    string mensaje = reader.ReadLine();

                    if (mensaje == null)
                        break;

                    MensajeRecibido?.Invoke(mensaje);
                }
            }
            catch (Exception ex)
            {
                if (_conectado)
                    Error?.Invoke(ex.Message);
            }
            finally
            {
                _conectado = false;
                Desconectado?.Invoke();
            }
        }
    }
}
