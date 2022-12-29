using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager GM { get; private set; }

    public InputField InputName;

    private string playerName;
    private int score;

    public void SetName() => playerName = InputName.text;

    public string GetName() { return playerName; }

    private void Awake()
    {
        if (GM != null)
        {
            Destroy(gameObject);
            return;
        }

        GM = this;
        DontDestroyOnLoad(gameObject);
    }
}
