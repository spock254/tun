using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lifecell : MonoBehaviour
{
    public Stats stats;
    public StatInit statInit;
    public ExpInit exp;
    public FightStatsInit fightStatsInit;

    UnityEvent lvlUp;
    UnityEvent dead;

    private float hungerDamage = 0.5f;
    private float sleepDamage = 0.5f;
    private float happinessDamage = 0.5f;

    private float baseHealthDuration = 0;
    private bool isGettingDamage = false;
    private void Start()
    {
        stats = statInit.stats;
        baseHealthDuration = stats.Health.duration;

        if (lvlUp == null) 
        {
            lvlUp = new UnityEvent();
        }

        if (dead == null)
        {
            dead = new UnityEvent();
        }

        lvlUp.AddListener(FightStatsModify);

        dead.AddListener(Dead);
    }

    void Update()
    {
        timeModify(stats.Age);
        timeModify(stats.Health);
        timeModify(stats.Hunger);
        timeModify(stats.Sleep);
        timeModify(stats.Happiness);

        // !!! BEFORE LvlCalculation !!!
        if (exp.exp.isLvlUp()) 
        {
            lvlUp.Invoke();
        }

        LvlCalculation();

        if ((stats.Hunger.isEmpty || stats.Sleep.isEmpty || stats.Happiness.isEmpty) && !isGettingDamage)
        {
            stats.Health.duration = Stats.healthDuration;
            isGettingDamage = true;
        }
        else if (!stats.Hunger.isEmpty && !stats.Sleep.isEmpty && !stats.Happiness.isEmpty)
        {
            stats.Health.duration = float.MaxValue;
            isGettingDamage = false;
        }

        StatModify.HealthControll(stats.Health, stats.Hunger, hungerDamage);
        StatModify.HealthControll(stats.Health, stats.Sleep, sleepDamage);
        StatModify.HealthControll(stats.Health, stats.Happiness, happinessDamage);


        if (!isAlife(statInit)) 
        {
            dead.Invoke();
        }

        //Test
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StatModify.AddValue(stats.Hunger, 30);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            StatModify.AddValue(stats.Sleep, 30);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StatModify.AddValue(stats.Happiness, 30);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            exp.exp.Current_exp += 100;
        }

    }

    public void timeModify(StatsField statsField)
    {
       // float oldDuration = statsField.duration;
        if (statsField.value < 0) 
        {
            statsField.value = 0;
        }

        if (statsField.buffTime > 0)
        {
            statsField.value -= Time.deltaTime / statsField.tempDuration;
            statsField.buffTime -= Time.deltaTime;
            return;
        }

        statsField.value -= Time.deltaTime / statsField.duration;
    }

    private void FightStatsModify() 
    {
        Debug.Log("lvl up");
    }

    public void LvlCalculation() 
    {
        if (exp.exp.Current_exp >= exp.exp.NextExpAmount())
        {
            exp.exp.Lvl++;
        }
    }

    private bool isAlife(StatInit stat) 
    {
        return stat.stats.Age.value < stat.stats.Age.MAX_VALUE
            && stat.stats.Health.value > 0;
    }

    private void Dead() 
    {
        Debug.Log("player dead");
    }
}
