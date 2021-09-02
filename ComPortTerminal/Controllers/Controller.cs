using ComPortTerminal.Domain.Connections.Realization.Com;
using ComPortTerminal.Domain.Logger.Realization.TextLogger;
using ComPortTerminal.Domain.Protocols.Realization.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ComPortTerminal.Domain.Protocols.Realization.v1.Protocol;
using static ComPortTerminal.Global;

namespace ComPortTerminal.Controllers
{
    public class Controller
    {        
        private Connection _conn;
        private Protocol _protocol;
        private TextLogger _logger;
        private Angles _angles;

        public Parameters parameters;

        public Controller()
        {
            
            _conn = new Connection();
            _protocol = new Protocol(_conn);
            _protocol.SetRecievedParametersHandler(_recievedParametersHandler);
            parameters = new Parameters();
        }

        private void _recievedParametersHandler(Parameters param)
        {
            parameters = param;
            /*_logger.Log(new Data
            {
                angleA = _angles.LBAngle,
                angleB = _angles.RBAngle,
                angleC = _angles.LTAngle,
                angleD = _angles.RTAngle,

                angleX = parameters.x,
                angleY = parameters.y,
                angleZ = parameters.z,
                rpm = parameters.rpm
            });*/
        }

        /// <summary>
        /// Connect to link with ID "connection"
        /// </summary>
        /// <param name="connection">Link ID</param>
        /// <returns>ResponseConnect</returns>
        public async Task<Response> Connect(string connection)
        {
            return await _protocol.ConnectAsync(connection);
        }

        /// <summary>
        /// Returns Available Connections
        /// </summary>
        /// <returns>ResponseAvailableConnections</returns>
        public ResponseAvailableConnections DisplayAvailableConnections()
        {
            _conn.UpdateAvailableConnections();
            return new ResponseAvailableConnections
            {
                Connections = _conn.AvailableConnections,
                isError = false,
                Message = null
            };
        }

        /// <summary>
        /// Disconnect
        /// </summary>
        /// <returns></returns>
        public Response Disconnect()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets Angles of Quadropter
        /// </summary>
        /// <param name="ang">RequestSetAngles</param>
        /// <returns></returns>
        public async Task<Response> SetAngles(Angles ang)
        {
            _angles = ang;
            var resp = await _protocol.SetAnglesAsync(
                ang.LTAngle, ang.RTAngle,
                ang.LBAngle, ang.RBAngle);
            if(!resp.isError)
            {
                _angles.LBAngle = ang.LBAngle;
                _angles.RBAngle = ang.RBAngle;
                _angles.LTAngle = ang.LTAngle;
                _angles.RTAngle = ang.RTAngle;
            }
            return resp;
        }
                        
        /// <summary>
        /// Sets ParametersHandler when data recieved
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>        

        public void SelectLogPath(string path)
        {
            _logger = new TextLogger(path);
        }

        /// <summary>
        /// Starts log
        /// </summary>
        /// <param name="path">Path where log will be save</param>
        /// <returns>Response</returns>
        public Response StartLog()
        {            
            return _logger.Start();
        }

        public void Log(int rpm, double x, double y, double z)
        {
            _logger.Log(new Data
            {
                angleA = _angles.LTAngle,
                angleB = _angles.RTAngle,
                angleC = _angles.LBAngle,
                angleD = _angles.RBAngle,
                angleX = x,
                angleY = y,
                angleZ = z
            });
        }

        /// <summary>
        /// Stop Log parameters in format "time, 
        /// </summary>
        /// <returns></returns>
        public Response StopLog()
        {
            return new Response { };
        }

        public class ResponseAvailableConnections : Response
        {
            public string[] Connections { get; set; }
        }
    }
}
