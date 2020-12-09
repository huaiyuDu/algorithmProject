using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmProject.algorithms
{
    struct InputMetaData : IInputMeta
    {

        private string defaultSeries;

        private string defaultN;

        public InputMetaData(string defaultSeries, string defaultN)
        {
            this.defaultSeries = defaultSeries;
            this.defaultN = defaultN;
        }

        public string DefaultSeries => defaultSeries;

        public string DefaultN => defaultN;
    }
}
