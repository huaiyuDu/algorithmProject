using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmProject.algorithms
{



    public abstract class AbstractAlgorithm : IAlgorithm
    {

        private IExecuteObserver executeObserver;

        private IAlgorithmInput singleInput;

        private List<IAlgorithmInput> batchInput; 

        public AbstractAlgorithm(IExecuteObserver executeObserver) {
            if (executeObserver == null) {
                executeObserver = new DumyExecuteObserver();
            }
            this.executeObserver = executeObserver;


        }

 
        public void execute() {
            IAlgorithmInput input = GetInputSingleFiles();
            executeObserver.printDebugToConsole($"{input.GetFileName()}Start at {DateTime.Now}");
            long startTime = System.DateTime.Now.Millisecond;
            (string result, long rumtime) = doExecute(input);
            executeObserver.printResult(result);
            long endTime = System.DateTime.Now.Millisecond;
            executeObserver.printDebugToConsole($"End at {DateTime.Now}");
            executeObserver.SetStatitcis(GetInputSingleFiles(), rumtime, -1);
        }

        protected abstract (string,long) doExecute(IAlgorithmInput input);
        public void executeBatch() {
            List < IAlgorithmInput >  batchInputs = this.GetBatchInputFiles();
            int index = 0;
            foreach  (IAlgorithmInput input in batchInputs) {
                input.SetResult(true, "start");
                executeObserver.updateTask(input, index);
                executeObserver.printDebugToConsole($"{input.GetFileName()}Start at {DateTime.Now}");
                long startTime = DateTime.Now.Ticks;
                //System.Console.WriteLine(startTime);
                (string result, long rumtime) = doExecute(input);
                executeObserver.printResult(result);
                long endTime = DateTime.Now.Ticks;
                //System.Console.WriteLine(endTime);
                //System.Console.WriteLine(endTime - startTime);
                executeObserver.printDebugToConsole($"End at {DateTime.Now}");
                executeObserver.SetStatitcis(input, rumtime, index);
                index = index + 1;
            }

            executeObserver.BatchFinished(batchInputs);
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
            if (string.IsNullOrEmpty(path)) {
                throw new Exception("please choose file path");
            }
            if (string.IsNullOrEmpty(n_series))
            {
                throw new Exception("please input N series");
            }

            if (number == 0)
            {
                throw new Exception("please input case number for each N");
            }
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
            Console.WriteLine($"{input} excuted {time}"  );
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
    }
}
