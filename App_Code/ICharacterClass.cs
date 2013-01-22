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
/// This interface defines all of the operations each character class can execute.
/// </summary>
 
public interface ICharacterClass
{
    int HP { get; }
    int TP { get; }
    int BaseDMG { get; }
    int HPMultiplier { get; }
    int TPMultiplier { get; }
    int BaseDMGMultiplier { get; }
    int BaseDefense { get; }
}