using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    public enum UI {
        Hud,
        PauseMenu,
        GameOverMenu,
        MainMenu,
        OptionsMenu,
        CreditsMenu
    }

    private enum HUD {
        Health,
        Score,
        Time,
        PauseButton
    }

    private List<GameObject> UIComponents = new List<GameObject>();

    Transform timer;
    Transform health;
    Transform score;

    private int time = 0;
    
    private void clearUI() {
        foreach(Transform child in transform) {
            child.gameObject.SetActive(false);
        }
    }

    public void setUIComponent(UI component) {
        clearUI();
        transform.GetChild((int) component).gameObject.SetActive(true);
    }

    public void changeHealth(int value) {
        for(int i = 0; i < health.childCount; i++) {
            if(i >= value) {
                health.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void changeScore(int value) {
        score.GetChild(1).GetComponent<TextMeshProUGUI>().text = value.ToString();
    }

    IEnumerator startTimer() {
        while(true) {
            time++;
            timer.GetChild(1).GetComponent<TextMeshProUGUI>().text = time.ToString();
            yield return new WaitForSeconds(1f);
        }
    }

    private void startSecondsCount() {
        StartCoroutine(startTimer());
    }


    private void Awake() {
        foreach(Transform child in transform) {
            UIComponents.Add(child.gameObject);
        }
        timer = UIComponents[(int) UI.Hud].transform.GetChild((int) HUD.Time);
        health = UIComponents[(int) UI.Hud].transform.GetChild((int) HUD.Health);
        score = UIComponents[(int) UI.Hud].transform.GetChild((int) HUD.Score);
    }

    private void Start() {
        Invoke("startSecondsCount", 1f);
    }

}
