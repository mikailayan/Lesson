#pragma checksum "C:\Users\Web ve Mobil Prog\source\Lesson\Week_10\09_MVC_Proje1\DersBlogSitesi\Views\Dersler\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e924ccdbe78d9d85d7633badc23d71b0c331f3a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dersler_Index), @"mvc.1.0.view", @"/Views/Dersler/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e924ccdbe78d9d85d7633badc23d71b0c331f3a", @"/Views/Dersler/Index.cshtml")]
    public class Views_Dersler_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DersBlogSitesi.Models.Lesson>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<table class=""table table-warning border-dark w-50"">
    <thead>
        <tr class=""table-active"">

            <th scope=""col"">ID</th>
            <th scope=""col"">Name</th>
            <th scope=""col"">cat</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 23 "C:\Users\Web ve Mobil Prog\source\Lesson\Week_10\09_MVC_Proje1\DersBlogSitesi\Views\Dersler\Index.cshtml"
          
            foreach (var lesson in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 27 "C:\Users\Web ve Mobil Prog\source\Lesson\Week_10\09_MVC_Proje1\DersBlogSitesi\Views\Dersler\Index.cshtml"
                   Write(lesson.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                    <td> ");
#nullable restore
#line 28 "C:\Users\Web ve Mobil Prog\source\Lesson\Week_10\09_MVC_Proje1\DersBlogSitesi\Views\Dersler\Index.cshtml"
                    Write(lesson.LessonName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 29 "C:\Users\Web ve Mobil Prog\source\Lesson\Week_10\09_MVC_Proje1\DersBlogSitesi\Views\Dersler\Index.cshtml"
                   Write(lesson.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                </tr>\r\n");
#nullable restore
#line 31 "C:\Users\Web ve Mobil Prog\source\Lesson\Week_10\09_MVC_Proje1\DersBlogSitesi\Views\Dersler\Index.cshtml"
           

        }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DersBlogSitesi.Models.Lesson>> Html { get; private set; }
    }
}
#pragma warning restore 1591
