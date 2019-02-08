using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UFOkillScore : MonoBehaviour
{
    public TextMeshProUGUI UFOscore;
    public static bool UFOisKilled = false;
    public static int points;
    public static Vector3 UFOPosition;
    void Update()
    {
        if (UFOisKilled)
        {
            UFOscore.transform.position = UFOPosition;
            UFOscore.text = points.ToString();
            UFOisKilled = false;
            Invoke("hide", 1f);
        }
    }
    void hide()
    {
        UFOscore.text = "";
    }
}
