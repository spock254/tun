using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class StatInit : MonoBehaviour
{
    public Stats stats;

    [SerializeField]
    private float initHungerDur = 1;
    [SerializeField]
    private float initSleepDur = 1;
    [SerializeField]
    private float initHappinessDur = 1;
    [SerializeField]
    private float initAgeDur = 1;
    void Awake()
    {
        stats = new Stats(new StatsField(100, float.MaxValue, "health", 150f),
            new StatsField(100, initHungerDur, "hunger", 150f),
            new StatsField(100, initSleepDur, "sleep", 150f),
            new StatsField(100, initHappinessDur, "happiness", 150f),
            new StatsField(16, initAgeDur, "age", 100));

        //SaveStats(@"stats.json", stats);
        //stats = LoadStats(@"stats.json");
    }

    void SaveStats(string path, Stats st) 
    {
        File.WriteAllText(path, JsonConvert.SerializeObject(st));
    }

    Stats LoadStats(string path) 
    {
        Stats st = JsonConvert.DeserializeObject<Stats>(File.ReadAllText(path));
        
        if (st == null) 
        { 
            Debug.LogWarning("DeserializeObject Stats == null"); 
        }

        return st;
    }
}
