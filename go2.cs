using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void Change(){
        SceneManager.LoadScene("Stage2");
    }
}
