#pragma checksum "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\Admin\UserList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27e5c65d45144e1fc40a9d6c8a0ad7e86eb4d1f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_UserList), @"mvc.1.0.view", @"/Views/Admin/UserList.cshtml")]
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
#line 2 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\_ViewImports.cshtml"
using MiniShopApp.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\_ViewImports.cshtml"
using MiniShopApp.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\_ViewImports.cshtml"
using MiniShopApp.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\_ViewImports.cshtml"
using MiniShopApp.WebUI.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\_ViewImports.cshtml"
using MiniShopApp.Core;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27e5c65d45144e1fc40a9d6c8a0ad7e86eb4d1f5", @"/Views/Admin/UserList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77e075d311e3beafea059a41ce3afc1b0ce52dce", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_UserList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<User>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/admin/user/delete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            DefineSection("Css", async() => {
                WriteLiteral("\r\n    <link href=\"https://cdn.datatables.net/1.12.1/css/dataTables.bootstrap5.min.css\" rel=\"stylesheet\" />\r\n");
            }
            );
            DefineSection("Scripts", async() => {
                WriteLiteral(@" 
    <script src=""https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js""></script>
    <script src=""https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap5.min.js""></script>
    <script>
        $(document).ready(function () {
            $('#userList').DataTable(
                {
                    lengthMenu: [
                        [2, 5, 10, 20, 40, -1],
                        [2, 5, 10, 20, 40, ""Tümü""]
                    ],
                    language: {
                        url:""//cdn.datatables.net/plug-ins/1.12.1/i18n/tr.json""
                    }
                }
            );
        });
    </script>
");
            }
            );
            WriteLiteral(@"<div class=""row"">
    <div class=""col-md-12"">
        <h6 class=""display-4"">User List</h6>
        <hr />
        <a href=""/admin/user/create"" class=""btn btn-sm btn-primary"">Create User</a>
        <hr />
        <table data-page-length=""3"" class=""table table-sm table-striped table-hover"" id=""userList"">
            <thead>
                <tr>
                    <td>First Name</td>
                    <td>Last Name</td>
                    <td>User Name</td>
                    <td>Email</td>
                    <td>Email Confirmed</td>
                    <td>Actions</td>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 42 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\Admin\UserList.cshtml"
                 if (Model.Count() > 0)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\Admin\UserList.cshtml"
                     foreach (var user in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr");
            BeginWriteAttribute("class", " class=\"", 1655, "\"", 1701, 1);
#nullable restore
#line 46 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\Admin\UserList.cshtml"
WriteAttributeValue("", 1663, user.EmailConfirmed?"":"bg-warning", 1663, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <td>");
#nullable restore
#line 47 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\Admin\UserList.cshtml"
                           Write(user.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 48 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\Admin\UserList.cshtml"
                           Write(user.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 49 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\Admin\UserList.cshtml"
                           Write(user.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 50 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\Admin\UserList.cshtml"
                           Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 51 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\Admin\UserList.cshtml"
                           Write(user.EmailConfirmed);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 2042, "\"", 2069, 2);
            WriteAttributeValue("", 2049, "/admin/user/", 2049, 12, true);
#nullable restore
#line 53 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\Admin\UserList.cshtml"
WriteAttributeValue("", 2061, user.Id, 2061, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-primary mr-2\">Edit</a>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27e5c65d45144e1fc40a9d6c8a0ad7e86eb4d1f510089", async() => {
                WriteLiteral("\r\n                                    <input type=\"hidden\" name=\"UserId\"");
                BeginWriteAttribute("value", " value=\"", 2286, "\"", 2302, 1);
#nullable restore
#line 55 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\Admin\UserList.cshtml"
WriteAttributeValue("", 2294, user.Id, 2294, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                    <button type=\"submit\" class=\"btn btn-sm btn-danger\">Delete</button>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 60 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\Admin\UserList.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\Admin\UserList.cshtml"
                     
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <tr>
                        <td colspan=""6"">
                            <div class=""alert alert-warning"">
                                <h4>No Users!</h4>
                            </div>
                        </td>
                    </tr>
");
#nullable restore
#line 71 "F:\github\Lesson\Week_14\MiniShopApp9\MiniShopApp\MiniShopApp.WebUI\Views\Admin\UserList.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
