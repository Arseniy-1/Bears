using System;

namespace _Project.Scripts.Spawner
{
    public interface IDestoyable<T>
    {
        public event Action<T> Destroed;
    }
}