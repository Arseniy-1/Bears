using _Project.Scripts.Storage;

namespace _Project.Scripts.Inventory
{
    public readonly struct ItemTransactionInfo
    {
        public readonly string InventoryOwnerId;
        public readonly ItemType _type;
        public readonly int ItemsToChangeAmount;
        public readonly int ItemsChangedAmount;
        
        public int ItemsNotChangedAmount => ItemsToChangeAmount - ItemsChangedAmount;
        public bool Success => ItemsToChangeAmount == ItemsChangedAmount;

        public ItemTransactionInfo(
            string inventoryOwnerId,
            ItemType type,
            int itemsToChangeAmount,
            int itemsChangedAmount)
        {
            InventoryOwnerId = inventoryOwnerId;
            _type = type;
            ItemsToChangeAmount = itemsToChangeAmount;
            ItemsChangedAmount = itemsChangedAmount;
        }

        public override string ToString()
        {
            return $"OwnerId: {InventoryOwnerId}, itemId {_type.ToString()}, ToChange: {ItemsToChangeAmount}, Changed: {ItemsChangedAmount} Success {Success}";
        }
    }
}