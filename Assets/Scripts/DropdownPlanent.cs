using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownPlanent : MonoBehaviour
{
    public Dropdown m_Dropdown;
    public Text text;
    public int selected;

    void Awake() {
        selected = 0;
    }

    void Start()
    {
        //Fetch the Dropdown GameObject
        m_Dropdown = GetComponent<Dropdown>();
        //Add listener for when the value of the Dropdown changes, to take action
        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(m_Dropdown);
        });

        //Initialise the Text to say the first value of the Dropdown
        //m_Text.text = "First Value : " + m_Dropdown.value;
    }

    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(Dropdown change)
    {
        Debug.Log(change.value);
        selected = change.value;
        if (selected == 0) {
            text.text = "행성을 선택하시면 값이 보입니다.";
            GameObject.Find("Player").transform.position = GameObject.Find("Sun").transform.position;
        }
    }   
}
