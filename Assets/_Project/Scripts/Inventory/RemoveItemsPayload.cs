namespace _Project.Scripts.Inventory
{
    public struct RemoveItemsPayload
    {
        public readonly string InventoryOwnerId;
        public readonly int ItemsToRemoveAmount;
        public readonly bool Succes;

        public RemoveItemsPayload(
            string inventoryOwnerId,
            int itemsToRemoveAmount,
            bool succes)
        {
            InventoryOwnerId = inventoryOwnerId;
            ItemsToRemoveAmount = itemsToRemoveAmount;
            Succes = succes;
        }
        
        public override string ToString()
        {
            return $"OwnerId: {InventoryOwnerId}, ToRemove: {ItemsToRemoveAmount}, Succes: {Succes}";
        }
    }
}