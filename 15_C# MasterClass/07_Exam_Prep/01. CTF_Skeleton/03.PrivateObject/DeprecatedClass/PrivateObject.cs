namespace DeprecatedClass
{
    using System;
    using System.Reflection;

    public class PrivateObject
    {
        private readonly Type obj; 
        public PrivateObject(object obj)
        {
            this.obj = obj.GetType();
        }

        public object Invoke(string methodName, params object[] parameters)
        {
            var instance = Activator.CreateInstance(this.obj);

            MethodInfo method = this.obj.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

            return method.Invoke(instance, parameters);
        }
    }
}
