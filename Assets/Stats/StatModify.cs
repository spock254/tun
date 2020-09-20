using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StatModify
{
    public static void AddValue(StatsField statsField, float value) 
    {
        statsField.value += value;

        if (statsField.value > statsField.MAX_VALUE) 
        {
            statsField.value = statsField.MAX_VALUE;
        }
    }

    public static void ChangeDuration(StatsField statsField, float value, float time) 
    {
        statsField.tempDuration = value;
        statsField.buffTime = time;
    }

    public static void HealthControll(StatsField health, StatsField atribute, float damage) 
    {
        if (atribute.value <= 0 && !atribute.isEmpty)
        {
            health.duration -= damage;
            atribute.isEmpty = true;
        }
        else if (atribute.isEmpty && atribute.value > 0)
        {
            health.duration += damage; //TODO: 
            atribute.isEmpty = false;
        }

        health.isEmpty = health.value <= 0;
    }
}
