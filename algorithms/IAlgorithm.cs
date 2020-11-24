﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmProject.algorithms
{
    interface IAlgorithm
    {
        public string GetAlgorithmName();


        public void execute();

        public void executeBatch();

        public void SetInputSingleFiles(IAlgorithmInput input);

        public IAlgorithmInput GetInputSingleFiles();

        public void SetBatchInputFiles(List<IAlgorithmInput> batchInput);

        public List<IAlgorithmInput> createInputFiles(string path);

    }
    public interface IAlgorithmInput
    {
        //public void init();

        //public void release();

        public string GetInputFilePath();

        public void SetResult(bool res, string description);

        public void SetExecuteTime(long time);
    }

    public interface IExecuteObserver {


        public void printDebugToConsole(string message); 

        public void printConsole(string message);

        public void printResult(string result);

        public void SetStatitcis(IAlgorithmInput input, long time);
    }
}
