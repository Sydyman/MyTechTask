using System.Collections.Generic;

public class ControlTypeSubject
{
    private List<IControlTypeObserver> observers = new List<IControlTypeObserver>();

    public void AddObserver(IControlTypeObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IControlTypeObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers(int newControlType)
    {
        foreach (var observer in observers)
        {
            observer.OnControlTypeChanged(newControlType);
        }
    }
}
