#pragma checksum "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5173f0ae3bdb482f39dc3aca654a7c727267917"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Takmicenje_Dodaj), @"mvc.1.0.view", @"/Views/Takmicenje/Dodaj.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5173f0ae3bdb482f39dc3aca654a7c727267917", @"/Views/Takmicenje/Dodaj.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"438b6b2e6f34317388d1a6ef6e05391772603c6e", @"/Views/_ViewImports.cshtml")]
    public class Views_Takmicenje_Dodaj : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FIT_PONG.ViewModels.TakmicenjeVMs.CreateTakmicenjeVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/jquery.mentionsInput.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("checkRucni"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "datetime-local", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Dodaj", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
  
    ViewData["Title"] = "Dodaj";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>

    tr td {
        /*margin-right: 25px;*/
        width: 50%;
    }

    .Default {
        display: none;
        opacity: 0;
        max-height: 0;
        overflow: hidden;
    }

    .Toggle {
        display: table-row-group;
        opacity: 1;
        max-height: 100px; /* little bit of a magic number :( */
        overflow: visible;
    }

    h3 {
        color: #8f8f8f;
    }

    .-sew-list-container {
        position: absolute;
        background: white;
        border: 1px solid #DDD;
        border-radius: 3px;
        box-shadow: 0 0 5px rgba(0, 0, 0, 0.1);
        min-width: 180px;
    }

    .-sew-list {
        list-style: none;
        margin: 0;
        padding: 0;
        max-height: 100px;
        overflow: scroll;
    }

    .-sew-list-item {
        display: block;
        padding: 5px 10px;
        border-bottom: 1px solid #DDD;
        cursor: pointer;
    }


        .-sew-list-item small {
            color: #afafaf;
 ");
            WriteLiteral("       }\r\n\r\n        .-sew-list-item.selected {\r\n            color: white;\r\n            background: #4183C4;\r\n            text-decoration: none;\r\n        }\r\n</style>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a5173f0ae3bdb482f39dc3aca654a7c7272679177966", async() => {
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
            WriteLiteral("\r\n\r\n<h1>Dodaj novo takmicenje</h1>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5173f0ae3bdb482f39dc3aca654a7c7272679179118", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5173f0ae3bdb482f39dc3aca654a7c7272679179380", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 72 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <table>\r\n        <tr>\r\n            <td>Naziv</td>\r\n            <td>");
#nullable restore
#line 76 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
           Write(Html.EditorFor(mod => mod.Naziv));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 77 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
           Write(Html.ValidationMessageFor(s => s.Naziv, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>Rucni unos prijava (u suprotnom definisite registracije)</td>\r\n            <td>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a5173f0ae3bdb482f39dc3aca654a7c72726791711889", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#nullable restore
#line 81 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.RucniOdabir);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</td>\r\n\r\n\r\n        </tr>\r\n        <tbody id=\"registracije\">\r\n            <tr class=\"RegistracijeRed\">\r\n                <td>Pocetak prijava</td>\r\n                <td>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a5173f0ae3bdb482f39dc3aca654a7c72726791713666", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 88 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.RokPocetkaPrijave);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 89 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
               Write(Html.ValidationMessageFor(s => s.RokPocetkaPrijave, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n            </tr>\r\n            <tr class=\"RegistracijeRed\">\r\n                <td>Kraj prijava</td>\r\n                <td>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a5173f0ae3bdb482f39dc3aca654a7c72726791715893", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 94 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.RokZavrsetkaPrijave);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 95 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
               Write(Html.ValidationMessageFor(s => s.RokZavrsetkaPrijave, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n            </tr>\r\n            <tr class=\"RegistracijeRed\">\r\n                <td>Minimalni ELO</td>\r\n                <td>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a5173f0ae3bdb482f39dc3aca654a7c72726791718125", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
#nullable restore
#line 100 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.MinimalniELO);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 101 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
               Write(Html.ValidationMessageFor(s => s.MinimalniELO, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            </tr>\r\n        </tbody>\r\n        <tbody id=\"RucniIgraciRed\" class=\"Default\">\r\n            <tr>\r\n                <td>Korisnicka imena igraca (format : ");
                WriteLiteral("@KorisnickoIme razmak)</td>\r\n                <td>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("textarea", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5173f0ae3bdb482f39dc3aca654a7c72726791720472", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper);
#nullable restore
#line 107 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.RucnoOdabraniIgraci);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 108 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
               Write(Html.ValidationMessageFor(s => s.RucnoOdabraniIgraci, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            </tr>\r\n        </tbody>\r\n        <tr>\r\n            <td>Rasporedi igrace na osnovu elo? (prazno oznacava random)</td>\r\n            <td>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a5173f0ae3bdb482f39dc3aca654a7c72726791722535", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 113 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Seeded);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>Kategorija</td>\r\n            <td>");
#nullable restore
#line 117 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
           Write(Html.DropDownListFor(n => n.KategorijaID, new SelectList(ViewBag.kategorije, "ID", "Opis"), "Odaberite kategoriju"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 118 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
           Write(Html.ValidationMessageFor(s => s.KategorijaID, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n        </tr>\r\n        <tr>\r\n            <td>Sistem</td>\r\n            <td>");
#nullable restore
#line 123 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
           Write(Html.DropDownListFor(n => n.SistemID, new SelectList(ViewBag.sistemi, "ID", "Opis"), "Odaberite sistem"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 124 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
           Write(Html.ValidationMessageFor(s => s.SistemID, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n        </tr>\r\n        <tr>\r\n            <td>Vrsta</td>\r\n            <td>");
#nullable restore
#line 129 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
           Write(Html.DropDownListFor(n => n.VrstaID, new SelectList(ViewBag.vrste, "ID", "Opis"), "Odaberite vrstu"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 130 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
           Write(Html.ValidationMessageFor(s => s.VrstaID, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n        </tr>\r\n        <tr>\r\n            <td>Status</td>\r\n            <td>");
#nullable restore
#line 135 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
           Write(Html.DropDownListFor(n => n.StatusID, new SelectList(ViewBag.statusi, "ID", "Opis"), "Odaberite status"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 136 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
           Write(Html.ValidationMessageFor(s => s.StatusID, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n        </tr>\r\n        <tr>\r\n            <td>Datum pocetka</td>\r\n            <td>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a5173f0ae3bdb482f39dc3aca654a7c72726791727251", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 141 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.DatumPocetka);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 142 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Takmicenje\Dodaj.cshtml"
           Write(Html.ValidationMessageFor(s => s.DatumPocetka, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n        </tr>\r\n    </table>\r\n    <input type=\"submit\" value=\"Dodaj\" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            if ($('#checkRucni').is("":checked"")) {
                $('#RucniIgraciRed').addClass(""Toggle"");
                $('#registracije').addClass(""Default"");
                $('#VrstaID option[value=""2""]').prop(""disabled"", true);
                $('#VrstaID option[value=""1""]').prop(""selected"", true);
            }
            $('#checkRucni').change(function () {
                if ($(this).is("":checked"")) {
                    $('#RucniIgraciRed').addClass(""Toggle"");
                    $('#registracije').addClass(""Default"");
                    $('#VrstaID option[value=""2""]').prop(""disabled"", true);
                    $('#VrstaID option[value=""1""]').prop(""selected"", true);
                } else {
                    $('#RucniIgraciRed').removeClass(""Toggle"");
                    $('#registracije').removeClass(""Default"");
                    $('#VrstaID option[value=""2""]').prop(""disabled"", false);

                }
          ");
                WriteLiteral("  });\r\n\r\n        })\r\n\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FIT_PONG.ViewModels.TakmicenjeVMs.CreateTakmicenjeVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
