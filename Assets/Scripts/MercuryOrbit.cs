using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Text;

public class MercuryOrbit : MonoBehaviour
{
    public OrbitData[] data = new OrbitData[]{
        new OrbitData(0.38709927d, 0.20563593d, 7.00497902d, 48.33076593d, 252.25032350d, 77.45779628d,  0d, 0d, 0d,0,0),
        new OrbitData(0.00000037d,  0.00001906d, -0.00594749d, -0.12534081d, 149472.67411175d, 0.16047689d,  0d, 0d, 0d,0,0),
        new OrbitData(0,0,0,0,0,0,0,0,0,0,0)
    };
    //a 장반경, e이심률, i기울기, o승교점 적경, l평균 경도, lp근일점 경도[J200, 1Century]

    public GameObject orbit;
    public OrbitCalculator orbitCalculator = null;
    public DropdownPlanent dropdown2;
    public DateTime nowTime;
    public Text t;
    private DropdownSelector dropdown;
    public Text sum;
    
    // Start is called before the first frame update
    void Awake() {
        //StartCoroutine(TimeUpdate());
    }

    void Start()
    {
        nowTime = DateTime.Now;
        orbitCalculator = new OrbitCalculator(data,  nowTime);
        orbit.transform.rotation = Quaternion.Euler(0,0, (float)data[0].i);
        dropdown = GameObject.Find("TimeSelector").GetComponent<DropdownSelector>();
        dropdown2 = GameObject.Find("PlanetSelector").GetComponent<DropdownPlanent>();
    }

    // private IEnumerator TimeUpdate() {
    //     // while (true) {
    //     //     if(orbitCalculator != null) {
    //     //         double ta = 10000000d;
    //     //         double[] results = orbitCalculator.calculate(ta);

    //     //         nowTime += TimeSpan.FromMilliseconds(ta);
    //     //         t.text = nowTime.ToString("yyyy/MM/dd hh:mm:ss");

    //     //         double x2, y2;
    //     //         x2 = results[0]*100*Math.Cos(results[1]);
    //     //         y2 = results[0]*100*Math.Sin(results[1]);
    //     //         mercury.transform.localPosition = new Vector3((float)x2, 0, (float)y2);
    //     //     }
    //     //     //float t = 1f / 31536000000‬f;
    //     //     yield return new WaitForSeconds(0.00000001f);
    //     // }
    // }

    OrbitData[] datas;

    // Update is called once per frame
    void Update() {
        double time = Time.deltaTime * 1000 * dropdown.speed;
        datas = orbitCalculator.calculate((double)time);

        nowTime = nowTime.AddMilliseconds(time);
        t.text = nowTime.ToString("yyyy/MM/dd hh:mm:ss");

        Vector3 v3Original = new Vector3(0f, 0f, 0f); // 임의의 점
        Vector3 v3Distance = new Vector3(0f, 0f, (float)datas[2].r); // 거리 10
        Quaternion qRotation = Quaternion.Euler((float)datas[2].v, 0f, 0f); // 각도 45도.
        Vector3 v3Temp = qRotation * v3Distance;  // 거리 10짜리를 45도 회전
        Vector3 v3Dest = v3Original + v3Temp; // 임의의 점에서 거리 10 각도 45도 회전한 위치로 이동한 값.

        double x2, y2;
        x2 = 0 + datas[2].r*10*Math.Cos(datas[2].v);
        y2 = 0 + datas[2].r*10*Math.Sin(datas[2].v);
        this.transform.localPosition = new Vector3((float)x2, 0, (float)y2);
        GameObject.Find("M").transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
        if (dropdown2.selected == 1) {
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
        
        //this.transform.localPosition = v3Dest;
    }
}
