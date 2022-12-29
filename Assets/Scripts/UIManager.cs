using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputField InputName;
    public Text HighscoreText;

    public void SetCurPlayerName() => GameManager.GM.SetName(InputName.text);

    public void StartNewGame(int sceneId) => ScenesManager.SM.LoadScene(sceneId);

    public void ExitGame() => ScenesManager.SM.ExitGame();

    private void Start()
    {
        HighscoreText.text = GameManager.GM.GetHighscoreString();
    }
}
