using System;
using System.Reflection;
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
/// This interface is to be used by all objects that need to be able to create a full, deep 
/// copy of themselves.  The method itself comes from http://www.thomashapp.com/node/106.  I 
/// have put it as an interface rather than a class, as most of the objects that need to use it
/// will derive from other base classes.
/// </summary>

public interface IDeepCopy
{
    IDeepCopy DeepCopy();
}