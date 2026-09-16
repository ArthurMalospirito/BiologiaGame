
using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    public int minutes;
    public int seconds;
    private float elapsedTime;

    private void Start()
    {
        Instance=this;
        elapsedTime=0;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        seconds = Mathf.FloorToInt(elapsedTime % 60);
        minutes = Mathf.FloorToInt(elapsedTime/60);
    }
}