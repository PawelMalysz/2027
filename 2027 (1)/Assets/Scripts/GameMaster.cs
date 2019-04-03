using UnityEngine.UI;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public Text msgBox;
    public float dTime;

    void Update()
    {
        if (dTime > 0)
            dTime -= Time.deltaTime;
        else
            msgBox.text = "";
    }

    public void ShowMessage(string message)
    {
        msgBox.text = message;
        dTime = 5;
    }

    public void ShowMessage(string message, float duration)
    {
        msgBox.text = message;
        dTime = duration;
    }
	
	
}
