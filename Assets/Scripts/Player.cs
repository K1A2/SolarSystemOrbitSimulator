using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Player : MonoBehaviour {
 
    public float Speed;         // 움직이는 스피드.
 
    private Transform Vec;      // 카메라 벡터.
    private Vector3 MovePos;    // 플레이어 움직임에 대한 변수.
    private Transform Target;   // 플레이어의 트랜스 폼.
    private Vector3 Pos;        // 자신의 위치.
    public DropdownPlanent dropdown;
 
    void Init()
    {
        MovePos = Vector3.zero;
    }
 
    void Start()
    {
        Vec = GameObject.Find("CameraVector").transform;
        Init();
    }
 
    void Update () 
    {
        dropdown = GameObject.Find("PlanetSelector").GetComponent<DropdownPlanent>();
        // switch (dropdown.selected) {
        //     case 0: {
        //         Target = GameObject.Find("Sun").transform;
        //         Debug.Log("S");
        //         break;
        //     }
        //     case 1: {
        //         Target = GameObject.Find("Mercury").transform;
        //         Debug.Log("M");
        //         break;
        //     }
        //     case 2: {
        //         Target = GameObject.Find("Venus").transform;
        //         Debug.Log("V");
        //         break;
        //     }
        //     case 3: {
        //         Target = GameObject.Find("Earth").transform;
        //         Debug.Log("E");
        //         break;
        //     }
        //     case 4: {
        //         Target = GameObject.Find("Mars").transform;
        //         Debug.Log("M");
        //         break;
        //     }
        //     case 5: {
        //         Target = GameObject.Find("Jupiter").transform;
        //         Debug.Log("J");
        //         break;
        //     }
        //     case 6: {
        //         Target = GameObject.Find("Saturn").transform;
        //         Debug.Log("Sa");
        //         break;
        //     }
        //     case 7: {
        //         Target = GameObject.Find("Uranus").transform;
        //         Debug.Log("U");
        //         break;
        //     }
        //     case 8: {
        //         Target = GameObject.Find("Neptune").transform;
        //         Debug.Log("N");
        //         break;
        //     }
        //     case 9: {
        //         Target = GameObject.Find("Pluto").transform;
        //         Debug.Log("P");
        //         break;
        //     }
        // }
        // this.transform.position = Target.transform.position;
    }
 
    // 플레이어 움직임.
    void Run()
    {
        int ButtonDown = 0;
        if (Input.GetKey(KeyCode.LeftArrow))    ButtonDown = 1;
        if (Input.GetKey(KeyCode.RightArrow))   ButtonDown = 1;
        if (Input.GetKey(KeyCode.UpArrow))      ButtonDown = 1;
        if (Input.GetKey(KeyCode.DownArrow))    ButtonDown = 1;
 
        // 플레이어가 움직임. 버튼에서 손을 땠을 때 Horizontal, Vertical이 0으로 돌아감으로써
        // 플레이어의 회전상태가 다시 원상태로 돌아가지 않게 하기 위해서.
        if (ButtonDown != 0) {}
            //Rotation();
        else {return;}
            
 
        transform.Translate(Vector3.forward * Time.deltaTime * Speed * ButtonDown);
    }
}
