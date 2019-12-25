using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownSelector : MonoBehaviour
{
    public Dropdown m_Dropdown;
    public double speed;

    void Awake() {
        speed = 1;
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
        switch(change.value) {
            case 0: {
                speed = 1;
                break;
            }
            case 1: {
                speed = 12 * 60 * 60;
                break;
            }
            case 2: {
                speed = 24 * 10 * 60 * 60;
                break;
            }
            case 3: {
                speed = 24 * 94 * 60 * 60;
                break;
            }
            case 4: {
                speed = 24 * 184 * 60 * 60;
                break;
            }
            case 5: {
                speed = 24 * 7305 * 60 * 60;
                break;
            }
        }
    }   
}
