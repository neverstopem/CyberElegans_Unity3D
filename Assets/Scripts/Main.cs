using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    Elegans worm = null;
    float lastSecond = -1;

    void Start () {
        KeysMan.AddKeyEvent(KeyCode.Escape, Application.Quit);
        KeysMan.AddKeyEvent(KeyCode.F1, ToggleShowInfo);
        KeysMan.AddKeyEvent(KeyCode.F2, ToggleGravity);
        KeysMan.AddKeyEvent(KeyCode.F3, ToggleCrawl);
        KeysMan.AddKeyEvent(KeyCode.F4, ToggleNeuron);
        KeysMan.AddKeyEvent(KeyCode.Mouse0, checkCollision);
        
        UIMan.Inst.SetText(0, null, "Show/Hide Infomation (F1)");

        Init();
    }

    void ToggleShowInfo() {
        if (lastSecond == float.MaxValue) lastSecond = Time.time;
        else {
            lastSecond = float.MaxValue;
            for (int i = 1; i < 9; i++) UIMan.Inst.SetText(i, "", "");
        }
    }
    void ToggleGravity() { Globals.mode2 = !Globals.mode2; }
    void ToggleCrawl() { Globals.mode3 = !Globals.mode3; }
    void ToggleNeuron() { Globals.mode4 = !Globals.mode4; }
    void Init()
    {
        if (worm != null) return;

        worm = new Elegans(0.5f, 26);

        worm.ClearSelection();
        worm.rotateWormAroundAnterPosterAxis(90);

        float angle = -90;
        Globals.ort1 = Tools.RotateVector1AroundVector2(Globals.ort1, Vector3.right, angle);
        Globals.ort2 = Tools.RotateVector1AroundVector2(Globals.ort2, Vector3.right, angle);
        Globals.ort3 = Tools.RotateVector1AroundVector2(Globals.ort3, Vector3.right, angle);

        Globals.status = EAppStatus.running;
    }

    void Update()
    {
        if (Time.time > lastSecond + 0.1f) {
            UIMan.Inst.SetText(1, "Gravity (F2):", Globals.mode2);
            UIMan.Inst.SetText(2, "Crawling (F3):", Globals.mode3);
            UIMan.Inst.SetText(3, "Neuron (F4):", Globals.mode4);
            lastSecond = Time.time;
        }

        KeysMan.update();
        if (Globals.status == EAppStatus.running || Globals.status == EAppStatus.pause)
        {
            UpdateLogic();
            Draw();
        }
    }


    void UpdateLogic()
    {
        float dt = Time.deltaTime;
        int numOfIterations = (int)(dt / Globals.MaxDelta) + 1;

        if (numOfIterations != 0)                                                // Avoid Division By Zero
        {
            dt = dt / numOfIterations;
        }

        for (int i = 0; i < numOfIterations; ++i) {
            worm.UpdateLogic(dt);
        }
    }
    void checkCollision()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            Debug.Log(hit.collider.name);
            
            const string n = "neuron ";
            string str = hit.collider.name;
            if (str.IndexOf(n) >= 0) {
                string num = str.Substring(n.Length);
                worm.UpdateSelection(int.Parse(num));
            }

        }
    }

    void Draw() {
        if (worm != null) worm.Draw();

#if undo_ui
        my_glPrint(15, 60, "F1 = help show / hide", 0, 255, 175);
        if(f1) {
            my_glPrint(15, 80, "F2 = toggle fullscreen", 0, 255, 75);
            my_glPrint(15, 100, "F5 = toggle full view / neuromuscular system only", 0, 255, 75);
            my_glPrint(15, 120, "F6 = physics on/off", 0, 255, 75);
            my_glPrint(15, 140, "F7 = send sinusoidal pattern directly to muscles", 0, 255, 75);
            my_glPrint(15, 160, "F8 = send sinusoidal pattern to ventral cord motorneurons", 0, 255, 75);
            my_glPrint(15, 180, "mouse scroll - change scale", 175, 255, 0);
            my_glPrint(15, 200, "mouse right button - rotate scene", 175, 255, 0);
            my_glPrint(15, 220, "mouse right button - move scene", 175, 255, 0);
            my_glPrint(15, 240, "click at neuron with mouse right button - select / deselect neuron", 175, 255, 0);
            my_glPrint(15, 260, "key 'a' - activate selected neuron(s)", 255, 255, 0);
            my_glPrint(15, 280, "key 'r' - rotate nematode worm around longitudinal axis", 255, 255, 0);
            my_glPrint(15, 300, "NumPad's '4' = x--, '6' = x++, '2' = y--, '8' = y++, '1' = z--, '9' = z++", 255, 125, 0);
            my_glPrint(15, 320, "for moving small points defining connection paths between neurons", 255, 125, 0);
            my_glPrint(15, 340, "key 's' to save its positions changes [only in editor mode, when physics is still off and no worm rotation was performed]", 255, 125, 0);
        }
#endif
    }
} // end of class
