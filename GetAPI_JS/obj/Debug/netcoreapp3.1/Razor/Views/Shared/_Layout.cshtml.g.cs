#pragma checksum "E:\FPTS\3_Tier\GetAPI_JS\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "383aabeb4cd7dc15ab5dd06ec8ecc452389a7f1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#line 1 "E:\FPTS\3_Tier\GetAPI_JS\Views\_ViewImports.cshtml"
using GetAPI_JS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\FPTS\3_Tier\GetAPI_JS\Views\_ViewImports.cshtml"
using GetAPI_JS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"383aabeb4cd7dc15ab5dd06ec8ecc452389a7f1e", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"feebfde757f9144300a6f2a73b1972a366bc5bd1", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("search-model-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"zxx\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "383aabeb4cd7dc15ab5dd06ec8ecc452389a7f1e3821", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""description"" content=""HVAC Template"">
    <meta name=""keywords"" content=""HVAC, unica, creative, html"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <meta http-equiv=""X-UA-Compatible"" content=""ie=edge"">
    <title>HVAC | Template</title>

    <!-- Google Font -->
    <link href=""https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700;900&display=swap"" rel=""stylesheet"">

    <!-- Css Styles -->
    <link rel=""stylesheet"" href=""wwwroot/css/bootstrap.min.css"" type=""text/css"">
    <link rel=""stylesheet"" href=""wwwroot/css/font-awesome.min.css"" type=""text/css"">
    <link rel=""stylesheet"" href=""wwwroot/css/elegant-icons.css"" type=""text/css"">
    <link rel=""stylesheet"" href=""wwwroot/css/nice-select.css"" type=""text/css"">
    <link rel=""stylesheet"" href=""wwwroot/css/magnific-popup.css"" type=""text/css"">
    <link rel=""stylesheet"" href=""wwwroot/css/jquery-ui.min.css"" type=""text/css"">
    <link rel=""stylesheet"" href=""wwwr");
                WriteLiteral(@"oot/css/owl.carousel.min.css"" type=""text/css"">
    <link rel=""stylesheet"" href=""wwwroot/css/slicknav.min.css"" type=""text/css"">
    <link rel=""stylesheet"" href=""wwwroot/css/style.css"" type=""text/css"">
    <style type=""text/css"">
        .car_item th:first-child {
            float: left;
        }

        .car_item th:last-child {
            float: right;
        }

        .car_item td:first-child {
            float: left;
        }

        .car_item td:last-child {
            float: right;
        }

        .header__nav__widget__btn {
            display: inline-block;
            position: relative;
        }

        .dropdown-content {
            display: none;
            position: absolute;
            background-color: #f1f1f1;
            min-width: 30em;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 1;
            right: -130px;
            top: 50px;
        }

            .dropdown-content h1 {
                color: black");
                WriteLiteral(";\r\n                padding: 12px 16px;\r\n                text-decoration: none;\r\n                display: block;\r\n            }\r\n\r\n        .header__nav__widget__btn:hover .dropdown-content {\r\n            display: block;\r\n        }\r\n    </style>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "383aabeb4cd7dc15ab5dd06ec8ecc452389a7f1e7250", async() => {
                WriteLiteral(@"
    <!-- Page Preloder -->
    <div id=""preloder"">
        <div class=""loader""></div>
    </div>

    <!-- Offcanvas Menu Begin -->
    <div class=""offcanvas-menu-overlay""></div>
    <div class=""offcanvas-menu-wrapper"">
        <div class=""offcanvas__widget"">
            <a href=""#""><i class=""fa fa-cart-plus""></i></a>
            <a href=""#"" class=""search-switch""><i class=""fa fa-search""></i></a>
            <a href=""#"" class=""primary-btn"">Add Car</a>
        </div>
        <div class=""offcanvas__logo"">
            <a href=""./index.html""><img src=""img/logo.png""");
                BeginWriteAttribute("alt", " alt=\"", 2936, "\"", 2942, 0);
                EndWriteAttribute();
                WriteLiteral(@"></a>
        </div>
        <div id=""mobile-menu-wrap""></div>
        <ul class=""offcanvas__widget__add"">
            <li><i class=""fa fa-clock-o""></i> Week day: 08:00 am to 18:00 pm</li>
            <li><i class=""fa fa-envelope-o""></i> Info.colorlib@gmail.com</li>
        </ul>
        <div class=""offcanvas__phone__num"">
            <i class=""fa fa-phone""></i>
            <span>(+12) 345 678 910</span>
        </div>
        <div class=""offcanvas__social"">
            <a href=""#""><i class=""fa fa-facebook""></i></a>
            <a href=""#""><i class=""fa fa-twitter""></i></a>
            <a href=""#""><i class=""fa fa-google""></i></a>
            <a href=""#""><i class=""fa fa-instagram""></i></a>
        </div>
    </div>
    <!-- Offcanvas Menu End -->
    <!-- Header Section Begin -->
   ");
#nullable restore
#line 106 "E:\FPTS\3_Tier\GetAPI_JS\Views\Shared\_Layout.cshtml"
Write(await Html.PartialAsync("~/Views/Shared/Header.cshtml"));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n    <!-- Header Section End -->\r\n    ");
#nullable restore
#line 108 "E:\FPTS\3_Tier\GetAPI_JS\Views\Shared\_Layout.cshtml"
Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <!-- Footer Section Begin -->\r\n  ");
#nullable restore
#line 110 "E:\FPTS\3_Tier\GetAPI_JS\Views\Shared\_Layout.cshtml"
Write(await Html.PartialAsync("~/Views/Shared/Footer.cshtml"));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n    <!-- Footer Section End -->\r\n    <!-- Search Begin -->\r\n    <div class=\"search-model\">\r\n        <div class=\"h-100 d-flex align-items-center justify-content-center\">\r\n            <div class=\"search-close-switch\">+</div>\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "383aabeb4cd7dc15ab5dd06ec8ecc452389a7f1e10116", async() => {
                    WriteLiteral("\r\n                <input type=\"text\" id=\"search-input\" placeholder=\"Search here.....\">\r\n            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
        </div>
    </div>
    <!-- Search End -->
    <!-- Js Plugins -->
    <script src=""wwwroot/js/jquery-3.3.1.min.js""></script>
    <script src=""wwwroot/js/bootstrap.min.js""></script>
    <script src=""wwwroot/js/jquery.nice-select.min.js""></script>
    <script src=""wwwroot/js/jquery-ui.min.js""></script>
    <script src=""wwwroot/js/jquery.magnific-popup.min.js""></script>
    <script src=""wwwroot/js/mixitup.min.js""></script>
    <script src=""wwwroot/js/jquery.slicknav.js""></script>
    <script src=""wwwroot/js/owl.carousel.min.js""></script>
    <script src=""wwwroot/js/main.js""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
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