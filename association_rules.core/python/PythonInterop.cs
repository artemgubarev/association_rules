using Python.Runtime;
using System;
using System.IO;

namespace association_rules.core
{
    public class PythonInterop
    {
        private const string PythonPath = @"..\..\..\..\association_rules.core\python\python38.dll";

        private void Init()
        {
            Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", PythonPath);
            PythonEngine.Initialize();
        }

        public object RunPythonCode
            (string filePath, string[] paramsNames, object[] paramsValues, string returningVariableName)
        {
            object result = new object();
            Init();
            int params_count = paramsNames.Length;

            using (Py.GIL())
            {
                using (var scope = Py.CreateScope())
                {
                    string pycode = File.ReadAllText(filePath);

                    for (int i = 0; i < params_count; i++)
                    {
                        scope.Set(paramsNames[i], paramsValues[i].ToPython());
                    }
                    scope.Exec(pycode);
                    result = scope.Get<PyObject>(returningVariableName);
                }
            }
            return result;
        }

    }
}
