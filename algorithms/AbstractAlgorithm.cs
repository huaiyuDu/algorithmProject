using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmProject.algorithms
{



    abstract class AbstractAlgorithm : IAlgorithm
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

        public abstract List<IAlgorithmInput> createInputFiles(string path);
        public void execute() {
            IAlgorithmInput input = GetInputSingleFiles();
            input.init();
            executeObserver.printDebugToConsole("Start");
            long startTime = System.DateTime.Now.Millisecond;
            doExecute(input);
            long endTime = System.DateTime.Now.Millisecond;
            executeObserver.printDebugToConsole("End");
            executeObserver.SetStatitcis(GetInputSingleFiles().ToString(), startTime - endTime);
            input.release();
        }

        protected abstract string doExecute(IAlgorithmInput input);
        public abstract void executeBatch();
        public abstract string GetAlgorithmName();
        public IAlgorithmInput GetInputSingleFiles() {
            return singleInput;
        }

        public void SetBatchInputFiles(List<IAlgorithmInput> batchInput) {
            this.batchInput = batchInput;
        }
        public void SetInputSingleFiles(IAlgorithmInput input) {
            this.singleInput = input;
         }
    }

    public abstract class AbstractAlgorithmInput: IAlgorithmInput
    {
        public String filePath;
        public AbstractAlgorithmInput(String filePath) {
            this.filePath = filePath;
        }

        public abstract void init();

        public abstract void release();

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

        public void SetStatitcis(string key, long time)
        {
            throw new NotImplementedException();
        }
    }
}
