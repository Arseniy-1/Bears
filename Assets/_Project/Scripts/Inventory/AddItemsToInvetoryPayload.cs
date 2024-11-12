namespace _Project.Scripts.Inventory
{
    public readonly struct AddItemsToInvetoryPayload
    {
        public readonly string InventoryOwnerId;
        public readonly int ItemsToAddAmount;
        public readonly int ItemsAddedAmount;
        public int ItemsNotAddedAmount => ItemsToAddAmount - ItemsAddedAmount;

        public AddItemsToInvetoryPayload(
            string inventoryOwnerId,
            int itemsToAddAmount,
            int itemsAddedAmount)
        {
            InventoryOwnerId = inventoryOwnerId;
            ItemsToAddAmount = itemsToAddAmount;
            ItemsAddedAmount = itemsAddedAmount;
        }
    }
}