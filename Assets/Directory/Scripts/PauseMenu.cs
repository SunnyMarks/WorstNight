using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour

{
    [SerializeField] GameObject pauseMenu;

    [SerializeField] Player_SO player;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

        player.isGamePaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

        player.isGamePaused = false;
    }

    public class PopupOpener : MonoBehaviour
    {
        public GameObject Popup;

        public void OpenPopup()
        {
            if (Popup != null)
            {
                bool isActive = Popup.activeSelf;

                Popup.SetActive(!isActive);
            }
        }
    }
}
