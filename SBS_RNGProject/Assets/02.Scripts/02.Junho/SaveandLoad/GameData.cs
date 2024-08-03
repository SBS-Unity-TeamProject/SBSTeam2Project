using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class GameData
{
    public int gold;

    public SerializableDictionary<string, int> inventory;
    public SerializableDictionary<string, float> volumSettings;

    public GameData()
    {
        this.gold = 0;

        inventory = new SerializableDictionary<string, int>();
    }
}