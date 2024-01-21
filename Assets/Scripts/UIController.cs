using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    static Transform health;
    Transform score;
    Transform pauseButton;

    private bool gamePausedButton = false;
    [SerializeField] private Sprite play;
    [SerializeField] private Sprite pause;
    
    private void clearUI() {
        foreach(Transform child in transform) {
            child.gameObject.SetActive(false);
        }
    }

    public void setUIComponent(UI component) {
        clearUI();
        transform.GetChild((int) component).gameObject.SetActive(true);
    }

    public static void changeHealth(int value) {
        for(int i = 0; i < health.childCount; i++) {
            if(i < value) {
                health.GetChild(i).gameObject.SetActive(true);
            }
            else { 
                health.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void changeScore(int value) {
        score.GetChild(1).GetComponent<TextMeshProUGUI>().text = value.ToString();
    }

    public void changeTime(int value) {
        timer.GetChild(1).GetComponent<TextMeshProUGUI>().text = value.ToString();
    }

    public void togglePauseButton() {
        if(gamePausedButton) {
            GameController.resumeGame();
            pauseButton.GetComponent<Image>().sprite = pause;
            UIComponents[(int) UI.PauseMenu].SetActive(false);
            gamePausedButton = false;
        }
        else {
            GameController.pauseGame();
            pauseButton.GetComponent<Image>().sprite = play;
            UIComponents[(int) UI.PauseMenu].SetActive(true);
            gamePausedButton = true;
        }
    }

    private void initializeVolume() {
        Slider volumeBar = UIComponents[(int) UI.OptionsMenu].transform.Find("Slider").GetComponent<Slider>();
        volumeBar.value = GameController.audioVolume;
    }

    private void getHUDReferences() {
        timer = UIComponents[(int) UI.Hud].transform.GetChild((int) HUD.Time);
        health = UIComponents[(int) UI.Hud].transform.GetChild((int) HUD.Health);
        score = UIComponents[(int) UI.Hud].transform.GetChild((int) HUD.Score);
        pauseButton = UIComponents[(int) UI.Hud].transform.GetChild((int) HUD.PauseButton);
    }

    private void Awake() {
        foreach(Transform child in transform) {
            UIComponents.Add(child.gameObject);
        }
        getHUDReferences();
        if(SceneManager.GetActiveScene().name == "Level1") {
            initializeVolume();
        }
    }

}
