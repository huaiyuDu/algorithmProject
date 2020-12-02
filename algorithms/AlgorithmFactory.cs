using algorithmProject.algorithms.devideconquer.pingpong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmProject.algorithms
{
    class AlgorithmFactory
    {
        public const string PING_PONG = "pingpong";
        public static IAlgorithm getAlorithm(string name, IExecuteObserver executeObserve = null) {
            switch (name)
            {
                case PING_PONG:
                    return new PingPongAlgorithm(executeObserve);
                default:
                    break;
            }
            return null;
        }
    }
}
