using ComPortTerminal.Domain.Connections.Realization.Com;
using ComPortTerminal.Domain.Protocols.Realization.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPortTerminal.Controller
{
    public class Controller
    {
        private Connection _conn;
        private Protocol _protocol;

        public Controller()
        {
            _conn = new Connection();
            _protocol = new Protocol();
        }

        /// <summary>
        /// Connect to link with ID "connection"
        /// </summary>
        /// <param name="connection">Link ID</param>
        /// <returns>ResponseConnect</returns>
        public ResponseConnect Connect(string connection)
        {
            return new ResponseConnect { };
        }

        /// <summary>
        /// Returns Available Connections
        /// </summary>
        /// <returns>ResponseAvailableConnections</returns>
        public ResponseAvailableConnections DisplayAvailableConnections()
        {            
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
            return new Response { };
        }

        /// <summary>
        /// Sets Angles of Quadropter
        /// </summary>
        /// <param name="ang">RequestSetAngles</param>
        /// <returns></returns>
        public Response TransferAngles(RequestSetAngles ang)
        {
            return new Response { };
        }

        /// <summary>
        /// Delegate to handle input parameters
        /// </summary>
        public delegate void NewParametersHandler();
        
        /// <summary>
        /// Sets ParametersHandler when data recieved
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public Response SetParametersHandler(NewParametersHandler handler)
        {
            return new Response{ };
        }

        /// <summary>
        /// Starts log
        /// </summary>
        /// <param name="path">Path where log will be save</param>
        /// <returns>Response</returns>
        public Response StartLog(string path)
        {
            return new Response{ };
        }

        /// <summary>
        /// Stop Log parameters in format "time, 
        /// </summary>
        /// <returns></returns>
        public Response StopLog()
        {
            return new Response { };
        }

        public class Response
        {
            public string Message { get; set; }
            public bool isError { get; set; }
        }
        public class ResponseAvailableConnections : Response
        {
            public string[] Connections { get; set; }
        }
        public class ResponseConnect : Response
        {
            public string Connection { get; set; }
        }
        public class RequestSetAngles
        {
            public int LTAngle;
            public int RTAngle;
            public int LBAngle;
            public int RBAngle;
        }
    }
}
