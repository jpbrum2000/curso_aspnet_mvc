#pragma checksum "C:\Users\ADM\curso_aspnet_mvc\SakilaWeb\Views\Film\CreateOrUpdate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8aa3d338be25562b8c820a04462855a0e1ec1185"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Film_CreateOrUpdate), @"mvc.1.0.view", @"/Views/Film/CreateOrUpdate.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Film/CreateOrUpdate.cshtml", typeof(AspNetCore.Views_Film_CreateOrUpdate))]
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
#line 1 "C:\Users\ADM\curso_aspnet_mvc\SakilaWeb\Views\_ViewImports.cshtml"
using SakilaWeb;

#line default
#line hidden
#line 2 "C:\Users\ADM\curso_aspnet_mvc\SakilaWeb\Views\_ViewImports.cshtml"
using SakilaWeb.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8aa3d338be25562b8c820a04462855a0e1ec1185", @"/Views/Film/CreateOrUpdate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc2e544edbf4d6a6c421e567a134c7bfa5c247e5", @"/Views/_ViewImports.cshtml")]
    public class Views_Film_CreateOrUpdate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SakilaWeb.ViewModel.CreateOrUpdateFilmViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(56, 582, true);
            WriteLiteral(@"
<div class=""container"">
    <from>
        <div class=""form-group"">
            <label>Title</label>
            <input type=""text"" class=""form-control"" />
        </div>
        <div class=""form-group"">
            <label>Description</label>
            <textarea rows=""4"" cols=""10"" class=""form-control""></textarea>
        </div>
        <div class=""form-group"">
            <label>Release Year</label>
            <input type=""number"" class=""form-control"" />
        </div>
        <input type=""submit"" class=""btn btn-primary"" value=""Save"" />
    </from>
</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SakilaWeb.ViewModel.CreateOrUpdateFilmViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
