namespace _Project.Scripts.Inventory
{
    public struct RemoveItemsFromInvetoryPayload
    {
        public readonly string InventoryOwnerId;
        public readonly int ItemsToRemoveAmount;
        public readonly bool Succes;

        public RemoveItemsFromInvetoryPayload(
            string inventoryOwnerId,
            int itemsToRemoveAmount,
            bool succes)
        {
            InventoryOwnerId = inventoryOwnerId;
            ItemsToRemoveAmount = itemsToRemoveAmount;
            Succes = succes;
        }
    }
}