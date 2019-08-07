using System;
using System.Linq;
using System.Reflection;

namespace WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
			var classes = Assembly.Load("Camc.ZTCost.Application.Shared").GetTypes();
			foreach (var item in classes)
			{
				
				Console.WriteLine(item.Name);
				if (item.GetInterfaces().Where(c => c.FullName.Contains("IApplicationService")).Count() > 0)
				{
					Console.WriteLine(item.GetInterfaces()[0].FullName);


				}


			}
			Console.ReadLine();
		}

		private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
		{
			return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
		}
	}
}
