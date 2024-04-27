using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour

{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
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
