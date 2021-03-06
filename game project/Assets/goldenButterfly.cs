﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class goldenButterfly : MonoBehaviour {
    public static Flowchart talkFlowchart;
    public static Flowchart flowchartManager;
    public string onMouseDown;
    public static Transform player;
    public static bool butterflyInSpecimen = false;

    void Awake()
    {
        flowchartManager = GameObject.FindGameObjectWithTag("flowchartController").GetComponent<Flowchart>();
        talkFlowchart = GameObject.FindGameObjectWithTag("talkFlowchart").GetComponent<Flowchart>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public static bool isTalking
    {
        get { return flowchartManager.GetBooleanVariable("talking"); }
    }

    public static bool isChoosing
    {
        get { return flowchartManager.GetBooleanVariable("choosing"); }
    }

    public static bool butterMachineOpen
    {
        get { return talkFlowchart.GetBooleanVariable("butterMachineOpen"); }
    }
    public static bool butterflySpecimen
    {
        get { return talkFlowchart.GetBooleanVariable("butterflySpecimen"); }
    }
    public static bool purpleBasin
    {
        get { return talkFlowchart.GetBooleanVariable("purpleBasin"); }
    }

    private void OnMouseDown()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist <= 30 && !isTalking)
        {
            if (!butterMachineOpen)
            {
                talkFlowchart.ExecuteBlock(talkFlowchart.FindBlock("noReaction"));
            }
            else
            {
                if (!butterflySpecimen)
                {
                    Block targetBlock = talkFlowchart.FindBlock(onMouseDown);
                    talkFlowchart.ExecuteBlock(targetBlock);
                }
                else{
                    if (!purpleBasin)
                    {
                        Block targetBlock = talkFlowchart.FindBlock("goldenButterfly2");
                        talkFlowchart.ExecuteBlock(targetBlock);
                    }
                    else{
                        talkFlowchart.ExecuteBlock("makeButterSpecimen");
                        butterflyInSpecimen = true;
                    }
                }
            }
        }
    }
}
