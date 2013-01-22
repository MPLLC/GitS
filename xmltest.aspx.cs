using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Reflection;

public partial class xmltest : System.Web.UI.Page
{
    public StatusEffect CreateStatusEffect(XElement se)
    {
        if (se.Element("Type") != null)
        {
            StatusEffect result = (StatusEffect)Assembly.GetExecutingAssembly().CreateInstance(((string)se.Element("Type")));
            result.Duration = (int)se.Element("Duration");
            result.Level = (int)se.Element("Level");

            return result;
        }
        else
        {
            throw new Exception();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        XDocument doc = XDocument.Load(MapPath("CharacterClasses/Hacker.xml"));

        List<Attack> charAttacks = (from attack in doc.Descendants("Attacks")
                                    select new Attack
                                    {
                                        Name = (string)attack.Element("AttackName"),
                                        Level = (int)attack.Element("AttackLevel"),
                                        TPCost = (int)attack.Element("TPCost"),
                                        DMGModifier = (double)attack.Element("DMGModifier"),
                                        HitPenalty = (double)attack.Element("HitPenalty"),
                                        Effect = attack.Element("StatusEffect").Element("Type") == null ? null :
                                            new Poison
                                            {
                                                Duration = (int)attack.Element("StatusEffect").Element("Duration"),
                                                Level = (int)attack.Element("StatusEffect").Element("Level")
                                            }
                                    }).ToList();

        foreach (Attack attack in charAttacks)
        {
            output.InnerHtml = attack.Name + "<br />";
        }
    }
}