using System.Collections.Generic;

namespace Gotchi.Objects
{
  public class Tamagotchi
  {
    private string _name;
    private int _food;
    private int _attention;
    private int _rest;
    private int _id;
    private static List<Tamagotchi> _instances = new List<Tamagotchi>{};


    public Tamagotchi (string name, int food = 5, int attention = 10, int rest = 7)
    {
      _name = name;
      _food = food;
      _attention = attention;
      _rest = rest;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public int GetFood()
    {
      return _food;
    }

    public void SetFood(int newFood)
    {
      _food = newFood;
    }

    public int GetAttention()
    {
      return _attention;
    }

    public void SetAttention(int newAttention)
    {
      _attention = newAttention;
    }

    public int GetRest()
    {
      return _rest;
    }

    public void SetRest(int newRest)
    {
      _rest = newRest;
    }

    public static List<Tamagotchi> GetAll()
    {
      return _instances;
    }
    public int GetId()
    {
      return _id;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Tamagotchi Find(int searchId)
    {
      return _instances[searchId - 1];
    }
  }
}
