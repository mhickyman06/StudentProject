#pragma checksum "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f95330eccd8955b5bf1521db39952a414524dbb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_School_GetAllSpellers), @"mvc.1.0.view", @"/Views/School/GetAllSpellers.cshtml")]
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
#nullable restore
#line 4 "C:\Users\HI\Documents\StudentProject\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HI\Documents\StudentProject\Views\_ViewImports.cshtml"
using StudentProject.Models.SeedRoles;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HI\Documents\StudentProject\Views\_ViewImports.cshtml"
using System.IO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f95330eccd8955b5bf1521db39952a414524dbb", @"/Views/School/GetAllSpellers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac78aafc0166b21636c3e85a20b00350ed09e13e", @"/Views/_ViewImports.cshtml")]
    public class Views_School_GetAllSpellers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ListSpellersViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditSpeller", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "School", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
  
    ViewData["Title"] = "Spellers List";

    Layout = "_SchoolPortalLayout";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 10 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
  
    if (ViewBag.Message != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n            alert(\"You Have Succesfully Registered A Speller\")\r\n        </script>\r\n");
#nullable restore
#line 16 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
    }
 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <style>
        table th {
            font-size: smaller;
            font-variant-caps: small-caps;
            font-family: inherit;
        }

        table tr td {
            font-size: medium;
            font-variant: all-small-caps;
        }

        .modal-title {
            font-size: unset;
            font-family: cursive;
        }

        .modal-bodycontent {
            font-size: medium;
            font-family: cursive;
            text-align: center;
        }
    </style>

<div class=""container-fluid"">
    <div>
        <h4> Spellers</h4>
    </div>
    <div class=""mt-5"">
        <div>
            <div class=""card"">
                <div class=""card-header"">
                    <h3 class=""card-title"">Spellers List</h3>
                </div>
                <!-- /.card-header -->
                <div class=""card-body"">
                    <table id=""example1"" class=""table table-bordered table-striped"">
                        <thead>
          ");
            WriteLiteral(@"                  <tr>
                                <th>FullName</th>
                                <th>Gender</th>
                                <th>Age</th>
                                <th>Date Of Birth</th>
                                <th>Email</th>
                                <th>Created By</th>
                                <th>Date Created</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 69 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
                             foreach (var spellers in Model.Spellers)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr");
            BeginWriteAttribute("id", " id=\"", 1977, "\"", 2006, 2);
            WriteAttributeValue("", 1982, "row_", 1982, 4, true);
#nullable restore
#line 71 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
WriteAttributeValue("", 1986, spellers.SpellersId, 1986, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <td>");
#nullable restore
#line 72 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
                                   Write(spellers.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 73 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
                                   Write(spellers.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 74 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
                                   Write(spellers.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 75 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
                                   Write(spellers.DateOfBirth);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 76 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
                                   Write(spellers.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 77 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
                                   Write(spellers.CreatedBy);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 78 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
                                   Write(spellers.DateCreated);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f95330eccd8955b5bf1521db39952a414524dbb10073", async() => {
                WriteLiteral("<i class=\"fa fa-edit\" aria-hidden=\"true\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 80 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
                                                                                                                             WriteLiteral(spellers.SpellersId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        <a class=\"btn btn-danger\" href=\"#\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2788, "\"", 2833, 3);
            WriteAttributeValue("", 2798, "ConfirmDelete(", 2798, 14, true);
#nullable restore
#line 81 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
WriteAttributeValue("", 2812, spellers.SpellersId, 2812, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2832, ")", 2832, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            <i class=\" fas fa-trash-alt\"></i>\r\n                                        </a>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 86 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                    <div class=""modal fade"" id=""myModal"">
                        <div class=""modal-dialog"">
                            <div class=""modal-content"">
                                <div class=""modal-header"">
                                    <h3 class=""modal-title"">Delete Spellers</h3>
                                    <a href=""#"" style=""margin-left:auto"" class=""close"" data-dismiss=""modal"">&times;</a>
                                </div>
                                <div class=""modal-body"">

                                    <h4 class=""modal-bodycontent"">Are you sure you want to remove this Speller?</h4>
                                </div>
                                <div class=""modal-footer"">
                                    <a href=""#"" class=""btn btn-default"" data-dismiss=""modal"">Cancel</a>
                                    <a href=""#"" class=""btn btn-success"" onclick=""DeleteSpeller()"">Confirm<");
            WriteLiteral(@"/a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <input type=""hidden"" id=""hiddenSpellerId"" />
                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
        </div>
        <!-- /.col -->
    </div>

    <div style=""margin-top:20px"">
        <div class=""card"">
            <div class=""card-header"">
                <h3 class=""card-title"">Spellers And their Videos</h3>
            </div>
            <div class=""card-body"">
                <div class=""row"">
");
#nullable restore
#line 123 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
                      
                        foreach (var item in Model.SpellersVideos)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-sm-5 ml-3\"");
            BeginWriteAttribute("id", " id=\"", 4909, "\"", 4934, 2);
            WriteAttributeValue("", 4914, "col_", 4914, 4, true);
#nullable restore
#line 126 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
WriteAttributeValue("", 4918, item.SpellersId, 4918, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <h6>");
#nullable restore
#line 127 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
                               Write(item.SpellersName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                <div class=\"mt-3\">\r\n");
#nullable restore
#line 129 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
                                      
                                        var videopath = System.IO.Path.Combine("~/content/Videos/", item.VideoPath);
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div style=\"margin-bottom:5px;\">\r\n                                        <video width=\"320\" height=\"240\" controls loop=\"loop\">\r\n                                            <source");
            BeginWriteAttribute("src", " src=\"", 5464, "\"", 5493, 1);
#nullable restore
#line 134 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
WriteAttributeValue("", 5470, Url.Content(videopath), 5470, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"video/mp4\" />\r\n                                        </video>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 139 "C:\Users\HI\Documents\StudentProject\Views\School\GetAllSpellers.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        var ConfirmDelete = function (SpellerId) {
            $(""#hiddenSpellerId"").val(SpellerId);
            $(""#myModal"").modal('show');
        }

        var DeleteSpeller = function () {
            var spelId = $(""#hiddenSpellerId"").val();
            $.ajax({
                type: ""POST"",
                url: ""DeleteSpeller"",
                data: {
                    id: spelId
                },
                success: function (result) {
                    $(""#myModal"").modal(""hide"");
                    $(""#row_"" + spelId).remove();
                    $(""#col_"" + spelId).remove();
                }
            })
        }





    </script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ListSpellersViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
