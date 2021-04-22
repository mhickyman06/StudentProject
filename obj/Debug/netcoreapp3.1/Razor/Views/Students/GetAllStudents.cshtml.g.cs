#pragma checksum "C:\Users\HI\Documents\StudentProject\Views\Students\GetAllStudents.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ec1031c549cf8a087ddaf778c5f042c09ab6fbc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Students_GetAllStudents), @"mvc.1.0.view", @"/Views/Students/GetAllStudents.cshtml")]
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
#line 1 "C:\Users\HI\Documents\StudentProject\Views\_ViewImports.cshtml"
using StudentProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HI\Documents\StudentProject\Views\_ViewImports.cshtml"
using StudentProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HI\Documents\StudentProject\Views\_ViewImports.cshtml"
using StudentProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ec1031c549cf8a087ddaf778c5f042c09ab6fbc", @"/Views/Students/GetAllStudents.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea836fd9cbc6b806ced4a1ff4ed4c89477d5b6b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Students_GetAllStudents : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Student>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<style>
    main{
        padding: 1em;
    }

    .table-wrapper{
        overflow:auto;
        max-width:100%;
        /*background: linear-gradient(to right, white 30%,rgba(255,255,255,0)),
            linear-gradient(farthest-side at 100% 50%,rgb)*/
        background-repeat:no-repeat;
        background-color:white;
        background-size:40px 100%, 40px 100%,14px 100%,14px 100%;
        background-position:0 0,100%, 0 0, 100%;
        background-attachment:local,local,scroll,scroll;
    } 
    tr{
        border-bottom: 1px solid;
    }
    th, td {
        text-align: left;
        padding: 0.5em 1em;
        font-stretch: semi-condensed;
        font-variant-caps: all-petite-caps;
        font-variant-east-asian: jis78;
        font: small-caption;
        font-family: -webkit-pictograph
    }
    .numeric{
        text-align: right;
    }
</style>
<div class=""mt-4"">
        <h6 class=""register-form-header""> List All Student</h6>
        <main>
            <div c");
            WriteLiteral(@"lass=""mt-3 table-wrapper"" tabindex=""0"">
                <table>
                    <thead>
                        <tr>
                            <th>StudentId</th>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Date of Birth</th>
                            <th>Age</th>
                            <th>Gender</th>
                            <th>Class</th>
                            <th>AddressLine1</th>
                            <th>AddressLine2</th>
                            <th>City</th>
                            <th>State</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 56 "C:\Users\HI\Documents\StudentProject\Views\Students\GetAllStudents.cshtml"
                         foreach (var items in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 59 "C:\Users\HI\Documents\StudentProject\Views\Students\GetAllStudents.cshtml"
                                               Write(items.StudentId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 60 "C:\Users\HI\Documents\StudentProject\Views\Students\GetAllStudents.cshtml"
                                               Write(items.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 61 "C:\Users\HI\Documents\StudentProject\Views\Students\GetAllStudents.cshtml"
                                               Write(items.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 62 "C:\Users\HI\Documents\StudentProject\Views\Students\GetAllStudents.cshtml"
                                               Write(items.DateOfBirth);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 63 "C:\Users\HI\Documents\StudentProject\Views\Students\GetAllStudents.cshtml"
                                               Write(items.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 64 "C:\Users\HI\Documents\StudentProject\Views\Students\GetAllStudents.cshtml"
                                               Write(items.Genders);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 65 "C:\Users\HI\Documents\StudentProject\Views\Students\GetAllStudents.cshtml"
                                               Write(items.Class);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 66 "C:\Users\HI\Documents\StudentProject\Views\Students\GetAllStudents.cshtml"
                                               Write(items.Address.AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 67 "C:\Users\HI\Documents\StudentProject\Views\Students\GetAllStudents.cshtml"
                                               Write(items.Address.AddressLine2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 68 "C:\Users\HI\Documents\StudentProject\Views\Students\GetAllStudents.cshtml"
                                               Write(items.Address.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 69 "C:\Users\HI\Documents\StudentProject\Views\Students\GetAllStudents.cshtml"
                                               Write(items.Address.State);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 71 "C:\Users\HI\Documents\StudentProject\Views\Students\GetAllStudents.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </main>\r\n    </div>");
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