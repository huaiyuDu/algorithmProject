using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace algorithmProject.algorithms
{



    public abstract class AbstractAlgorithm : IAlgorithm
    {

        private IExecuteObserver executeObserver;

        private IAlgorithmInput singleInput;

        private List<IAlgorithmInput> batchInput;

        protected CancellationToken token;

        public AbstractAlgorithm(IExecuteObserver executeObserver) {
            if (executeObserver == null) {
                executeObserver = new DumyExecuteObserver();
            }
            this.executeObserver = executeObserver;


        }


        public void execute(CancellationToken token) {
            IAlgorithmInput input = GetInputSingleFiles();
            putCancellToken(token);
            executeObserver.startTask();
            executeObserver.printDebugToConsole($"{input.GetFileName()}Start at {DateTime.Now}");
             
            try
            {
                var startTime = DateTime.Now;
                (string result, long rumtime) = doExecute(input);
                var endTime= DateTime.Now;
                writeFile(result, input.GetInputFilePath()+".out");
                executeObserver.printResult(result);
                executeObserver.printDebugToConsole($"End at {DateTime.Now}");
                executeObserver.SetStatitcis(GetInputSingleFiles(), (long)(endTime - startTime).TotalMilliseconds, -1);
            }
            catch (OperationCanceledException E)
            {
                executeObserver.printConsole(E.Message);
            }
            finally {
                executeObserver.finishTask();
            }


        }



        protected abstract (string, long) doExecute(IAlgorithmInput input);

        protected virtual void putCancellToken(CancellationToken token)
        {
        }

        public void executeBatch(IProgress<int> progress, CancellationToken token){
            this.token = token;
            putCancellToken(token);
            executeObserver.startBatchTask();
            List<IAlgorithmInput> batchInputs = this.GetBatchInputFiles();
            int index = 0;
            try
            {
                foreach (IAlgorithmInput input in batchInputs)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                    input.SetResult(true, "start");
                    executeObserver.updateTask(input, index);
                    executeObserver.printDebugToConsole($"{input.GetFileName()}Start at {DateTime.Now}");
                    var startTime = DateTime.Now;
                    (string result, long rumtime) = doExecute(input);
                    var endTime = DateTime.Now;
                    executeObserver.printDebugToConsole(result);
                    executeObserver.printDebugToConsole($"End at {DateTime.Now}");
                    executeObserver.SetStatitcis(input, (long)(endTime - startTime).TotalMilliseconds, index);
                    index = index + 1;
                    progress.Report(index * 100 / batchInputs.Count);
                }
            }
            catch (OperationCanceledException E)
            {
                executeObserver.printConsole(E.Message);
            }
            finally {
                executeObserver.BatchFinished(batchInputs);
            }
            
        }

        protected void writeFile(string result, string fileName) {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine(result);
            }
            executeObserver.printDebugToConsole($"output file write to {fileName}");
        }

        protected void checkCancel() {
            if (token.IsCancellationRequested)
            {
                throw new OperationCanceledException("the task canceled");
            }
        }
        public void executeBatch() {
            executeBatch(DumyProgress.DUMY_PROGRESS, CancellationToken.None);
        }
        public abstract string GetAlgorithmName();
        public IAlgorithmInput GetInputSingleFiles() {
            return singleInput;
        }

        public void SetBatchInputFiles(List<IAlgorithmInput> batchInput) {
            this.batchInput = batchInput;
        }

        public List<IAlgorithmInput> GetBatchInputFiles()
        {
            return batchInput;
        }

        public void SetInputSingleFiles(IAlgorithmInput input) {
            this.singleInput = input;
         }

        public List<IAlgorithmInput> createInputFiles(string path, string n_series, int number)
        {
            
            string[] series = n_series.Split(',');
            int index = 0;
            foreach (string nstr in series) {
                long n = long.Parse(nstr);
                for (int i= 0; i < number; i++) {
                    string fileName = $"{path}{Path.DirectorySeparatorChar}{GetAlgorithmName()}_{n}_{index}.txt";
                    createInputFile(fileName,n);
                    executeObserver.printDebugToConsole($"{fileName} created");
                    index++;
                }
                
            }
            return null;

        }
        protected abstract string createInputFile(string fileName, long n);
    }

    public class BaseAlgorithmInput : AbstractAlgorithmInput {
        public BaseAlgorithmInput(string filePath):base(filePath)
        {
        }
    }

    public class DumyProgress : IProgress<int>
    {
        public static readonly DumyProgress DUMY_PROGRESS  = new DumyProgress();

        public DumyProgress() { 
        }
        public void Report(int value)
        {
            Console.WriteLine($"{value}%");
            //throw new NotImplementedException();
        }
    }
    public abstract class AbstractAlgorithmInput: IAlgorithmInput
    {
        private string filePath;

        private string description;

        private bool? res = null;

        private long? time = null;

        private long? n;


        public AbstractAlgorithmInput(string filePath) {
            this.filePath = filePath;
        }

        public string GetInputFilePath()
        {
            return filePath;
        }

        public void SetResult(bool res, string description)
        {
            this.res = res;
            this.description = description;
        }

        public void SetExecuteTime(long time)
        {
            this.time = time;
        }

        public string GetFileName()
        {
            return filePath.Substring(filePath.LastIndexOf(Path.DirectorySeparatorChar)+1);
        }

        public long? GetExecuteTime()
        {
            return time;
        }

        public long? getN()
        {
            return n;
        }

        public void setN(long n)
        {
            this.n = n;
        }

        public (bool? res, string description) GetResult()
        {
            return (res, description);
        }
    }

    public class DumyExecuteObserver : IExecuteObserver
    {

        public void printDebugToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public void printConsole(string message)
        {
            Console.WriteLine(message);
        }

        public void printResult(string result)
        {
            Console.WriteLine(result);
        }


        public void SetStatitcis(IAlgorithmInput input, long time)
        {
            Console.WriteLine($"{input} excuted {time}");
        }

        public void SetStatitcis(IAlgorithmInput input, long time, int index)
        {
            throw new NotImplementedException();
        }

        public void taskBegin(IAlgorithmInput input, int index)
        {
            throw new NotImplementedException();
        }

        public void BatchFinished(List<IAlgorithmInput> batchInputs)
        {
            throw new NotImplementedException();
        }

        public void updateTask(IAlgorithmInput input, int index)
        {
            throw new NotImplementedException();
        }

        public void setPercentage(int percentage)
        {
            throw new NotImplementedException();
        }

        public void startBatchTask()
        {
            throw new NotImplementedException();
        }

        public void startTask()
        {
            throw new NotImplementedException();
        }

        public void finishTask()
        {
            throw new NotImplementedException();
        }
    }
}
