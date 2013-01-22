using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Interface for objects that can be the subject of Observers
/// </summary>

public interface IObservable
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}