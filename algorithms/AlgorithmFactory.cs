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
    public class AlgorithmFactory
    {


        public enum Algorithm {
            PING_PONG,
            HUFFMAN,
            ACTIVIT_SELECTION_DYN,
            ACTIVIT_SELECTION_GREEDY,
            CLOSEST_PAIR_POINTS,
            MULTIPLICATION_MATRICES,
            LCS
        }
        public static IAlgorithm getAlorithm(Algorithm name, IExecuteObserver executeObserve = null) {
            switch (name)
            {
                case Algorithm.PING_PONG:
                    return new PingPongAlgorithm(executeObserve);
                case Algorithm.HUFFMAN:
                    return new HuffmanCode(executeObserve);
                case Algorithm.ACTIVIT_SELECTION_DYN:
                    return new ActivitySelectionDynamic(executeObserve);
                case Algorithm.ACTIVIT_SELECTION_GREEDY:
                    return new ActivitySelectionGreedy(executeObserve);
                case Algorithm.CLOSEST_PAIR_POINTS:
                    return new ClosestPairPoints(executeObserve);
                case Algorithm.MULTIPLICATION_MATRICES:
                    return new MultiplicationSequenceMatrix(executeObserve);
                case Algorithm.LCS:
                    return new LongestCommonSequence(executeObserve);
                default:
                    break;
            }
            return null;
        }
    }
}
