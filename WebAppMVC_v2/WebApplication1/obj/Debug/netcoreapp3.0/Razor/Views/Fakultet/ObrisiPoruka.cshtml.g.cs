#pragma checksum "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Fakultet\ObrisiPoruka.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3beb01dc2dffd78b142f7085d9bee76d84f30942"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Fakultet_ObrisiPoruka), @"mvc.1.0.view", @"/Views/Fakultet/ObrisiPoruka.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3beb01dc2dffd78b142f7085d9bee76d84f30942", @"/Views/Fakultet/ObrisiPoruka.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Fakultet_ObrisiPoruka : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1 style=\"font-family: sans-serif\">Uspjesno obrisan fakultet ");
#nullable restore
#line 2 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Fakultet\ObrisiPoruka.cshtml"
                                                         Write(TempData["nekiKey"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<h2>");
#nullable restore
#line 3 "C:\Users\admin\source\repos\EntityFrameworkExercise\WebApplication1\Views\Fakultet\ObrisiPoruka.cshtml"
Write(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<a href=\"/fakultet/index\">Go back</a>\r\n");
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
