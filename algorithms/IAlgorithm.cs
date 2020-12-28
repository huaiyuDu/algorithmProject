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

        public bool supportCompairAlogirthm();

        public void execute(CancellationToken token);

        public void executeBatch(IProgress<int> progress, CancellationToken token, bool executeCompair = false);

        public void executeBatch();

        public void SetInputSingleFiles(IAlgorithmInput input);

        public IAlgorithmInput GetInputSingleFiles();

        public void SetBatchInputFiles(List<IAlgorithmInput> batchInput);

        public List<IAlgorithmInput> GetBatchInputFiles();

        public List<IAlgorithmInput> createInputFiles(string path,string n_series, int number);

        public IInputMeta InputMeta { get; }

    }
    public interface IAlgorithmInput
    {

        public abstract bool ExecuteCompairAlgorithm { get; set; }

        public abstract long? ExecuteTime { get; set; }

        public abstract long? N { get; set; }

        public abstract (bool? res, string description) Result { get; set; }

        public abstract string InputFilePath { get; }

        public abstract string FileName { get; }
    }

    public interface IExecuteObserver {


        public void printDebugToConsole(string message); 

        public void printConsole(string message);

        public void printResult(string result, bool cleanResult = false);

        public void SetStatitcis(IAlgorithmInput input, long time, int index);

        public void updateTask(IAlgorithmInput input, int index);

        public void BatchFinished(List<IAlgorithmInput> batchInputs, bool executeComparison);

        public void setPercentage(int percentage);

        public void startBatchTask();

        public void startTask();

        public void finishTask();
    }
}
