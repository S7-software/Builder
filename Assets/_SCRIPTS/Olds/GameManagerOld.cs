using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerOld : MonoBehaviour
{
    [SerializeField] GameObject Room;
    [SerializeField] Transform Center;
    Rigidbody _rigiCenter;
    Blok[] blocks = new Blok[9];

    private void Awake()
    {
        _rigiCenter = Center.gameObject.GetComponent<Rigidbody>();
    }
    void Start()
    {
        SetFloors();
    }

    private void SetFloors()
    {
        int i = 0;
        for (int z = 0; z > -3; z--)
        {
            for (int x = 0; x < 3; x++)
            {
                blocks[i] = new Blok(x,0,z);
                i++;
            }
            
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RandomAdd()
    {
        if (!_rigiCenter.useGravity) _rigiCenter.useGravity = true;
        Blok temp = RandomLocation();
        Vector3 loc = new Vector3(temp.x, temp.floor, temp.z);
        temp.AddFloor();
    
       GameObject go= Instantiate(Room, loc, Quaternion.identity,Center);
        _rigiCenter.mass = _rigiCenter.mass + go.GetComponent<CubeOld>().mass;
    }

    Blok RandomLocation()
    {
        return blocks[UnityEngine.Random.Range(0, 9)];
    }
 
}

public class Blok
{
    public int x;
    public int z;
    public int floor;
    public Blok(int x,int floor, int z)
    {
        this.x = x;
        this.floor = floor;
        this.z = z;
    }
    public void AddFloor() { floor++; }
}
