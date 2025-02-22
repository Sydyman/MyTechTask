using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button buttonKeyboard, buttonSwipe, buttonDrag, buttonResume;
    public InputController inputController;

    private void Start()
    {
        buttonKeyboard.onClick.AddListener(() => ChangeControlType(0));
        buttonSwipe.onClick.AddListener(() => ChangeControlType(1));
        buttonDrag.onClick.AddListener(() => ChangeControlType(2));
        buttonResume.onClick.AddListener(ResumeGame);

        int savedControl = PlayerPrefs.GetInt("ControlType", 0);
        ChangeControlType(savedControl);

    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    private void ChangeControlType(int type)
    {
        InputController.ChangeControlType(type);
        PlayerPrefs.SetInt("ControlType", type); 
        PlayerPrefs.Save(); 
    }


}
