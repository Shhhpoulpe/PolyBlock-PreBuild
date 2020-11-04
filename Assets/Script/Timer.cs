using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float temps = 0;
    public Text timertext;
    public int tempsInt, tempsIntS, tempsIntM;
    public string tempsStr, tempsStrS, tempsStrM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tempsIntS < 10)
        {
            tempsStrS = "0" + tempsIntS;
        }
        else
        {
            tempsStrS = tempsIntS.ToString();
        }

        if (tempsIntM < 10)
        {
            tempsStrM = "0" + tempsIntM;
        }
        else
        {
            tempsStrM = tempsIntM.ToString();
        }

        timertext.text = (tempsStrM + ":" + tempsStrS);
        temps += Time.deltaTime;
        tempsInt = Mathf.RoundToInt(temps);
        tempsIntM = tempsInt / 60;
        tempsIntS = tempsInt % 60;
        
    }
}
