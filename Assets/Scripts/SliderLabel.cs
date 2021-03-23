using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderLabel : MonoBehaviour
{
    public void refresh(float val) {
        this.GetComponent<Text>().text = val.ToString();
    }
}
