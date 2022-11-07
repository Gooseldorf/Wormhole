using System;
using Interfaces;


namespace Managers
{
    public class ExecutableManager
    {
        public IExecute[] Executables => _executableObjects;
        private IExecute[] _executableObjects;
        public int Length => _executableObjects.Length;
    
        public IExecute this[int curr]
        {
            get => _executableObjects[curr];
            private set => _executableObjects[curr] = value;
        }

        public void AddExecutableObject(IExecute execute)
        {
            if (_executableObjects == null)
            {
                _executableObjects = new [] { execute };
                return;
            }
            Array.Resize(ref _executableObjects,Length+1);
            _executableObjects[Length - 1] = execute;
        }
    }

}