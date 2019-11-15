using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialHealth : MonoBehaviour
{
    public Image imageHealthIcon;
    public float curHealth, maxHealth;
    void HealthChange()
    {
        float amount = Mathf.Clamp01(curHealth / maxHealth);
        imageHealthIcon.fillAmount = amount;
    }

    // Update is called once per frame
    void Update()
    {
        HealthChange();
    }
}
