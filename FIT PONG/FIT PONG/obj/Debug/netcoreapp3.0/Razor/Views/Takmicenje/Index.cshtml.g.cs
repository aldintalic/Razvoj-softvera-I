#pragma checksum "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9223f30c1ffba2e517ab8a99e3b31f0a0e2faeb3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Takmicenje_Index), @"mvc.1.0.view", @"/Views/Takmicenje/Index.cshtml")]
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
#line 1 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\_ViewImports.cshtml"
using FIT_PONG;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\_ViewImports.cshtml"
using FIT_PONG.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml"
using FIT_PONG.ViewModels.TakmicenjeVMs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9223f30c1ffba2e517ab8a99e3b31f0a0e2faeb3", @"/Views/Takmicenje/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"438b6b2e6f34317388d1a6ef6e05391772603c6e", @"/Views/_ViewImports.cshtml")]
    public class Views_Takmicenje_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Takmicenje", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Dodaj", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml"
  
    ViewData["Title"] = "Index";
    var sve = (List<TakmicenjeVM>)ViewData["TakmicenjaKey"];

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9223f30c1ffba2e517ab8a99e3b31f0a0e2faeb35098", async() => {
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
            WriteLiteral(@"
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
<style>


    .css-table {
        display: table;
        border-collapse: collapse;
        box-sizing: border-box;
        border-top: 1px solid #dee2e6;
        margin-bottom: 1rem;
        width: 100%;
        overflow: scroll;
    }

    .css-table-header {
        display: table-header-group;
        font-weight: bold;
        background-color: rgb(191, 191, 191);
    }

    .css-table-body {
        display: table-row-group;
    }

    .css-table-row {
        display: table-row;
        text-decoration: none;
        color: black;
    }

        .css-table-row:hover {
            background-color: lightgray;
            cursor: pointer;
        text-decoration: none;

        }

        .css-table-header div,
        .css-table-row div {
            display: table-cell;
            padding: 0.75rem;
            border-top: 1px solid #dee2e6;
   ");
            WriteLiteral("     }\r\n\r\n    .css-table-header div {\r\n        text-align: center;\r\n        border: 1px solid rgb(255, 255, 255);\r\n    }\r\n</style>\r\n<h1>Takmicenja</h1>\r\n<br />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9223f30c1ffba2e517ab8a99e3b31f0a0e2faeb37447", async() => {
                WriteLiteral("Dodaj");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 59 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml"
 if (sve.Count() == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Nema trenutno pohranjenih takmicenja</p>\r\n");
#nullable restore
#line 62 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""css-table"">

        <div class=""css-table-row"">
            <div class=""css-table-header"">ID</div>
            <div class=""css-table-header"">Naziv</div>
            <div class=""css-table-header"">Minimalni ELO</div>
            <div class=""css-table-header"">Kategorija</div>
            <div class=""css-table-header"">Sistem</div>
            <div class=""css-table-header"">Vrsta</div>
            <div class=""css-table-header"">Prijave do:</div>
            <div class=""css-table-header"">Broj prijavljenih</div>
            <div class=""css-table-header"">Status</div>
        </div>
");
#nullable restore
#line 78 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml"
         foreach (var x in sve)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <a class=\"css-table-row\"");
            BeginWriteAttribute("href", " href=\"", 2236, "\"", 2270, 2);
            WriteAttributeValue("", 2243, "/Takmicenje/Prikaz?id=", 2243, 22, true);
#nullable restore
#line 80 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml"
WriteAttributeValue("", 2265, x.ID, 2265, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div>");
#nullable restore
#line 81 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml"
        Write(x.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div>");
#nullable restore
#line 82 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml"
        Write(x.Naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div>");
#nullable restore
#line 83 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml"
        Write(x.MinimalniELO);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div>");
#nullable restore
#line 84 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml"
        Write(x.Kategorija);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div>");
#nullable restore
#line 85 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml"
        Write(x.Sistem);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div>");
#nullable restore
#line 86 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml"
        Write(x.Vrsta);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div>");
#nullable restore
#line 87 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml"
        Write(x.DatumZavrsetkaPrijava.GetValueOrDefault().ToLongDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div>");
#nullable restore
#line 88 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml"
        Write(x.BrojPrijavljenih);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div>");
#nullable restore
#line 89 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml"
        Write(x.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    </a>\r\n");
#nullable restore
#line 91 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 93 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
