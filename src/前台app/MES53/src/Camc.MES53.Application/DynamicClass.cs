using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Camc.MES53
{
    public class DynamicClass 
	{
		string testClass = @"using System; 
		namespace test{

		 public class tes
		 {

		   public string unescape(string Text)
		  { 
			return Uri.UnescapeDataString(Text);
		  } 

		 }

		}";



		

		public DynamicClass()
		{
			var dd = typeof(Enumerable).GetTypeInfo().Assembly.Location;
			var coreDir = Directory.GetParent(dd);

			var compilation = CSharpCompilation.Create(Guid.NewGuid().ToString() + ".dll")
				.WithOptions(new CSharpCompilationOptions(Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary))
				.AddReferences(
				MetadataReference.CreateFromFile(typeof(Object).GetTypeInfo().Assembly.Location),
				MetadataReference.CreateFromFile(typeof(Uri).GetTypeInfo().Assembly.Location),
				MetadataReference.CreateFromFile(coreDir.FullName + Path.DirectorySeparatorChar + "mscorlib.dll"),
				MetadataReference.CreateFromFile(coreDir.FullName + Path.DirectorySeparatorChar + "System.Runtime.dll")
				)
				.AddSyntaxTrees(CSharpSyntaxTree.ParseText(testClass));

			var eResult = compilation.Emit("test.dll");
		}

		//Dictionary<string, object> dictionary = new Dictionary<string, object>();
		//public DynamicClass(Type type)
		//{
		//	dictionary.Add("Title", "Hello World!");
		//	dictionary.Add("Text", "My first post");
		//	dictionary.Add("Tags", new[] { "hello", "world" });
		//}

		//public override bool TryGetMember(GetMemberBinder binder, out object result)
		//{
		//	return dictionary.TryGetValue(binder.Name, out result);
		//}

		//// If you try to set a value of a property that is
		//// not defined in the class, this method is called.
		//public override bool TrySetMember(
		//	SetMemberBinder binder, object value)
		//{
		//	// Converting the property name to lowercase
		//	// so that property names become case-insensitive.
		//	dictionary[binder.Name.ToLower()] = value;

		//	// You can always add a value to a dictionary,
		//	// so this method always returns true.
		//	return true;
		//}

		//// Calling a method.
		//public override bool TryInvokeMember(
		//	InvokeMemberBinder binder, object[] args, out object result)
		//{
		//	Type dictType = typeof(Dictionary<string, object>);
		//	try
		//	{
		//		result = dictType.InvokeMember(
		//					 binder.Name,
		//					 BindingFlags.InvokeMethod,
		//					 null, dictionary, args);
		//		return true;
		//	}
		//	catch
		//	{
		//		result = null;
		//		return false;
		//	}
		//}

	}
}
