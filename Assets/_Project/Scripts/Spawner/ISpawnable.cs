using System;

namespace _Project.Scripts.Spawner
{
    public interface ISpawnable<T>
    {
        public event Action<T> Destroying;
    }
}