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
        public static HtmlString GenerisiComboBox(string naziv, List<ComboBoxVM> podaci)
        {
            string comboBox = @"<select name=" + naziv + ">" +
                              "<option value=' ' disabled selected>---Chose value---</option>";

            foreach (var item in podaci)
                comboBox += "<option value=" + item.ID + ">" + item.Opis + "</option>";

            comboBox += "</select>";

            return new HtmlString(comboBox);

        }

    }
}
