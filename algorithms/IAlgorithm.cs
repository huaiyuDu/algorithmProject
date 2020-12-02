using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace algorithmProject.algorithms
{
    public interface IAlgorithm
    {

        public string GetAlgorithmName();


        public void execute(CancellationToken token);

        public void executeBatch(IProgress<int> progress, CancellationToken token);

        public void executeBatch();

        public void SetInputSingleFiles(IAlgorithmInput input);

        public IAlgorithmInput GetInputSingleFiles();

        public void SetBatchInputFiles(List<IAlgorithmInput> batchInput);

        public List<IAlgorithmInput> GetBatchInputFiles();

        public List<IAlgorithmInput> createInputFiles(string path,string n_series, int number);

    }
    public interface IAlgorithmInput
    {
        //public void init();

        //public void release();

        public string GetInputFilePath();

        public string GetFileName();

        public void SetResult(bool res, string description);

        public void SetExecuteTime(long time);

        public long? GetExecuteTime();

        public long? getN();

        public void setN(long n);

        public (bool? res, string description) GetResult();


    }

    public interface IExecuteObserver {


        public void printDebugToConsole(string message); 

        public void printConsole(string message);

        public void printResult(string result);

        public void SetStatitcis(IAlgorithmInput input, long time, int index);

        public void updateTask(IAlgorithmInput input, int index);

        public void BatchFinished(List<IAlgorithmInput> batchInputs);

        public void setPercentage(int percentage);

        public void startBatchTask();

        public void startTask();

        public void finishTask();
    }
}
