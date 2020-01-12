using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMovement : MonoBehaviour
{
    public List<Engine> Engines = new List<Engine>();
    public Transform ShipT = null;
    public float turnSpeed = 9.0f;
    
    private readonly List<Gear> _gearbox = new List<Gear>();
    private short _transmission;
    private float _speed = 0.0f;
    [SerializeField] private Text Transmission = null;
    private void Awake()
    {
        _gearbox.Add(new Gear("R", -50, 0));
        _gearbox.Add(new Gear("N", 0, 0));
        _gearbox.Add(new Gear("1", 0, 25));
        _gearbox.Add(new Gear("2", 25, 50));
        _gearbox.Add(new Gear("3", 50, 75));
        _gearbox.Add(new Gear("4", 75, 100));
        _gearbox.Add(new Gear("5", 100, 175));
        _transmission = 1;
        Transmission.text =  _gearbox[_transmission].Name;
    }

    void Update()
    {
        //Turn();
        //Movement();
        //ShiftLever();
    }

    public void Turn(float Yaw, float Pitch, float Roll)
    {
        float yaw = turnSpeed * Time.deltaTime * Yaw;
        float pitch = turnSpeed * Time.deltaTime * Pitch;
        float roll = turnSpeed * Time.deltaTime * Roll;
        ShipT.Rotate(pitch, yaw, roll);
    }

    public void DownShift()
    {
        _transmission = (short)Mathf.Clamp(_transmission + 1, 0, _gearbox.Count - 1);
        Transmission.text = _gearbox[_transmission].Name;
    }

    public void UpShift()
    {

        _transmission = (short)Mathf.Clamp(_transmission - 1, 0, _gearbox.Count - 1);
        Transmission.text = _gearbox[_transmission].Name;
    }

    public void Movement(float horizontal, float vertical)
    {
        for (var i = 0; i <= (Engines.Count + 1) / 2; ++i)
        {
            _speed += Engines[i].Thrust() * Time.deltaTime;
            Engines[i].SwitchLight(true);
        }

        if (_transmission == 0)
        {
            _speed = Mathf.Clamp(_speed,_gearbox[_transmission].MaxSpeed ,_gearbox[_transmission].MinSpeed * -1);
            _speed *= -1;
        }
        else
        {
            _speed = Mathf.Clamp(_speed, _gearbox[_transmission].MinSpeed, _gearbox[_transmission].MaxSpeed);
        }

        var vectorToMoveX = horizontal * _speed * Time.deltaTime;
        var vectorToMoveZ = vertical * _speed * Time.deltaTime;
        ShipT.Translate(new Vector3(vectorToMoveX, 0, vectorToMoveZ));
    }
}

class Gear
{
    public string Name { get; }
    public float MaxSpeed { get; }
    public float MinSpeed { get; }

    public Gear(string name, int minSpeed, int maxSpeed)
    {
        Name = name;
        MinSpeed = minSpeed;
        MaxSpeed = maxSpeed;
    }

}
