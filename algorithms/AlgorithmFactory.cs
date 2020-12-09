using algorithmProject.algorithms.devideconquer;
using algorithmProject.algorithms.devideconquer.pingpong;
using algorithmProject.algorithms.dynamicprograming;
using algorithmProject.algorithms.greedy;
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
        public const string HUFFMAN = "huffman";
        public const string ACTIVIT_SELECTION_DYN = "ActivitSelDyn";
        public const string ACTIVIT_SELECTION_GREEDY = "ActivitSelGreedy";
        public const string CLOSEST_PAIR_POINTS = "CloestPairPoints"; 
        public static IAlgorithm getAlorithm(string name, IExecuteObserver executeObserve = null) {
            switch (name)
            {
                case PING_PONG:
                    return new PingPongAlgorithm(executeObserve);
                case HUFFMAN:
                    return new HuffmanCode(executeObserve);
                case ACTIVIT_SELECTION_DYN:
                    return new ActivitySeletionDynamic(executeObserve);
                case ACTIVIT_SELECTION_GREEDY:
                    return new ActivitySelectionGreedy(executeObserve);
                case CLOSEST_PAIR_POINTS:
                    return new CloestPairPoints(executeObserve);

                default:
                    break;
            }
            return null;
        }
    }
}
