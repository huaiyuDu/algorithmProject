using algorithmProject.algorithms.dynamicprograming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmProject.algorithms.greedy
{
    class ActivitySelectionGreedy: ActivitySelectionDynamic
    {
        public ActivitySelectionGreedy(IExecuteObserver executeObserver) : base(executeObserver)
        {
        }
        public override string GetAlgorithmName()
        {
            return "Activity Seletion Problem (Greedy)";
        }

        protected override string doExecute(IAlgorithmInput input)
        {
            List<Activity> inputs = readInput(input);
            inputs.Sort(Comparer<Activity>.Create((Activity x, Activity y) => x.End - y.End));
            int n = inputs.Count;
            int?[,] c = new int?[n, n];

            int[,] z = new int[n, n];
            List<Activity> selectedActivity = new List<Activity>();
            Activity lastSelectedActivity = inputs[0];
            //selectedActivity.Add(inputs[i]);
            for (int i = 1; i < n-1; i++)
            {
                if (lastSelectedActivity.End <= inputs[i].Start) {
                    selectedActivity.Add(inputs[i]);
                    lastSelectedActivity = inputs[i];
                    executeObserver.printDebugToConsole(string.Format("Activity:({0}) start:{1}, end:{2}", i, inputs[i].Start, inputs[i].End));

                }
            }
            
            return string.Format("total activity count = {0}", selectedActivity.Count);
        }
    }
}
