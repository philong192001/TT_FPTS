#pragma checksum "E:\FPTS\3_Tier\GetAPI_JS\Views\Shared\Header.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "207cd19a25db2bc032046a5de240d4173451caa1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Header), @"mvc.1.0.view", @"/Views/Shared/Header.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"207cd19a25db2bc032046a5de240d4173451caa1", @"/Views/Shared/Header.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"feebfde757f9144300a6f2a73b1972a366bc5bd1", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Header : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<header class=""header"">
    <div class=""header__top"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-7"">
                    <ul class=""header__top__widget"">
                        <li><i class=""fa fa-clock-o""></i> Week day: 08:00 am to 18:00 pm</li>
                        <li><i class=""fa fa-envelope-o""></i> Info.colorlib@gmail.com</li>
                    </ul>
                </div>
                <div class=""col-lg-5"">
                    <div class=""header__top__right"">
                        <div class=""header__top__phone"">
                            <i class=""fa fa-phone""></i>
                            <span>(+12) 345 678 910</span>
                        </div>
                        <div class=""header__top__social"">
                            <a href=""#""><i class=""fa fa-facebook""></i></a>
                            <a href=""#""><i class=""fa fa-twitter""></i></a>
                            <a href=""#""><i class=""fa fa-google");
            WriteLiteral(@"""></i></a>
                            <a href=""#""><i class=""fa fa-instagram""></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-2"">
                <div class=""header__logo"">
                    <a href=""./index.html""><img src=""img/logo.png""");
            BeginWriteAttribute("alt", " alt=\"", 1447, "\"", 1453, 0);
            EndWriteAttribute();
            WriteLiteral(@"></a>
                </div>
            </div>
            <div class=""col-lg-10"">
                <div class=""header__nav"">
                    <nav class=""header__menu"">
                        <ul>
                            <li class=""active""><a href=""./index.html"">Home</a></li>
                            <li><a href=""./car.html"">Cars</a></li>
                            <li><a href=""./blog.html"">Blog</a></li>
                            <li>
                                <a href=""#"">Pages</a>
                                <ul class=""dropdown"">
                                    <li><a href=""./about.html"">About Us</a></li>
                                    <li><a href=""./car-details.html"">Car Details</a></li>
                                    <li><a href=""./blog-details.html"">Blog Details</a></li>
                                </ul>
                            </li>
                            <li><a href=""./about.html"">About</a></li>
                            <li><a hre");
            WriteLiteral(@"f=""./contact.html"">Contact</a></li>
                        </ul>
                    </nav>
                    <div class=""header__nav__widget"">
                        <div class=""header__nav__widget__btn"">
                            <a class=""dropbtn"" href=""#""><i class=""fa fa-cart-plus""></i></a>
                            <div class=""dropdown-content"">
                                <table class=""table table-active table-bordered"">
                                    <thead>
                                        <tr class=""car_item"">
                                            <th class=""text-center"">Name Car</th>
                                            <th class=""text-center"">Image Car</th>
                                            <th class=""text-center"">Price</th>
                                            <th class=""text-center"">Quantity</th>
                                        </tr>
                                    </thead>
                                    <tbody");
            WriteLiteral(@">
                                        <tr class=""car_item"">
                                            <td class=""text-center"">1</td>
                                            <td class=""text-center"">2</td>
                                            <td class=""text-center"">3</td>
                                            <td class=""text-center"">4</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <a href=""#"" class=""search-switch""><i class=""fa fa-search""></i></a>
                    </div>
                    <a href=""#"" class=""primary-btn"">Add Car</a>



                </div>
            </div>
        </div>
        <div class=""canvas__open"">
            <span class=""fa fa-bars""></span>
        </div>
    </div>
</header>");
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