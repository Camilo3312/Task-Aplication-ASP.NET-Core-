#pragma checksum "C:\Users\Camilo\Desktop\Task Aplication\Task Aplication\Views\Admin\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84594ccf1cee5a0eff67491d3fe4d8ed02a1f294"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Dashboard), @"mvc.1.0.view", @"/Views/Admin/Dashboard.cshtml")]
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
#line 1 "C:\Users\Camilo\Desktop\Task Aplication\Task Aplication\Views\_ViewImports.cshtml"
using Task_Aplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Camilo\Desktop\Task Aplication\Task Aplication\Views\_ViewImports.cshtml"
using Task_Aplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84594ccf1cee5a0eff67491d3fe4d8ed02a1f294", @"/Views/Admin/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38342b383d9710ce79a1116ecec72b323c393e2b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Task_Aplication.Models.DataBase.User>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Camilo\Desktop\Task Aplication\Task Aplication\Views\Admin\Dashboard.cshtml"
  
    ViewData["title"] = "Panel del control";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\Camilo\Desktop\Task Aplication\Task Aplication\Views\Admin\Dashboard.cshtml"
 foreach(var i in Model)
{   

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card_user\">\r\n        <p>");
#nullable restore
#line 9 "C:\Users\Camilo\Desktop\Task Aplication\Task Aplication\Views\Admin\Dashboard.cshtml"
      Write(i.Iduser);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>");
#nullable restore
#line 10 "C:\Users\Camilo\Desktop\Task Aplication\Task Aplication\Views\Admin\Dashboard.cshtml"
      Write(i.Names);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>");
#nullable restore
#line 11 "C:\Users\Camilo\Desktop\Task Aplication\Task Aplication\Views\Admin\Dashboard.cshtml"
      Write(i.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>");
#nullable restore
#line 12 "C:\Users\Camilo\Desktop\Task Aplication\Task Aplication\Views\Admin\Dashboard.cshtml"
      Write(i.Rol);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>  \r\n");
#nullable restore
#line 14 "C:\Users\Camilo\Desktop\Task Aplication\Task Aplication\Views\Admin\Dashboard.cshtml"
}    

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Dashboard</h1>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Task_Aplication.Models.DataBase.User>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
