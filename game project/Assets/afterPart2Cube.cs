﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class afterPart2Cube : MonoBehaviour {

    public static Flowchart talkFlowchart;
    public static Flowchart flowchartManager;
    public GameObject cube;

    void Awake()
    {
        flowchartManager = GameObject.FindGameObjectWithTag("flowchartController").GetComponent<Flowchart>();
        talkFlowchart = GameObject.FindGameObjectWithTag("talkFlowchart").GetComponent<Flowchart>();
        cube.SetActive(false);
    }

    public static bool isTalking
    {
        get { return flowchartManager.GetBooleanVariable("talking"); }
    }

    public static bool isChoosing
    {
        get { return flowchartManager.GetBooleanVariable("choosing"); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            talkFlowchart.ExecuteBlock("wentToBoyA");
        }
        Destroy(GameObject.Find("afterPart2Cube"));
    }
}