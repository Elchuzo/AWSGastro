#pragma checksum "C:\Users\Oscar\source\repos\GastroAvancesWeb\GastroAvancesWeb\Views\_ViewStart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c67dcf3470301b0b31b738fe49c77c604895f753"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views__ViewStart), @"mvc.1.0.view", @"/Views/_ViewStart.cshtml")]
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
#line 1 "C:\Users\Oscar\source\repos\GastroAvancesWeb\GastroAvancesWeb\Views\_ViewImports.cshtml"
using GastroAvancesWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Oscar\source\repos\GastroAvancesWeb\GastroAvancesWeb\Views\_ViewImports.cshtml"
using GastroAvancesWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c67dcf3470301b0b31b738fe49c77c604895f753", @"/Views/_ViewStart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fffe38b900749a9d05590c6e026a3fab21b5185", @"/Views/_ViewImports.cshtml")]
    public class Views__ViewStart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Oscar\source\repos\GastroAvancesWeb\GastroAvancesWeb\Views\_ViewStart.cshtml"
  
    if (this.User.IsInRole("Administrator"))
    {
        Layout = "~/Views/Shared/_Layout_admin.cshtml";
    }
    else
    {
        Layout = "~/Views/Shared/_Layout.cshtml";
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