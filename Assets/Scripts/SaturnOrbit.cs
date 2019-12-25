﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class SaturnOrbit : MonoBehaviour
{
    public OrbitData[] data = new OrbitData[]{
        new OrbitData(9.53667594d,0.05386179d,  2.48599187d, 113.66242448d, 49.95424423d, 92.59887831d, 0d, 0d, 0d, 0d, 0d),
        new OrbitData(-0.00125060d,  -0.00050991d, 0.00193609d, -0.28867794d, 1222.49362201d, -0.41897216d, 0d, 0d, 0d, 0d, 0d),
        new OrbitData(0,0,0,0,0,0,0,0,0,0,0)
    };
    //a 장반경, e이심률, i기울기, o승교점 적경, l평균 경도, lp근일점 경도[J200, 1Century]

    public GameObject orbit;
    public OrbitCalculator orbitCalculator = null;
    private DropdownSelector dropdown;
    public LineRenderer lineRenderer;
    public int count = 0;
    public int max = 99999;
    public DropdownPlanent dropdown2;
    public Vector3[] positions;
    public Vector3[] positions2;
    public Text sum;
    
    // Start is called before the first frame update
    void Awake() {
        //StartCoroutine(TimeUpdate());
    }

    void Start()
    {
        count = 0;
        max = 200;
        positions = new Vector3[max + 1];
        positions2 = new Vector3[max + 1];
        orbitCalculator = new OrbitCalculator(data,  DateTime.Now);
        orbit.transform.rotation = Quaternion.Euler(0,0, (float)data[0].i);
        dropdown = GameObject.Find("TimeSelector").GetComponent<DropdownSelector>();
        lineRenderer = this.GetComponent<LineRenderer>();
        lineRenderer.SetColors(new Color(103f/255f, 161f/255f, 219f/255f), new Color(56f/255f, 83f/255f, 235f/255f));
        lineRenderer.SetWidth(0.1f, 0.4f);
        lineRenderer.SetVertexCount(max);
        dropdown2 = GameObject.Find("PlanetSelector").GetComponent<DropdownPlanent>();
        //lineRenderer.useWorldSpace = false;
    }

    OrbitData[] datas;

    // Update is called once per frame
    void Update() {
        double time = Time.deltaTime * 1000  * dropdown.speed;
        datas = orbitCalculator.calculate((double)time);

        double x2, y2;
        x2 = 0 + datas[2].r*10*Math.Cos(datas[2].v);
        y2 = 0 + datas[2].r*10*Math.Sin(datas[2].v);
        this.transform.localPosition = new Vector3((float)x2, 0, (float)y2);
        GameObject.Find("S").transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
        if (dropdown2.selected == 6) {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("태양으로부터 거리(AU): " + datas[2].r + "AU\n");
            stringBuilder.Append("태양으로부터 거리(KM): " + (datas[2].r * 149597870) + "KM\n");
            stringBuilder.Append("근일점으로부터의 각도: " + (datas[2].v * 180 / Math.PI) + "도\n");
            stringBuilder.Append("장반경: " + datas[2].a + "\n");
            stringBuilder.Append("이심률: " + datas[2].e + "\n");
            stringBuilder.Append("기울기: " + datas[2].i + "도\n");
            stringBuilder.Append("근일점 편각: " + datas[2].w + "도\n");
            stringBuilder.Append("평균 근점이각: " + datas[2].M + "도\n");
            sum.text = stringBuilder.ToString();
             GameObject.Find("Player").transform.position = this.transform.position;
        }

        if (count >= max) {
            //lineRenderer.SetVertexCount(max);
            // for (int i = 0;i < max - 2;i++) {
            //     if (i == 0) {
            //         lineRenderer.SetPosition(i, this.transform.position);
            //         positions2[i] = this.transform.position;
            //         continue;
            //     }
            //     positions2[i] = positions[i + 1];
            //     lineRenderer.SetPosition(i, positions2[i]);
            // }
        } else {
            // positions[count] = this.transform.position;
            // lineRenderer.SetPosition(count, this.transform.position);
            // count++;
        }
        
        
        //this.transform.localPosition = v3Dest;
    }
}
