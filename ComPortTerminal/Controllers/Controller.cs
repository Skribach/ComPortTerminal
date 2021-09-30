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
        private AliasAngles _aliasAngles;

        public Parameters parameters;
        public Controller()
        {
            _conn = new Connection();
            _protocol = new Protocol(_conn);
            _protocol.SetRecievedParametersHandler(_recievedParametersHandler);            

            _logger = new TextLogger();
            parameters = new Parameters();
            _aliasAngles = new AliasAngles();
        }

        public Statuses GetStatus() => _protocol.GetStatus();

        private void _recievedParametersHandler(Parameters param)
        {
            parameters = new Parameters
            {
                Angles = new BladeAngles
                {
                    A = param.Angles.A - _aliasAngles.A,
                    B = param.Angles.B - _aliasAngles.B,
                    C = param.Angles.C - _aliasAngles.C,
                    D = param.Angles.D - _aliasAngles.D,
                },
                Id = param.Id,
                Gyro = new Gyro
                {
                    x = param.Gyro.x,
                    y = param.Gyro.y,
                    z = param.Gyro.z
                },
                Rpm = param.Rpm
            };

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
        public async Task<Response> SetAngles(BladeAngles ang, AliasAngles alias)
        {
            _aliasAngles = alias;
            ang.A += _aliasAngles.A;
            ang.B += _aliasAngles.B;
            ang.C += _aliasAngles.C;
            ang.D += _aliasAngles.D;

            var resp = await _protocol.SetAnglesAsync(
                ang);            
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
