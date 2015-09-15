using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Http
{

    /// <summary>
    /// Make an attribute to determine the Action is whether to use MultiParameter
    /// </summary>
    [AttributeUsage(AttributeTargets.Method,AllowMultiple= false,Inherited=false)]
    public sealed class MultiParameterSupportAttribute : Attribute
    {

    }
}
