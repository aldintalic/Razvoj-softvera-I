#pragma checksum "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\DodajStudentaForma.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7001e05c6d1d19d51211ecc8737bbde3c932700a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_DodajStudentaForma), @"mvc.1.0.view", @"/Views/Student/DodajStudentaForma.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\DodajStudentaForma.cshtml"
using ClassLibrary1.ViewsModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\DodajStudentaForma.cshtml"
using EntityFrameworkExercise.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\DodajStudentaForma.cshtml"
using WebApplication1.helper;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7001e05c6d1d19d51211ecc8737bbde3c932700a", @"/Views/Student/DodajStudentaForma.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_DodajStudentaForma : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin: 20px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/student/dodaj"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-group"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\DodajStudentaForma.cshtml"
  

    var fakulteti = (List<ComboBoxVM>) (TempData["fakultetiKey"]);
    var opstine = (List<ComboBoxVM>) (TempData["opstineKey"]);
    var student= (Student) (TempData["studentKey"]);
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7001e05c6d1d19d51211ecc8737bbde3c932700a5493", async() => {
                WriteLiteral("\r\n    <table>\r\n        <tr>\r\n");
                WriteLiteral("            <td> <input type=\"text\" name=\"studentID\"");
                BeginWriteAttribute("value", " value=\"", 538, "\"", 557, 1);
#nullable restore
#line 20 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\DodajStudentaForma.cshtml"
WriteAttributeValue("", 546, student.ID, 546, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" hidden/></td>\r\n        </tr>\r\n        <tr>\r\n            <td>\r\n                <label>Ime</label>\r\n            </td>\r\n            <td> <input type=\"text\" name=\"Ime\"");
                BeginWriteAttribute("value", " value=\"", 722, "\"", 742, 1);
#nullable restore
#line 26 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\DodajStudentaForma.cshtml"
WriteAttributeValue("", 730, student.Ime, 730, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n        </tr>\r\n        <tr>\r\n            <td>\r\n                <label>Prezime</label>\r\n            </td>\r\n            <td> <input type=\"text\" name=\"Prezime\"");
                BeginWriteAttribute("value", " value=\"", 909, "\"", 933, 1);
#nullable restore
#line 32 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\DodajStudentaForma.cshtml"
WriteAttributeValue("", 917, student.Prezime, 917, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("/></td>\r\n        </tr>\r\n        <tr>\r\n            <td>\r\n                <label>Datum rodjenja</label>\r\n            </td>\r\n            <td>\r\n                <input type=\"datetime\" name=\"DatumRodjenja\"");
                BeginWriteAttribute("value", " value=\"", 1133, "\"", 1163, 1);
#nullable restore
#line 39 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\DodajStudentaForma.cshtml"
WriteAttributeValue("", 1141, student.DatumRodjenja, 1141, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("/>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td>\r\n                <label>Opstina rodjenja ID</label>\r\n            </td>\r\n            <td>\r\n");
                WriteLiteral("                ");
#nullable restore
#line 54 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\DodajStudentaForma.cshtml"
           Write(HtmlFormaAlati.GenerisiComboBox("OpstinaRodjenjaID", opstine, student.OpstinaRodjenjaID));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td>\r\n                <label>Opstina prebivalista ID</label>\r\n            </td>\r\n            <td>\r\n");
                WriteLiteral("                ");
#nullable restore
#line 69 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\DodajStudentaForma.cshtml"
           Write(HtmlFormaAlati.GenerisiComboBox("OpstinaPrebivalistaID", opstine, student.OpstinaPrebivalistaID));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td>\r\n                <label>Fakultet ID</label>\r\n            </td>\r\n            <td>\r\n");
                WriteLiteral("                ");
#nullable restore
#line 84 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\DodajStudentaForma.cshtml"
           Write(HtmlFormaAlati.GenerisiComboBox("FakultetID", fakulteti, student.FakultetID));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td>\r\n                <button class=\"btn btn-primary\" type=\"submit\">Dodaj</button>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<a href=\"/student\" style=\"text-decoration: none; color: blueviolet;font-size: 20px\">  << Vrati se na početnu</a>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
