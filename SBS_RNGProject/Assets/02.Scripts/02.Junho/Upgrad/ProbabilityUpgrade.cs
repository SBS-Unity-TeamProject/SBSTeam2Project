using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;

public class ProbabilityUpgrade : MonoBehaviour, IPointerDownHandler, ISaveManager
{
    private float[] rareProbs = new float[200];
    private float[] epicProbs = new float[200];
    private float[] uniqueProbs = new float[200];
    private float[] legendProbs = new float[200];
    public int level = 1;

    private void Start()
    {
        LoadProbabilitiesFromCSV();
    }

    private void Update()
    {
        Debug.Log(level);

        if (Input.GetKeyDown(KeyCode.U))
        {
            level++;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UpdateProbabilities(level);
    }

    public void UpdateProbabilities(int level)
    {
        float rareProb = rareProbs[level - 1];
        float epicProb = epicProbs[level - 1];
        float uniqueProb = uniqueProbs[level - 1];
        float legendProb = legendProbs[level - 1];

        int result = Mathf.RoundToInt(Random.Range(0f, 100f));
        if (result < rareProb)
        {
            Debug.Log(rareProb);
            Debug.Log("Rare");
        }
        else if (result < rareProb + uniqueProb)
        {
            Debug.Log(epicProb);
            Debug.Log("Unique");
        }
        else if (result < rareProb + uniqueProb + epicProb)
        {
            Debug.Log(uniqueProb);
            Debug.Log("Epic");
        }
        else
        {
            Debug.Log(legendProb);
            Debug.Log("Legend");
        }
        Debug.Log(result);
    }

    private void LoadProbabilitiesFromCSV()
    {
        string path = Path.Combine(Application.dataPath, "05.Data/DataTable/UpgradeDataTable.csv");

        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                rareProbs[i - 1] = float.Parse(values[0]);
                epicProbs[i - 1] = float.Parse(values[1]);
                uniqueProbs[i - 1] = float.Parse(values[2]);
                legendProbs[i - 1] = float.Parse(values[3]);
            }
        }
        else
        {
            Debug.LogError("CSV file not found at path: " + path);
        }
    }

    public void LoadData(GameData _data)
    {
        return;
    }

    public void SaveData(ref GameData _data)
    {
        return;
    }
}
