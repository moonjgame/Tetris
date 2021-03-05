using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Model model;
    public View view;
    private FSMSystem fsm;
    public CameraManger cameraManger;
    public GameManger gameManger;
    public AudioManger audioManger;
    void Start()
    {
        MakeFSM();
    }

    private void MakeFSM()
    {
        fsm = new FSMSystem();
        FSMState[] states = GetComponentsInChildren<FSMState>();
        foreach(FSMState s in states)
        {
            fsm.AddState(s,fsm,this);
        }
        MenuState menuState = GetComponentInChildren<MenuState>();
        fsm.SetCurrentState(menuState);
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
