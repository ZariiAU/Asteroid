using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class WeaponSelectUI : MonoBehaviour
{
    public TMP_Text weaponText;
    public WeaponSelect weaponSelect;
    [SerializeField] private float textFadeInSpeed;
    [SerializeField] private float textFadeOutSpeed;
    [SerializeField] private float textFadeDelay;
    private float alpha = 0;
    private bool fadeOut = false;
    private bool fadeIn = false;

    // Start is called before the first frame update
    void Start()
    {
        weaponText.alpha = 0;
        weaponSelect.OnWeaponSwitch.AddListener(() => {
            weaponText.SetText("Weapon: " + weaponSelect.selectedWeapon.weaponType.weaponName);
            StartCoroutine(FadeInOut(weaponText));
        });
    }

    private void Update()
    {
        FadeUI(weaponText, textFadeInSpeed, textFadeOutSpeed, fadeIn, fadeOut);
        alpha = weaponText.alpha;
    }

    /// <summary>
    /// Sets fade in and fade out bools for <see cref="FadeUI(Graphic, float, float, bool, bool)"/>
    /// </summary>
    /// <param name="uiElement"></param>
    /// <returns></returns>
    IEnumerator FadeInOut(Graphic uiElement)
    {
        fadeIn = true;
        fadeOut = false;
        while (uiElement.color.a < 1)
        {
            yield return null;
        }
        if(uiElement.color.a >= 0.9f)
        {
            fadeIn = false;
            yield return new WaitForSeconds(textFadeDelay);
            fadeOut = true;
        }
    }

    /// <summary>
    /// Must be used in conjunction with Coroutine <see cref="FadeInOut(Graphic)"/>
    /// </summary>
    /// <param name="uiElement"></param>
    /// <param name="fadeInSpeed"></param>
    /// <param name="fadeOutSpeed"></param>
    void FadeUI(Graphic uiElement, float fadeInSpeed, float fadeOutSpeed, bool fadeIn, bool fadeOut)
    {
        if (fadeIn)
        {
            fadeOut = false;
            if(uiElement.color.a < 1)
            {
                fadeOut = false; // Prevents early, unintended fade out
                uiElement.color = new Color(uiElement.color.r, uiElement.color.g, uiElement.color.b, uiElement.color.a + Time.deltaTime * fadeInSpeed);
                if(uiElement.color.a >= 1)
                {
                    fadeIn = false;
                }
            }
        }
        if (fadeOut)
        {
            if (uiElement.color.a >= 0)
            {
                uiElement.color = new Color(uiElement.color.r, uiElement.color.g, uiElement.color.b, uiElement.color.a - Time.deltaTime * fadeOutSpeed);
                if (uiElement.color.a <= 0.1f) // non-zero value to ensure timely switching of flag
                {
                    fadeOut = false;
                }
            }
        }
    }
}
