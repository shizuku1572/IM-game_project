﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gettingTubeGreen : MonoBehaviour {
    public static Transform player;
    public static GameObject pivot;
    public static GameObject goal;
    public GameObject testTube;
    public GameObject item;
    public static bool tubeGreen = false;
    Vector3 prePos;
    //Rigidbody body;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        pivot = GameObject.Find("pivot");
        goal = GameObject.Find("goal");
        //body = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (tubeGreen)
        {
            item.transform.SetParent(pivot.transform, true);
        }
        if (Input.GetMouseButton(1) && tubeGreen)
        {
            tubeGreen = false;
            item.transform.SetParent(testTube.transform, true);
            item.GetComponent<Rigidbody>().useGravity = true;
        }
    }
    private void OnMouseDown()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if (tubeGreen == false && dist <= 30)
        {
            item.transform.position = goal.transform.position;
            item.GetComponent<Rigidbody>().useGravity = false;
            tubeGreen = true;
            //item.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
