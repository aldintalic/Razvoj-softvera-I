#pragma checksum "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\PrikaziStudente.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73723f5f4baf15c36932d8d5e6fd7e8a90463428"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_PrikaziStudente), @"mvc.1.0.view", @"/Views/Student/PrikaziStudente.cshtml")]
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
#line 1 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\PrikaziStudente.cshtml"
using EntityFrameworkExercise.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\PrikaziStudente.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73723f5f4baf15c36932d8d5e6fd7e8a90463428", @"/Views/Student/PrikaziStudente.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_PrikaziStudente : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Student>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap-solar.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\PrikaziStudente.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "73723f5f4baf15c36932d8d5e6fd7e8a904634285218", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "73723f5f4baf15c36932d8d5e6fd7e8a904634286332", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73723f5f4baf15c36932d8d5e6fd7e8a904634287483", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>PrikaziStudente</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73723f5f4baf15c36932d8d5e6fd7e8a904634288552", async() => {
                WriteLiteral(@"
<table class=""table table-dark"">
    <thead>
    <tr>
        <th>ID</th>
        <th>Ime</th>
        <th>Prezime</th>
        <th>Datum rodjenja</th>
        <th>Opstina rodjenja</th>
        <th>Opstina prebivalista</th>
        <th>Fakultet</th>
        <th>Delete</th>
    </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 32 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\PrikaziStudente.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 35 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\PrikaziStudente.cshtml"
           Write(item.ID);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 36 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\PrikaziStudente.cshtml"
           Write(item.Ime);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 37 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\PrikaziStudente.cshtml"
           Write(item.Prezime);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 38 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\PrikaziStudente.cshtml"
           Write(item.DatumRodjenja);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 39 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\PrikaziStudente.cshtml"
           Write(item.OpstinaRodjenja.Naziv);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 40 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\PrikaziStudente.cshtml"
           Write(item.OpstinaPrebivalista.Naziv);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 41 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\PrikaziStudente.cshtml"
           Write(item.Fakultet.Naziv);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td><a");
                BeginWriteAttribute("href", " href=\"", 1110, "\"", 1152, 2);
                WriteAttributeValue("", 1117, "/student/obrisistudenta?id=", 1117, 27, true);
#nullable restore
#line 42 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\PrikaziStudente.cshtml"
WriteAttributeValue("", 1144, item.ID, 1144, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"text-decoration: none; color: azure;\" onmouseover=\"this.style.color = \'grey\';\" onmouseout=\"this.style.color=\'azure\'\">Obrisi</a></td>\r\n        </tr>\r\n");
#nullable restore
#line 44 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Student\PrikaziStudente.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    </tbody>\r\n</table>\r\n<a href=\"/student\" style=\"text-decoration: none; color: blueviolet;font-size: 20px\">  <--- Vrati se na početnu</a>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Student>> Html { get; private set; }
    }
}
#pragma warning restore 1591
