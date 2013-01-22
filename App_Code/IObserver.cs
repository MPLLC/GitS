using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Interface for all Observers
/// </summary>

public interface IObserver
{
    void Update(IObservable subject);
}