using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.ConsoleApp.Tests
{
    class Test : BaseTest
    {
        public override void Init()
        {
            var a = EmitCreateClass.Create();
            a.PrintClassAType();
            Console.Read();
        }
    }

    public abstract class ClassA
    {
        protected string name = "a";
        public abstract void PrintClassAType();
    }
    public class ClassB
    {
        protected string name = "b";
        public void PrintClassBType()
        {
            Console.WriteLine(name);
            Console.WriteLine(string.Format("this.GetType() in class ClassB is：{0}.", this.GetType()));
        }
    }

    public class EmitCreateClass
    {
        public static ClassA Create()
        {
            var assemblyName = new AssemblyName("MyAssembly");
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("MyModule", "myclasses.dll");
            var typeBuilder = moduleBuilder.DefineType("ClassC", TypeAttributes.Public | TypeAttributes.Class, typeof(ClassA));
            CreateClass(typeBuilder);
            var t = typeBuilder.CreateType();
            assemblyBuilder.Save("myclasses.dll");
            object obj = Activator.CreateInstance(t);
            return obj as ClassA;
        }

        private static void CreateClass(TypeBuilder typeBuilder)
        {
            // ---- define fields ----
            var fieldClassA = typeBuilder.DefineField("_a", typeof(ClassA), FieldAttributes.Private);
            fieldClassA.SetConstant(default(ClassA));

            // ---- define costructors ----
            var constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, null);
            var ilOfCtor = constructorBuilder.GetILGenerator();
            ilOfCtor.Emit(OpCodes.Ldarg_0);
            ilOfCtor.Emit(OpCodes.Ldarg_0);
            ilOfCtor.Emit(OpCodes.Stfld, fieldClassA);
            //
            ilOfCtor.Emit(OpCodes.Ret);

            // ---- define methods ----
            var methodInfo = typeof(ClassA).GetMethod("PrintClassAType");

            var parameterTypes = methodInfo.GetParameters().Select(p => p.ParameterType).ToArray();
            var methodBuilder = typeBuilder.DefineMethod(
                methodInfo.Name,
                MethodAttributes.Public | MethodAttributes.Virtual,
                CallingConventions.Standard,
                methodInfo.ReturnType,
                parameterTypes);

            var methodIL = methodBuilder.GetILGenerator();
            methodIL.Emit(OpCodes.Ldnull);
            methodIL.Emit(OpCodes.Ldarg_0);
            methodIL.Emit(OpCodes.Ldfld, fieldClassA);

            // call PrintType() method of ClassB
            methodIL.Emit(OpCodes.Callvirt, typeof(ClassB).GetMethod("PrintClassBType"));

            // pop the stack if return void
            if (methodInfo.ReturnType == typeof(void))
            {
                methodIL.Emit(OpCodes.Pop);
            }
            // complete
            methodIL.Emit(OpCodes.Ret);

        }
    }
}
