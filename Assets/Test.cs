using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //private Stats stats;
    //// gui
    //int barlength = 150;

    //public Texture2D progressBarEmpty;
    //public Texture2D progressBarFull;
    void Start()
    {
        //stats = new Stats(new StatsField(100,0.1f, "health"),
        //    new StatsField(100, 0.05f, "hunger"),
        //    new StatsField(100, 0.05f, "sleep"),
        //    new StatsField(100, 0.05f, "happiness"));

    }

    //private void OnGUI()
    //{
    //    DrawStatBar(stats.Health, 0);
    //    DrawStatBar(stats.Hunger, 1);

    //}

    // Update is called once per frame
    //void Update()
    //{
    //    timeModify(stats.Health);
    //    timeModify(stats.Hunger);

        
    //}

    //public void timeModify(StatsField statsField) 
    //{
    //    statsField.value -= Time.deltaTime / statsField.duration;
    //}

    //public void timeModifyAll(Stats stats) 
    //{ 
        
    //}

    // void DrawStatBar(StatsField statsField, int order) 
    //{
    //    int step = 32;

    //    GUI.BeginGroup(new Rect(0, step * order, barlength, 32));
    //    GUI.Box(new Rect(0, 0, barlength, 32), progressBarEmpty);
    //    GUI.BeginGroup(new Rect(0, 0, statsField.value / 100 * barlength, 32));
    //    GUI.Box(new Rect(0, 0, barlength, 32), progressBarFull);
    //    GUI.EndGroup();
    //    GUI.EndGroup();
    //    GUI.Label(new Rect(0, step * order, barlength, 32), statsField.name + " " + ((int)statsField.value).ToString());

    //}
}
