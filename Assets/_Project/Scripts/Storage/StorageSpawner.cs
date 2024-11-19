namespace _Project.Scripts.Storage
{
    public class StorageSpawner
    {
        private readonly StorageFactory _storageFactory;

        public StorageSpawner(StorageFactory storageFactory)
        {
            _storageFactory = storageFactory;
        }
        
        public void Spawn(StorageSpawnPoint storageSpawnPoint)
        {
            Storage storage = _storageFactory.Create();
            storage.transform.position = storageSpawnPoint.transform.position;
        }
    }
}