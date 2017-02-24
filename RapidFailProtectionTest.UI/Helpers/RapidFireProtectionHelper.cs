using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;

namespace RapidFailProtectionTest.UI.Helpers
{
    public class RapidFireProtectionHelper
    {
        public static void StackOverFlowException(int numberOfExceptions)
        {
            Action stackOverflowAction = RecursiveMethod;
            GenerateExceptions(stackOverflowAction, numberOfExceptions);
        }

        public static void AccessViolationException(int numberOfExceptions)
        {
            Action accessViolationAction = AccessViolation;
            GenerateExceptions(accessViolationAction, numberOfExceptions);
        }

        private static void GenerateExceptions(Action action, int numberOfExceptions)
        {
            if (numberOfExceptions == 0)
                numberOfExceptions = 1;

            var tasks = new Task[numberOfExceptions];
            for (var i = 0; i < numberOfExceptions; i++)
            {
                tasks[i] = new Task(action);
            }

            foreach (var task in tasks)
            {
                task.Start();
            }
        }

        // ReSharper disable once FunctionRecursiveOnAllPaths
        private static void RecursiveMethod()
        {
            // ReSharper disable once TailRecursiveCall
            RecursiveMethod();
        }

        public static void AccessViolation()
        {
            var ptr = new IntPtr(42);
            Marshal.StructureToPtr(42, ptr, true);
        }
    }
}