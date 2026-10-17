using UGU.Runtime;
using UnityEngine;

public class Launch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UGUGameSystemUtils.Create<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
