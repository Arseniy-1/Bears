namespace _Project.Scripts.Inventory
{
    public readonly struct ItemTransactionInfo
    {
        public readonly string InventoryOwnerId;
        private readonly string _itemId;
        public readonly int ItemsToChangeAmount;
        public readonly int ItemsChangedAmount;
        public int ItemsNotChangedAmount => ItemsToChangeAmount - ItemsChangedAmount;
        public bool Success => ItemsToChangeAmount == ItemsChangedAmount;

        public ItemTransactionInfo(
            string inventoryOwnerId,
            string itemId,
            int itemsToChangeAmount,
            int itemsChangedAmount)
        {
            InventoryOwnerId = inventoryOwnerId;
            _itemId = itemId;
            ItemsToChangeAmount = itemsToChangeAmount;
            ItemsChangedAmount = itemsChangedAmount;
        }

        public override string ToString()
        {
            return $"OwnerId: {InventoryOwnerId}, itemId {_itemId}, ToChange: {ItemsToChangeAmount}, Changed: {ItemsChangedAmount} Succes {Success}";
        }
    }
}