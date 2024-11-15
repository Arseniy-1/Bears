namespace _Project.Scripts.Inventory
{
    public struct RemoveItemsPayload
    {
        public readonly string InventoryOwnerId;
        private readonly string _itemId;
        public readonly int ItemsToRemoveAmount;
        public readonly bool Succes;

        public RemoveItemsPayload(
            string inventoryOwnerId,
            string itemId,
            int itemsToRemoveAmount,
            bool succes)
        {
            InventoryOwnerId = inventoryOwnerId;
            _itemId = itemId;
            ItemsToRemoveAmount = itemsToRemoveAmount;
            Succes = succes;
        }
        
        public override string ToString()
        {
            return $"OwnerId: {InventoryOwnerId}, itemId {_itemId}, ToRemove: {ItemsToRemoveAmount}, Succes: {Succes}";
        }
    }
}