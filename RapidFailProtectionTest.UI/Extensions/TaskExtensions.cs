using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RapidFailProtectionTest.UI.Extensions
{
    public static class TaskExtensions
    {
        public static async void Forget(this Task task, bool handleExceptions, params Type[] acceptableExceptions)
        {
            try
            {
                await task.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // TODO: consider whether derived types are also acceptable.
                if (!acceptableExceptions.Contains(ex.GetType()))
                    throw;
            }
        }

        public static void Forget(this Task task)
        {

        }

    }
}