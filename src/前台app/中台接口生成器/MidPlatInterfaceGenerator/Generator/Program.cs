using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Generator
{
	class Program
	{
		public static void Main()
		{
			//foreach (var assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
			//{
			//	Assembly assembly = Assembly.Load(assemblyName);
			//	foreach (var type in assembly.GetTypes())
			//	{

			//		Console.WriteLine(type.Name);
			//	}
			//}

			Assembly myAssembly = Assembly.LoadFrom(@"Camc.ZTCost.Application.Shared.dll");

			//Gets all referenced Types of the current Assembly that implement a specific interface
			IEnumerable<Type> currentAssemblytypes = myAssembly.GetTypes();

			//Gets all referenced Types of an assembly that implement a specific interface
			//IEnumerable<Type> otherAssemblyTypes = myAssembly.GetTypes().Where(y => typeof(MyAbractClassName).IsAssignableFrom(y) && !y.IsInterface);

			//You can also change IsInterface to IsAbstract if you are checking for types that implement an Abstract Class.
			//IEnumerable<Type> otherAssemblyTypesAbstract = myAssembly.GetTypes().Where(y => typeof(MyAbractClassName).IsAssignableFrom(y) && !y.IsAbstract);

			foreach (var type in currentAssemblytypes)
			{

				Console.WriteLine(type.FullName);
			}
			

			Console.ReadLine();

			GenerateCSharpCode(BuildHelloWorldGraph());

			CompileCSharpCode("HelloWorld.cs", "HelloWorld.dll");
		}

		public static string GenerateCSharpCode(CodeCompileUnit compileunit)
		{
			// Generate the code with the C# code provider.
			CSharpCodeProvider provider = new CSharpCodeProvider();

			// Build the output file name.
			string sourceFile;
			if (provider.FileExtension[0] == '.')
			{
				sourceFile = "HelloWorld" + provider.FileExtension;
			}
			else
			{
				sourceFile = "HelloWorld." + provider.FileExtension;
			}

			// Create a TextWriter to a StreamWriter to the output file.
			using (StreamWriter sw = new StreamWriter(sourceFile, false))
			{
				IndentedTextWriter tw = new IndentedTextWriter(sw, "    ");

				// Generate source code using the code provider.
				provider.GenerateCodeFromCompileUnit(compileunit, tw,
					new CodeGeneratorOptions());

				// Close the output file.
				tw.Close();
			}

			return sourceFile;
		}

		public static bool CompileCSharpCode(string sourceFile, string exeFile)
		{
			CSharpCodeProvider provider = new CSharpCodeProvider();

			// Build the parameters for source compilation.
			CompilerParameters cp = new CompilerParameters();

			// Add an assembly reference.
			cp.ReferencedAssemblies.Add("System.dll");

			// Generate an executable instead of
			// a class library.
			cp.GenerateExecutable = false;

			// Set the assembly file name to generate.
			cp.OutputAssembly = exeFile;

			// Save the assembly as a physical file.
			cp.GenerateInMemory = false;


			// Invoke compilation.
			CompilerResults cr = provider.CompileAssemblyFromFile(cp, sourceFile);

			if (cr.Errors.Count > 0)
			{
				// Display compilation errors.
				Console.WriteLine("Errors building {0} into {1}",
					sourceFile, cr.PathToAssembly);
				foreach (CompilerError ce in cr.Errors)
				{
					Console.WriteLine("  {0}", ce.ToString());
					Console.WriteLine();
				}
			}
			else
			{
				Console.WriteLine("Source {0} built into {1} successfully.",
					sourceFile, cr.PathToAssembly);
			}

			// Return the results of compilation.
			if (cr.Errors.Count > 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public static CodeCompileUnit BuildHelloWorldGraph()
		{
			// Create a new CodeCompileUnit to contain 
			// the program graph.
			CodeCompileUnit compileUnit = new CodeCompileUnit();

			// Declare a new namespace called Samples.
			CodeNamespace samples = new CodeNamespace(ConfigurationManager.AppSettings.Get("Key0"));
			// Add the new namespace to the compile unit.
			compileUnit.Namespaces.Add(samples);

			// Add the new namespace import for the System namespace.
			samples.Imports.Add(new CodeNamespaceImport("System"));

			// Declare a new type called Class1.
			CodeTypeDeclaration class1 = new CodeTypeDeclaration("Class1");
			// Add the new type to the namespace type collection.
			samples.Types.Add(class1);

			// Declare a new code entry point method.
			CodeEntryPointMethod start = new CodeEntryPointMethod();

			// Create a type reference for the System.Console class.
			CodeTypeReferenceExpression csSystemConsoleType = new CodeTypeReferenceExpression("System.Console");

			// Build a Console.WriteLine statement.
			CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
				csSystemConsoleType, "WriteLine",
				new CodePrimitiveExpression("Hello World!"));

			// Add the WriteLine call to the statement collection.
			start.Statements.Add(cs1);

			// Build another Console.WriteLine statement.
			CodeMethodInvokeExpression cs2 = new CodeMethodInvokeExpression(
				csSystemConsoleType, "WriteLine",
				new CodePrimitiveExpression("Press the Enter key to continue."));

			// Add the WriteLine call to the statement collection.
			start.Statements.Add(cs2);

			// Build a call to System.Console.ReadLine.
			CodeMethodInvokeExpression csReadLine = new CodeMethodInvokeExpression(
				csSystemConsoleType, "ReadLine");

			// Add the ReadLine statement.
			start.Statements.Add(csReadLine);

			// Add the code entry point method to
			// the Members collection of the type.
			class1.Members.Add(start);

			return compileUnit;
		}

	}
}
