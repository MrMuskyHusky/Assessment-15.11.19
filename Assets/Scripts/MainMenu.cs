using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public menuSelect MenuSelect = menuSelect.Play;
    public GameObject SettingsGO;

    private void Update()
    {
        if (Settings.SettingsOpen)
        {
            SettingsGO.SetActive(true);
        }
        else if (!Settings.SettingsOpen)
        {
            SettingsGO.SetActive(false);
        }
    }

    public void ClickButton()
    {
        switch (MenuSelect)
        {
            case menuSelect.Play:
                break;
            case menuSelect.Settings:
                Settings.SettingsOpen = !Settings.SettingsOpen;
                break;
            case menuSelect.Quit:
                Application.Quit();
                break;
        }
    }

    public enum menuSelect
    {
        Play,
        Settings,
        Quit
    }
}
