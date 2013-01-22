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
/// Simple container class containing the biographical information of each PlayerCharacter
/// </summary>

public class CharBio
{
    private string name;
    private string gender;
    private string desc;

	public CharBio(string name, string gender, string desc)
	{
        this.name = name;
        this.gender = gender;
        this.desc = desc;
	}

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string Gender
    {
        get { return this.gender; }
        set { this.gender = value; }
    }

    public string Desc
    {
        get { return this.desc; }
        set { this.desc = value; }
    }
}