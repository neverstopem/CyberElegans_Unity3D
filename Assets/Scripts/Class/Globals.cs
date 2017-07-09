using UnityEngine;

public class Globals
{
    public static int limit = 11;
    public static int done = 0;

    public static string ConfigPath = "/Resources/Configs/";
    public static string NeuronPosFile =    Application.dataPath + ConfigPath + "celegans302positions.new.txt";
    public static string NeuronConnFile =   Application.dataPath + ConfigPath + "celegans302connections.txt";
    public static string NeuronMuscleFile = Application.dataPath + ConfigPath + "neuromuscle.txt";
    
    public const float Gravity = -9.81f;
    public const float AirFrictionCoefficient = 0.002f;
    public const float GroundRepulsionConstant = 100;
    public const float GroundAbsorptionConstant = 2.0f;
    public const float GroundFrictionConstant = 0.6f;
    public const float GroundHeight = 0;
    public const float StiffCoeff = 80;
    public const float FrictCoeff = 0.6f;
    public const float MStrength = 20;    //1
    public const float Detect = -1;
    public const float neuron_normal = 0.008f;
    public const float neuron_selected = 0.015f;
    public const float MaxDelta = 0.009f;

    //int iter_counter = 5;// draw only one of 5 iterations in physical world to make everything faster
    public static int meet_obstacle = 0;
    public static float direction = 1;
    public static float scale = 20;
    public static int window_height = 0;
    public static Vector3 vbeg = new Vector3(0, 0, 0);
    public static Vector3 vend = new Vector3(0, 0, 0);
    public static Vector3 ort1 = new Vector3(1, 0, 0);
    public static Vector3 ort2 = new Vector3(0, 1, 0);
    public static Vector3 ort3 = new Vector3(0, 0, 1);
    public static Vector3 vcenter = new Vector3(0, 0, 0);
    public static Vector3 pos_rc = new Vector3(0, 0, 0);

    public static int mx;
    public static int my;
    public static bool ldown;
    public static bool rdown;
    public static uint mouse_button = 0;
    public static bool mode = true;
    public static bool mode2 = false;
    public static bool mode3 = false;
    public static bool mode4 = false;
    public static bool f9 = false;
    public static bool f1 = false;
    public static bool f10 = false;
    public static bool f11 = false;
    public static bool f6 = true;
    public static bool key_a = false;
    public static bool key_a_prev = false;
    public static bool key_r_prev = false;

    public static Color[] colors = {
        new Color(0.3f, 0.4f, 0.4f),    // 0: def
        new Color(0.7f, 0.7f, 0),       // 1: VB..
        new Color(0, 0.5f, 1),          // 2: DB..
        new Color(0.45f, 0, 0.2f),      // 3: AVB
        new Color(0.4f, 0, 0.4f),       // 4: PVC
        new Color(0.2f, 0, 0.6f)        // 5: DVA
    };

    public static char[] splitor = { '\t', ',' };



    public static EAppStatus status = EAppStatus.init;

    public static EWormParts renderSwitch = (EWormParts)(1 + 2 + 4 + 8 + 16);
    //public static EWormParts renderSwitch = (EWormParts)(1 + 2 + 4 + 8 + 16);

}

public enum EWormParts
{
    point   = 1,
    spring  = 2,
    muscle  = 4,
    neuron  = 8,
    axon    = 16,
}
public enum EAppStatus
{
    init = 0,
    running,
    pause,
}
