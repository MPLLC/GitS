using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Abstract base class that represents a status effect that can be applied to a Character during combat
/// </summary>

abstract public class StatusEffect : IObserver
{
    #region Class Data Members

    protected int duration;
    protected int level;
    protected string outputText;

    #endregion

    #region Class Methods

    public StatusEffect()
    {
        this.duration = 0;
        this.level = 0;
        this.outputText = null;
    }

    public StatusEffect(int duration, int level)
    {
        this.duration = duration;
        this.level = level;
        this.outputText = null;
    }

    public void Update(IObservable character)
    {
        this.Execute(character);
    }

    protected abstract void Execute(IObservable character);

    public abstract string Display();

    #endregion

    #region Class Properties

    public int Duration
    {
        get { return this.duration; }
        set { this.duration = value; }
    }

    public int Level
    {
        get { return this.level; }
        set { this.level = value; }
    }

    public bool IsNull
    {
        get
        {
            if (this.duration == 0 || this.level == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    #endregion
}