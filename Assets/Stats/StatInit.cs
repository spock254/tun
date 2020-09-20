using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
