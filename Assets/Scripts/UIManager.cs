using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;
    public float currentTime;

    private void Update()
    {
        currentTime += Time.deltaTime;
        int minutes=Mathf.FloorToInt(currentTime/60);
        int seconds=Mathf.FloorToInt(currentTime%60);

        tmp.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
