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
/// Poison debuff.  Derived from StatusEffect
/// </summary>

public class Poison : StatusEffect
{
    public Poison() : base() { }

	public Poison(int duration, int level) : base(duration, level) { }

   /* public override void Update(IObservable character)
    {
        this.Execute(character);
    } */

    protected override void Execute(IObservable character)
    {
        Character observed = (Character)character;

        Random random = new Random();
        int damage = (random.Next(2, 9) * this.level);
        observed.CurrentHP -= damage;

        --this.duration;

        this.outputText = observed.Name + " suffers " + damage + " damage from poison!<br />";

        if (this.duration <= 0)
        {
            character.Detach(this);
        }
    }

    public override string Display()
    {
        if (this.outputText != null) { return this.outputText; }
        else { return ""; }
    }
}