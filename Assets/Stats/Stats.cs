using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStats
{
    AGE,
    HEALTH,
    HUNGER,
    SLEEP,
    HAPPINESS,
}

public class Stats
{
    public static readonly float healthDuration = 2;

    private StatsField health;
    private StatsField hunger;
    private StatsField sleep;
    private StatsField happiness;
    private StatsField age;

    // private List<StatsField> statsFieldsList;
    public Stats(StatsField health, StatsField hunger, StatsField sleep, StatsField happiness, StatsField age)
    {
        this.health = health;
        this.hunger = hunger;
        this.sleep = sleep;
        this.happiness = happiness;
        this.Age = age;

    }

    public StatsField Health { get => health; set { if (value.value <= 0) health.value = 0; } }
    public StatsField Hunger { get => hunger; set { if (value.value <= 0) hunger.value = 0; } }
    public StatsField Sleep { get => sleep; set { if (value.value <= 0) sleep.value = 0; } }
    public StatsField Happiness { get => happiness; set { if (value.value <= 0) happiness.value = 0; } }
    public StatsField Age { get => age; set => age = value; }
}

public class StatsField
{
    public float value;
    public float buffTime;
    public float duration;
    public float tempDuration;
    public readonly string name;
    public bool isEmpty;
    public readonly float MAX_VALUE;

    public StatsField(float value, float duration, string name, bool isEmpty, float MAX_VALUE)
    {
        this.value = value;
        this.duration = duration;
        this.name = name;
        this.isEmpty = isEmpty;
        this.MAX_VALUE = MAX_VALUE;
        tempDuration = 0;
        buffTime = 0;
    }

    public StatsField(float value, float duration, string name, float MAX_VALUE)
    {
        this.value = value;
        this.duration = duration;
        this.name = name;
        this.isEmpty = value <= 0;
        this.MAX_VALUE = MAX_VALUE;
        tempDuration = 0;
        buffTime = 0;
    }
}