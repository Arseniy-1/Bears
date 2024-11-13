namespace _Project.Scripts.Inventory
{
    public readonly struct AddItemsPayload
    {
        public readonly string InventoryOwnerId;
        public readonly int ItemsToAddAmount;
        public readonly int ItemsAddedAmount;
        public int ItemsNotAddedAmount => ItemsToAddAmount - ItemsAddedAmount;

        public AddItemsPayload(
            string inventoryOwnerId,
            int itemsToAddAmount,
            int itemsAddedAmount)
        {
            InventoryOwnerId = inventoryOwnerId;
            ItemsToAddAmount = itemsToAddAmount;
            ItemsAddedAmount = itemsAddedAmount;
        }

        public override string ToString()
        {
            return $"OwnerId: {InventoryOwnerId}, ToAdd: {ItemsToAddAmount}, Added: {ItemsAddedAmount}";
        }
    }
}