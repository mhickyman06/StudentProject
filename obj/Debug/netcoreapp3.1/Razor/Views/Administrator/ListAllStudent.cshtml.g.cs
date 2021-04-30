#pragma checksum "C:\Users\HI\Documents\StudentProject\Views\Administrator\ListAllStudent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b37f701777f4853923bc04879e76e0a4ff75bed6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrator_ListAllStudent), @"mvc.1.0.view", @"/Views/Administrator/ListAllStudent.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b37f701777f4853923bc04879e76e0a4ff75bed6", @"/Views/Administrator/ListAllStudent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea836fd9cbc6b806ced4a1ff4ed4c89477d5b6b4", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrator_ListAllStudent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<ApplicationUser>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/js/bootstrap.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<style>
    main {
        padding: 1em;
    }

    input[placeholder] {
        font-family: -webkit-pictograph;
        font-size:12px;
    }
    .table-wrapper {
        overflow: auto;
        max-width: 100%;
        /*background: linear-gradient(to right, white 30%,rgba(255,255,255,0)),
            linear-gradient(farthest-side at 100% 50%,rgb)*/
        background-repeat: no-repeat;
        background-color: white;
        background-size: 40px 100%, 40px 100%,14px 100%,14px 100%;
        background-position: 0 0,100%, 0 0, 100%;
        background-attachment: local,local,scroll,scroll;
    }

    tr {
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
    .numeric {
        text-align: right;
    }
</style>
<div ");
            WriteLiteral(@"class=""mt-4"">
    <h6 class=""register-form-header""> List All Student</h6>
    <main>
        <div class=""row mt-4"">
            <div class=""col-sm-3"">
                <h6 style=""font-size: 13px; font-family: system-ui"">search for a student</h6>
            </div>
            <div class=""col-sm-9"">
                <div class=""row"">
                    <div class=""col-sm-4"">
                        <input class=""form-control"" id=""FirstName"" placeholder=""FirstName"" />
                    </div>
                    <div class=""col-sm-4"">
                        <input class=""form-control"" id=""LastName"" placeholder=""LastName"" />
                    </div>
                    <div class=""col-sm-3"">
                        <button type=""submit"" class=""btn btn-sm"" style=""background-color:#f1f1f1;border-color:wheat"" id=""btn-Submit"">Find</button>
                        <button id=""refresh-Btn"" class=""btn btn-sm""  style=""background-color:#f1f1f1;border-color:wheat"">Refresh</button>
                   ");
            WriteLiteral(@" </div>
                </div>
                <div class=""mt-3"">
                    <h6 id=""no-Record"" class=""text-danger""  style=""display:none; font-size:12px""></h6>
                </div>
            </div>
        </div>
        <div class=""mt-3 table-wrapper"" tabindex=""0"">
            <div id=""normal-Data"" style=""display:block"">
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
                            <th>Address</th>
                            <th>Email</th>
                            <th>UserName</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 84 "C:\Users\HI\Documents\StudentProject\Views\Administrator\ListAllStudent.cshtml"
                         foreach (var items in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 87 "C:\Users\HI\Documents\StudentProject\Views\Administrator\ListAllStudent.cshtml"
                                               Write(items.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 88 "C:\Users\HI\Documents\StudentProject\Views\Administrator\ListAllStudent.cshtml"
                                               Write(items.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 89 "C:\Users\HI\Documents\StudentProject\Views\Administrator\ListAllStudent.cshtml"
                                               Write(items.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 90 "C:\Users\HI\Documents\StudentProject\Views\Administrator\ListAllStudent.cshtml"
                                               Write(items.DateOfBirth);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 91 "C:\Users\HI\Documents\StudentProject\Views\Administrator\ListAllStudent.cshtml"
                                               Write(items.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 92 "C:\Users\HI\Documents\StudentProject\Views\Administrator\ListAllStudent.cshtml"
                                               Write(items.Genders);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 93 "C:\Users\HI\Documents\StudentProject\Views\Administrator\ListAllStudent.cshtml"
                                               Write(items.Class);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 94 "C:\Users\HI\Documents\StudentProject\Views\Administrator\ListAllStudent.cshtml"
                                               Write(items.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 95 "C:\Users\HI\Documents\StudentProject\Views\Administrator\ListAllStudent.cshtml"
                                               Write(items.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"numeric\">");
#nullable restore
#line 96 "C:\Users\HI\Documents\StudentProject\Views\Administrator\ListAllStudent.cshtml"
                                               Write(items.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 98 "C:\Users\HI\Documents\StudentProject\Views\Administrator\ListAllStudent.cshtml"
                         }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
            <div id=""filter-Data"" style=""display:none"">
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
                            <th>Address</th>
                            <th>Email</th>
                            <th>UserName</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class=""numeric"" id=""filter-data_Id""></td>
                            <td class=""numeric"" id=""filter-data_FirstName""></td>
                            <td class=""numeric"" id=""filter-data_L");
            WriteLiteral(@"astName""></td>
                            <td class=""numeric"" id=""filter-data_DateOfBirth""></td>
                            <td class=""numeric"" id=""filter-data_Age""></td>
                            <td class=""numeric"" id=""filter-data_Genders""></td>
                            <td class=""numeric"" id=""filter-data_Class""></td>
                            <td class=""numeric"" id=""filter-data_Address""></td>
                            <td class=""numeric"" id=""filter-data_Email""></td>
                            <td class=""numeric"" id=""filter-data_UserName""></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </main>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b37f701777f4853923bc04879e76e0a4ff75bed613195", async() => {
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b37f701777f4853923bc04879e76e0a4ff75bed614318", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script>
    $(function () {
      

        $('#btn-Submit').click(function () {
            $(""#no-Record"").text(""C"");
            const FirstName = $('#FirstName').val();
            const LastName = $('#LastName').val();
            const values = {
                ""FirstName"": FirstName,
                ""LastName"": LastName
            }
            if (values.FirstName == """" || values.LastName == """") {
                $(""#no-Record"").css(""display"", ""block"");
                $(""#no-Record"").text(""Check your inputs and try again "");
            }
            console.log(values);
            $.ajax({
                type: ""Post"",
                url: ""/Administrator/FilterStudent"",
                dataType: ""json"",
                'contentType': 'application/json; charset=utf-8',
                data: JSON.stringify(values),
                success: function (data, status) {
                    var user = data;
                    console.log(user);
                    console.l");
            WriteLiteral(@"og(data);
                    if ( user != null) {
                        $(""#normal-Data"").css(""display"", ""none"");
                        $(""#filter-Data"").css(""display"", ""block"");
                        $(""#filter-data_Id"").text(user.id);
                        $(""#filter-data_FirstName"").text(user.firstName);
                        $(""#filter-data_FirstName"").text(user.lastName);
                        $(""#filter-data_DateOfBirth"").text(user.dateOfBirth);
                        $(""#filter-data_Age"").text(user.age);
                        $(""#filter-data_Genders"").text(user.genders);
                        $(""#filter-data_Class"").text(user.class);
                        $(""#filter-data_Address"").text(user.address);
                        $(""#filter-data_Email"").text(user.email);
                        $(""#filter-data_UserName"").text(user.userName);
                    }
                  
                    else
                    {
                        $(""#normal-Data"").c");
            WriteLiteral(@"ss(""display"", ""block"");
                    }
                },
                error: function (error) {
                    if (error) {
                        console.log(error);
                        $(""#no-Record"").css(""display"", ""block"");
                        $(""#no-Record"").text(error.responseText);
                    }
                    if (values.FirstName == """" || values.LastName == """" && error.responseText != """") {
                        $(""#no-Record"").css(""display"", ""block"");
                        //$(""#no-Record"").text(""Check your inputs and try again "");
                        $(""#no-Record"").html(""One of the inputs was ommited, please check and try again <br/> "" + error.responseText);
                    }
                }
            });
        })
        $(""#refresh-Btn"").click(() => {
            window.location.reload();
        })
    });
</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<ApplicationUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
