using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputField InputName;
    public Text HighscoreText;

    public void FlushCurSession() => GameManager.GM.FlushScores();

    public void SetCurPlayerName() => GameManager.GM.SetName(InputName.text);

    public void StartNewGame(int sceneId)
    {
        if (InputName.text != "")
            ScenesManager.SM.LoadScene(sceneId);
        else
        {
            InputName.text = "Player";
            ScenesManager.SM.LoadScene(sceneId);
        }
    }

    public void ExitGame() => ScenesManager.SM.ExitGame();

    public void UpdateUI()
    {
        HighscoreText.text = GameManager.GM.GetHighscoreString();
        if (InputName.text != null)
            InputName.text = GameManager.GM.GetName();
    }

    private void Start() => UpdateUI();
}
