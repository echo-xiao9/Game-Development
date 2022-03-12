using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider lifeSlider;
  

    void Start(){
      lifeSlider.minValue = 0;
      lifeSlider.maxValue = 100;
      lifeSlider.wholeNumbers = true;
      lifeSlider.value = 50;
    }

    public void OnvalueChanged(float value){
      print("life changed to: "+value);
    }

}
