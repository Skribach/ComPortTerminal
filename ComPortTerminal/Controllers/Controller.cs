using QuadcopterConfigurator.Domain.Connections.Realization.Com;
using QuadcopterConfigurator.Domain.Logger.Realization.TextLogger;
using QuadcopterConfigurator.Domain.Protocols.Realization.v1;
using System;
using System.Threading.Tasks;
using static QuadcopterConfigurator.Domain.Protocols.Realization.v1.Protocol;
using static QuadcopterConfigurator.Global;

namespace QuadcopterConfigurator.Controllers
{
    public class Controller
    {
        private Connection _conn;
        private Protocol _protocol;
        private TextLogger _logger;
        private BladeAngles _angles;

        public Parameters parameters;
        public Controller()
        {
            _conn = new Connection();
            _protocol = new Protocol(_conn);
            _protocol.SetRecievedParametersHandler(_recievedParametersHandler);


            _logger = new TextLogger();
            parameters = new Parameters();
        }

        public Statuses GetStatus() => _protocol.GetStatus();

        private void _recievedParametersHandler(Parameters param)
        {
            parameters = param;
            if (_logger.isRunning)
            {
                _logger.Log(parameters);
            }
        }

        /// <summary>
        /// Connect to link with ID "connection"
        /// </summary>
        /// <param name="connection">Link ID</param>
        /// <returns>ResponseConnect</returns>
        public Response Connect(string connection)
        {
            return _protocol.Connect(connection);
        }

        public async Task<ConnResponse> AutoConnectAsync()
        {
            return await _protocol.AutoConnectAsync();
        }

        /// <summary>
        /// Returns Available Connections
        /// </summary>
        /// <returns>ResponseAvailableConnections</returns>
        public ResponseAvailableConnections DisplayAvailableConnections()
        {            
            return new ResponseAvailableConnections
            {
                Connections = _conn.GetAvailableConnections(),
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
        public async Task<Response> SetAngles(BladeAngles ang)
        {
            _angles = ang;
            var resp = await _protocol.SetAnglesAsync(
                _angles);            
            return resp;
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

        /// <summary>
        /// Stop Log parameters in format "time, 
        /// </summary>
        /// <returns></returns>
        public Response StopLog(string path)
        {
            _logger.Stop(path);
            return new Response
            {
                Message = "Log file was saved",
                isCanceled = false,
                isError = false,
            };
        }

        public class ResponseAvailableConnections : Response
        {
            public string[] Connections { get; set; }
        }
    }
}
