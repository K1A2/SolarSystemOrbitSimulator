using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraMan : MonoBehaviour {
 
    // 공개
    public float MoveSpeed;     // 플레이어를 따라오는 카메라 맨의 스피드.
    public DropdownPlanent dropdown;
 
    // 비공개
    private Transform Target;   // 플레이어의 트랜스 폼.
    private Vector3 Pos;        // 자신의 위치.
 
    void Start()
    {
        // Player라는 태그를 가진 오브젝트의 transform을 가져온다.
        Target = GameObject.Find("Player").transform;
    }
 
    // 플레이어를 따라다님.
    void Update () 
    {
        // dropdown = GameObject.Find("PlanetSelector").GetComponent<DropdownPlanent>();
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
        // Pos = transform.position;
        // transform.position += (Target.position - Pos) * MoveSpeed;
        // Pos = transform.position;
        this.transform.position = Target.transform.position;
        //transform.position += (Target.position - Pos) * MoveSpeed;
    }
}
