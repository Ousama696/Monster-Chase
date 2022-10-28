using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
   

    public void playGame()
    {
        int ObjSel = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GameManagment.instance.CharIndex = ObjSel;
        SceneManager.LoadScene("gamePlay");
    }


}//class




























