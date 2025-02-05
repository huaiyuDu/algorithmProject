﻿using System;
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

        protected IExecuteObserver executeObserver;

        private IAlgorithmInput singleInput;

        private List<IAlgorithmInput> batchInput;

        protected CancellationToken token;

        private IInputMeta inputMeta;

        public IInputMeta InputMeta => inputMeta;

        public AbstractAlgorithm(IExecuteObserver executeObserver,string defaultSeries = "10,20,50,100,200,500,1000", string defaultN = "5") {
            if (executeObserver == null) {
                executeObserver = new DumyExecuteObserver();
            }
            this.executeObserver = executeObserver;
            inputMeta = new InputMetaData(defaultSeries, defaultN);
        }


        public void execute(CancellationToken token) {
            IAlgorithmInput input = GetInputSingleFiles();
            putCancellToken(token);
            executeObserver.startTask();
            executeObserver.printDebugToConsole($"[{input.FileName}] Start at {DateTime.Now}");
             
            try
            {
                var startTime = DateTime.Now;
                string result = doExecute(input);
                var endTime= DateTime.Now;
                writeFile(result, input.InputFilePath.Replace(".input", ".output"));
                executeObserver.printResult("execute result:  "+result, true);
                executeObserver.printDebugToConsole($"[{input.FileName}] End at {DateTime.Now}");
                executeObserver.SetStatitcis(GetInputSingleFiles(), (long)(endTime - startTime).TotalMilliseconds, -1);
                test(result, input.InputFilePath.Replace(".input", ".result"));
            }
            catch (OperationCanceledException E)
            {
                executeObserver.printConsole(E.Message);
            }
            finally {
                executeObserver.finishTask();
            }


        }



        protected abstract string doExecute(IAlgorithmInput input);

        protected virtual void putCancellToken(CancellationToken token)
        {
        }

        public void executeBatch(IProgress<int> progress, CancellationToken token, bool executeCompair = false)
        {
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
                    input.Result=(true, "start");
                    executeObserver.updateTask(input, index);
                    executeObserver.printDebugToConsole($"[{input.FileName}] Start at {DateTime.Now}");
                    var startTime = DateTime.Now;
                    input.ExecuteCompairAlgorithm = executeCompair;
                    string result = doExecute(input);
                    var endTime = DateTime.Now;
                    executeObserver.printDebugToConsole(result);
                    executeObserver.printDebugToConsole($"[{input.FileName}] End at {DateTime.Now}");
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
                executeObserver.BatchFinished(batchInputs, executeCompair);
            }
            
        }

        private void test(string result,string resultFilePath) {
            try {
                using (StreamReader sw = new StreamReader(resultFilePath))
                {
                    string expectResult = sw.ReadToEnd();
                    executeObserver.printResult($"expected result: {expectResult}");
                    if (expectResult.TrimEnd(Environment.NewLine.ToCharArray()).Equals(result.TrimEnd(Environment.NewLine.ToCharArray())))
                    {
                        executeObserver.printResult($"Test Result: True");
                    }
                    else {
                        executeObserver.printResult($"Test Result: False");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                executeObserver.printResult($"No expect result file");
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
                    string fileName = $"{path}{Path.DirectorySeparatorChar}{GetAlgorithmName()}_{n}_{index}.input";
                    createInputFile(fileName,n);
                    executeObserver.printDebugToConsole($"{fileName} created");
                    index++;
                }
                
            }
            return null;

        }
        protected abstract string createInputFile(string fileName, long n);

        public virtual bool supportCompairAlogirthm()
        {
            return false;
        }
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

        private long? executeTime = null;

        private long? n;

        private bool executeCompairAlgorithm;

        public bool ExecuteCompairAlgorithm { 
            get => executeCompairAlgorithm; 
            set => executeCompairAlgorithm = value; }

        public long? ExecuteTime { 
            get => executeTime; 
            set => executeTime = value; }

        public long? N { get => n; set => n = value; }
        public (bool? res, string description) Result { get => (res, description); set  { res = value.res; this.description = value.description; } }

        public string InputFilePath => filePath;

        public string FileName => filePath.Substring(filePath.LastIndexOf(Path.DirectorySeparatorChar) + 1);

        public AbstractAlgorithmInput(string filePath) {
            this.filePath = filePath;
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

        public void printResult(string result,bool cleanResult)
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

        public void BatchFinished(List<IAlgorithmInput> batchInputs, bool executeComparison)
        {
            throw new NotImplementedException();
        }
    }
}
