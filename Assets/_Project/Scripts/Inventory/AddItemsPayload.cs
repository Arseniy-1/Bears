namespace _Project.Scripts.Inventory
{
    public readonly struct AddItemsPayload
    {
        public readonly string InventoryOwnerId;
        private readonly string _itemId;
        public readonly int ItemsToAddAmount;
        public readonly int ItemsAddedAmount;
        public int ItemsNotAddedAmount => ItemsToAddAmount - ItemsAddedAmount;

        public AddItemsPayload(
            string inventoryOwnerId,
            string itemId,
            int itemsToAddAmount,
            int itemsAddedAmount)
        {
            InventoryOwnerId = inventoryOwnerId;
            _itemId = itemId;
            ItemsToAddAmount = itemsToAddAmount;
            ItemsAddedAmount = itemsAddedAmount;
        }

        public override string ToString()
        {
            return $"OwnerId: {InventoryOwnerId}, itemId {_itemId}, ToAdd: {ItemsToAddAmount}, Added: {ItemsAddedAmount}";
        }
    }
}