using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class GameData
{
    public int gold;
    public SerializableDictionary<string, int> inventoryItem;

    public GameData()
    {
        this.gold = 0;

        inventoryItem = new SerializableDictionary<string, int>();
    }
}