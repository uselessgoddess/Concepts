using System;
using System.Collections.Generic;
using System.Linq;

namespace Concepts
{
    public class Requires
    {
        // this will get rid of inheritance(interfaces)
        // stupid C++ style
        /// <summary>
        /// Oh, excuse me. I will be use XML comments
        /// </summary>
        enum Initialization 
        {
            BoolExpression,
            CheckMethod,
        }

        private readonly Initialization initializationWay;
        private readonly bool value;
        private readonly string methodName;
        private readonly Type[] arguments;
        
        public Requires(bool expression)
        {
            value = expression;
            initializationWay = Initialization.BoolExpression;
        }
        
        public Requires(string methodName, params Type[] arguments)
        {
            this.methodName = methodName;
            this.arguments = arguments;

            initializationWay = Initialization.CheckMethod;
        }

        private static bool MethodCheck<T>(string methodName, Type[] arguments)
        {
            try
            {
                return typeof(T).GetMethod(methodName, arguments) != null;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Is<T>()
        {
            // Ha-ha-ha c-plus-plusers do not know how
            return initializationWay switch
            {
                Initialization.BoolExpression => value,
                Initialization.CheckMethod => MethodCheck<T>(methodName, arguments),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}