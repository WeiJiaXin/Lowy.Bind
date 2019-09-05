using System.Collections;
using System.Collections.Generic;
using Lowy.Bind;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Awake()
    {
        Binder.Bind<IInterface>().To<MyClass2>().ToName(MyEnum._1);
        Binder.Bind<IInterface>().To<MyClass>();
        Binder.GetBind<IInterface>().ToSingleForAll();
        Binder.ReflectionAll();
    }
    // Start is called before the first frame update
    void Start()
    {
        print(Binder.GetInstance<IInterface>(MyEnum._1,"strTest").GetType());
        print(Binder.GetInstance<IInterface>()+"--");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public enum MyEnum
{
    _1,_2
}
public interface IInterface
{
    string s { get; set; }
}
public class MyClass:IInterface
{
    public string s { get; set; }

    public MyClass()
    {
        Debug.Log("MyuClass");
    }
}
public class MyClass2 : IInterface
{
    public string s { get; set; }
    [Inject]
    public IInterface inf;
    private MyClass2(string s)
    {
        this.s = s;
        Debug.Log(s);
        Binder.InjectObj(this);
    }
}