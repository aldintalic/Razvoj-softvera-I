#pragma checksum "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Feed\Prikaz.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9bf5f9e2b02f0f9554abd452871912194d0b83f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Feed_Prikaz), @"mvc.1.0.view", @"/Views/Feed/Prikaz.cshtml")]
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
#line 1 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Feed\Prikaz.cshtml"
using FIT_PONG.ViewModels.FeedVMs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9bf5f9e2b02f0f9554abd452871912194d0b83f1", @"/Views/Feed/Prikaz.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"438b6b2e6f34317388d1a6ef6e05391772603c6e", @"/Views/_ViewImports.cshtml")]
    public class Views_Feed_Prikaz : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Objava", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Dodaj", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Prikaz", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Feed\Prikaz.cshtml"
  
    ViewData["Title"] = "Prikaz";
    DisplayFeedVM fid = ViewBag.fid;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Feed\Prikaz.cshtml"
Write(fid.naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9bf5f9e2b02f0f9554abd452871912194d0b83f15080", async() => {
                WriteLiteral("Dodaj objavu");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 8 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Feed\Prikaz.cshtml"
                                                WriteLiteral(fid.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<br /><br />\r\n");
#nullable restore
#line 10 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Feed\Prikaz.cshtml"
 if (fid.Objave.Count() == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Trenutno nema objava dodajte nekad novu</p>\r\n");
#nullable restore
#line 13 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Feed\Prikaz.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table>\r\n");
#nullable restore
#line 17 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Feed\Prikaz.cshtml"
         foreach (var x in fid.Objave)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>   \r\n                <td>\r\n                    <table>\r\n                        <tr>\r\n                            <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9bf5f9e2b02f0f9554abd452871912194d0b83f18493", async() => {
#nullable restore
#line 24 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Feed\Prikaz.cshtml"
                                                                                                Write(x.Naziv);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 24 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Feed\Prikaz.cshtml"
                                                                                 WriteLiteral(x.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                            <td class=\"small\">");
#nullable restore
#line 25 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Feed\Prikaz.cshtml"
                                         Write(x.DatumKreiranja);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                            <td class=""small"">Napisao/la : </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style=""border-bottom:1px solid"">
                    ");
#nullable restore
#line 33 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Feed\Prikaz.cshtml"
               Write(x.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 36 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Feed\Prikaz.cshtml"
            
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
#nullable restore
#line 39 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Feed\Prikaz.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<br /><br />\r\n<input type=\"button\" value=\"Edit\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1132, "\"", 1183, 3);
            WriteAttributeValue("", 1142, "window.location.href=\'/Feed/Edit/", 1142, 33, true);
#nullable restore
#line 41 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Feed\Prikaz.cshtml"
WriteAttributeValue("", 1175, fid.ID, 1175, 7, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1182, "\'", 1182, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n<input type=\"button\" value=\"Obrisi\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1224, "\"", 1277, 3);
            WriteAttributeValue("", 1234, "window.location.href=\'/Feed/Obrisi/", 1234, 35, true);
#nullable restore
#line 42 "C:\Users\talicni\Desktop\SEMINARSKI_RAD_RS_1\webapp\FIT PONG\FIT PONG\Views\Feed\Prikaz.cshtml"
WriteAttributeValue("", 1269, fid.ID, 1269, 7, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1276, "\'", 1276, 1, true);
            EndWriteAttribute();
            WriteLiteral("  />\r\n\r\n");
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
