using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Castle.Core.Logging;
using Castle.DynamicProxy;


namespace Camc.MES53
{
    public class MidPlatServiceInterceptor : IInterceptor
	{
		public ILogger Logger { get; set; }

		public MidPlatServiceInterceptor()
		{
			Logger = NullLogger.Instance;
		}

		public void Intercept(IInvocation invocation)
		{
			//Before method execution
			var stopwatch = Stopwatch.StartNew();

			//Executing the actual method
			invocation.Proceed();

			//After method execution
			stopwatch.Stop();


			Logger.InfoFormat(
				"MeasureDurationInterceptor: {0} executed in {1} milliseconds.",
				invocation.MethodInvocationTarget.Name,
				stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
				);
		}
	}
}
