using Abp.Application.Services;
using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Camc.MES53
{
	public class MidPlatDynamicClass<T>
	{
		//public string MidPlatServiceNameSpace
		public MidPlatDynamicClass()
		{

		}

		public T CreateInstance()
		{
			//var provOptions = new Dictionary<string, string>();
			//provOptions.Add("CompilerVersion", "v3.5");

			//CodeDomProvider codeDomProvider = new CSharpCodeProvider(provOptions);
			//CompilerParameters compilerParameters = new CompilerParameters();
			//compilerParameters.GenerateExecutable = false;
			//compilerParameters.GenerateInMemory = true;
			//compilerParameters.ReferencedAssemblies.Add("mscorlib.dll");
			//compilerParameters.ReferencedAssemblies.Add("System.dll");
			//compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
			//string[] code = new string[1];
			//code[0] = GenerateCode();
			//CompilerResults compilerResults =
			//codeDomProvider.CompileAssemblyFromSource(compilerParameters, code);

			//Assembly ass = compilerResults.CompiledAssembly;
			//var obj = ass.GetTypes().FirstOrDefault();
			//return (T)Activator.CreateInstance(obj);



			var provOptions = new Dictionary<string, string>();
			provOptions.Add("CompilerVersion", "v3.5");

			CodeDomProvider codeDomProvider = new CSharpCodeProvider(provOptions);
			CompilerParameters compilerParameters = new CompilerParameters();
			compilerParameters.GenerateExecutable = false;
			compilerParameters.GenerateInMemory = true;
			compilerParameters.ReferencedAssemblies.Add("mscorlib.dll");
			compilerParameters.ReferencedAssemblies.Add("System.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Core.dll");


			string[] code = new string[1];
			code[0] = GenerateCode();
			CompilerResults compilerResults = codeDomProvider.CompileAssemblyFromSource(compilerParameters, code);


			Assembly ass = compilerResults.CompiledAssembly;
			var obj = ass.GetTypes().FirstOrDefault();
			return (T)Activator.CreateInstance(obj);

			// Invoke compilation.
			
		}

		public string GenerateCode()
		{
			CodeCompileUnit lUnit = new CodeCompileUnit();

			CodeNamespace lNamespace = new CodeNamespace("MyNamespace");
			lNamespace.Imports.Add(new CodeNamespaceImport("System"));
			lUnit.Namespaces.Add(lNamespace);

			CodeTypeDeclaration lClass = new CodeTypeDeclaration("MyClass");
			lClass.IsClass = true;
			lClass.Attributes = MemberAttributes.Public;
			lNamespace.Types.Add(lClass);


			// -----------------------------------------------
			// method DoSomething()
			// -----------------------------------------------

			CodeTypeParameter lClassAsParameter = new CodeTypeParameter(lClass.Name);
			CodeTypeReference lClassReference = new CodeTypeReference(lClassAsParameter);
			CodeParameterDeclarationExpression lClassExpression = new CodeParameterDeclarationExpression(lClassReference, "xClass");
			CodeMemberMethod lDoSomething = new CodeMemberMethod();
			lDoSomething.Attributes = MemberAttributes.Public;
			lDoSomething.Comments.Add(new CodeCommentStatement("This is an example comment for our method DoSomething()."));
			lDoSomething.Name = "DoSomething";
			lDoSomething.ReturnType = new CodeTypeReference(typeof(double));
			lDoSomething.Parameters.Add(new CodeParameterDeclarationExpression(typeof(int), "xInteger"));
			lDoSomething.Parameters.Add(new CodeParameterDeclarationExpression(typeof(string), "xString"));
			lDoSomething.Parameters.Add(lClassExpression);
			lDoSomething.Statements.Add(new CodeMethodReturnStatement(new CodePrimitiveExpression(1.0)));
			lClass.Members.Add(lDoSomething);


			// -----------------------------------------------
			// private field _MyField
			// -----------------------------------------------

			CodeMemberField lField = new CodeMemberField(typeof(long), "_MyField");
			lField.Attributes = MemberAttributes.Private;
			lField.InitExpression = new CodePrimitiveExpression(10);
			lClass.Members.Add(lField);



			// -----------------------------------------------
			// Main()
			// -----------------------------------------------

			CodeEntryPointMethod lMain = new CodeEntryPointMethod();
			lClass.Members.Add(lMain);

			// local double variable d
			CodeVariableReferenceExpression lLocalVariable_d = new CodeVariableReferenceExpression("d");
			CodeVariableDeclarationStatement lLocalVariableStatement_d = new CodeVariableDeclarationStatement(typeof(double), lLocalVariable_d.VariableName);
			lMain.Statements.Add(lLocalVariableStatement_d);

			// local integer variable i
			CodeVariableReferenceExpression lLocalVariable_i = new CodeVariableReferenceExpression("i");
			CodeVariableDeclarationStatement lLocalVariableStatement_i = new CodeVariableDeclarationStatement(typeof(int), lLocalVariable_i.VariableName);
			lLocalVariableStatement_i.InitExpression = new CodePrimitiveExpression(0);
			lMain.Statements.Add(lLocalVariableStatement_i);

			// local class variable MyClass
			CodeVariableReferenceExpression lLocalVariable_Class = new CodeVariableReferenceExpression("lClass");
			CodeVariableDeclarationStatement lLocalVariableStatement_Class = new CodeVariableDeclarationStatement(lClassReference, lLocalVariable_Class.VariableName);
			lLocalVariableStatement_Class.InitExpression = new CodeObjectCreateExpression(lClass.Name, new CodeExpression[] { });
			lMain.Statements.Add(lLocalVariableStatement_Class);

			// DoSomething() method call
			CodeMethodInvokeExpression lDoSomethingExpression = new CodeMethodInvokeExpression(lLocalVariable_Class, lDoSomething.Name, new CodeExpression[] { lLocalVariable_i, new CodePrimitiveExpression("hello"), lLocalVariable_Class });
			CodeAssignStatement lAssignment = new CodeAssignStatement(lLocalVariable_d, lDoSomethingExpression);
			lMain.Statements.Add(lAssignment);

			// -----------------------------------------------
			// create source code
			// -----------------------------------------------

			string lDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\";
			CodeGeneratorOptions lOptions = new CodeGeneratorOptions();
			lOptions.IndentString = "  "; // or "\t";
			lOptions.BlankLinesBetweenMembers = true;

			// generate a C# source code file
			CSharpCodeProvider lCSharpCodeProvider = new CSharpCodeProvider();

			StringWriter Text = new StringWriter();
				 
			
			lCSharpCodeProvider.GenerateCodeFromCompileUnit(lUnit, Text, lOptions);

			return Text.ToString();
		}

	}
}
