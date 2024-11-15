using System.Collections.Generic;
using _Project.Scripts.Inventory;
using _Project.Scripts.Inventory.Data;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class GameStatePlayerPrefsProvider : IGameStateProvider, IGameStateSaver
    {
        private const string GameStateKey = "GAME STATE";

        public GameStateData GameState { get; private set; }

        public void SaveGameState()
        {
            var json = JsonUtility.ToJson(GameState);
            PlayerPrefs.SetString(GameStateKey, json);
        }

        public void LoadGameState()
        {
            if (PlayerPrefs.HasKey(GameStateKey))
            {
                string json = PlayerPrefs.GetString(GameStateKey);
                GameState = JsonUtility.FromJson<GameStateData>(json);
            }
            else
            {
                GameState = InitFromSettings();
                SaveGameState();
            }
        }

        private GameStateData InitFromSettings()
        {
            var gameState = new GameStateData
            {
                Inventories = new List<InventoryGridData>
                {
                    CreateTestInventory("Player"),
                    CreateTestInventory("chest_1")
                }
            };

            return gameState;
        }

        private InventoryGridData CreateTestInventory(string ownerId)
        {
            var size = new Vector2Int(3, 4); // load from configs
            var cellsData = new List<InventoryCellData>();
            var length = size.x * size.y;

            for (int i = 0; i < length; i++)
                cellsData.Add(new InventoryCellData());

            var inventoryData = new InventoryGridData
            {
                OwnerId = ownerId,
                Size = size,
                Cells = cellsData
            };
            
            return inventoryData;
        }
    }
}