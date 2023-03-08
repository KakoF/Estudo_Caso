using App.Metrics;
using App.Metrics.Counter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Metrics
{
    public class MetricsRegistry
    {
        public static CounterOptions SimianDnaResult => new CounterOptions
        {
            Name = "Simian Dna Result",
            Context = "SimianService ",
            
            MeasurementUnit = Unit.Calls
        };

        public static CounterOptions SimianStats => new CounterOptions
        {
            Name = "Simian Status Result",
            Context = "SimianController",
            MeasurementUnit = Unit.Calls
        };
    }
}
