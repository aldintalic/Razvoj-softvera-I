using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.ViewsModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebApplication1.helper
{
    public class HtmlFormaAlati
    {
        public static HtmlString GenerisiComboBox(string naziv, List<ComboBoxVM> podaci, int id)
        {
            string comboBox = @"<select class='form-control selcls' name=" + naziv + ">" +
                              "<option value=' ' disabled selected>---Chose value---</option>";

            foreach (var item in podaci)
            {
                if(item.ID==id)
                    comboBox += "<option value=" + item.ID + " selected>" + item.Opis + "</option>";
                else
                    comboBox += "<option value=" + item.ID + ">" + item.Opis + "</option>";
            }
            comboBox += "</select>";

            return new HtmlString(comboBox);

        }

    }
}
