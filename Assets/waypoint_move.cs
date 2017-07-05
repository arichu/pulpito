﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint_move : MonoBehaviour {
    //Variables
    public GameObject[] waypoints;
    public int num = 0;
    public float minDist;
    public float speed;
    public bool rand = false;
    public bool go = true;
    
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(gameObject.transform.position, waypoints[num].transform.position);
        if (go)
        {
            if (dist > minDist)
            {
                move();
            }
            else
            {
                if (!rand)
                {
                    if(num + 1 == waypoints.Length)
                    {
                        num = 0;
                    }
                    else
                    {
                        num++;
                    }
                }
                else
                {
                    num = Random.Range(0, waypoints.Length);
                }
            }
        }
	}
    void move() {
        gameObject.transform.LookAt(waypoints[num].transform.position);
        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
    }
}
