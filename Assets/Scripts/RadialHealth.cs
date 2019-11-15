using UnityEngine.UI;
using UnityEngine;

public class RadialHealth : MonoBehaviour
{
    public Image radialHealthIcon;
    public float curHealth, maxHealth;
    void HealthChange()
    {
        float amount = Mathf.Clamp01(curHealth/maxHealth);
        radialHealthIcon.fillAmount = amount;
    }

    // Update is called once per frame
    void Update()
    {
        HealthChange();
    }
}
