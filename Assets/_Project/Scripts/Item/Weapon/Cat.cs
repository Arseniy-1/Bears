using UnityEngine;

public class Cat: Animal
{
    public override void Test()
    {
        base.Test();
        Debug.Log("im Animal");
    }
}