using UnityEngine;
using System.IO.Ports;
public class SerialController : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM3", 9600);
    public delegate void MovementInputHandler(Vector3 movementInput);
    public event MovementInputHandler OnMovementInput;
    private const int availableButtons = 4;
    private int[] buttonStates = new int[availableButtons];
    private Vector3 lastInput = new Vector3();
    private string lastData = "";

    void Start()
    {
        if (!sp.IsOpen)
            sp.Open();
    }
    void Update()
    {
        if (sp.IsOpen && sp.BytesToRead > 0)
        {
            ReceiveInput();
        }
    }

    void ReceiveInput()
    {
        string data = sp.ReadLine();
        if (data != lastData)
        {
            lastData = data;
            string[] splitData = data.Split(',');
            if (splitData.Length == availableButtons)
            {
                for (int i = 0; i < availableButtons; i++)
                {
                    int.TryParse(splitData[i], out buttonStates[i]);
                }
                ProcessInput();
            }
        }
    }

    void ProcessInput()
    {
        float right = buttonStates[0];
        float forward = buttonStates[1];
        float backward = buttonStates[2];
        float left = buttonStates[3];
        Vector3 input = new Vector3(left - right, 0f, forward - backward);
        if (input != lastInput)
        {
            lastInput = input;
            OnMovementInput?.Invoke(input);
        }
    }
    void OnApplicationQuit()
    {
        if (sp.IsOpen)
            sp.Close();
    }
}