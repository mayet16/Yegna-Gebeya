#pragma checksum "D:\edit\YegnaGebiyaSystem1\Views\Administrator\ViewTracsaction.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7df3e9fa88d9afd185d0e1c78cfbc04e614e3112"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrator_ViewTracsaction), @"mvc.1.0.view", @"/Views/Administrator/ViewTracsaction.cshtml")]
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
#line 1 "D:\edit\YegnaGebiyaSystem1\Views\_ViewImports.cshtml"
using YegnaGebiyaSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\edit\YegnaGebiyaSystem1\Views\_ViewImports.cshtml"
using YegnaGebiyaSystem.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\edit\YegnaGebiyaSystem1\Views\_ViewImports.cshtml"
using YegnaGebiyaSystem.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\edit\YegnaGebiyaSystem1\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7df3e9fa88d9afd185d0e1c78cfbc04e614e3112", @"/Views/Administrator/ViewTracsaction.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"082c7e06cd637e0c411ce52ebddc4d53f83b4a64", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrator_ViewTracsaction : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<orderListViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\edit\YegnaGebiyaSystem1\Views\Administrator\ViewTracsaction.cshtml"
  
        Layout = "_LayoutOfAdmin";
    ViewData["Title"] = "View tracsaction";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <h1>");
#nullable restore
#line 7 "D:\edit\YegnaGebiyaSystem1\Views\Administrator\ViewTracsaction.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
    <table class=""table table-hover border"">
        <thead style=""background-color:aqua"">
            <tr>
                <th scope=""col"">Order Id</th>
                <th scope=""col"">Seller Name</th>
                <th scope=""col"">Buyer Name</th>
                <th scope=""col"">Order Date</th>
                <th scope=""col"">Price</th>
                <th scope=""col"">Quantity</th>
                <th scope=""col"">State</th>
            </tr>
        </thead>
        <tbody>
        <tbody>
");
#nullable restore
#line 22 "D:\edit\YegnaGebiyaSystem1\Views\Administrator\ViewTracsaction.cshtml"
             foreach (var order in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <th scope=\"row\">");
#nullable restore
#line 25 "D:\edit\YegnaGebiyaSystem1\Views\Administrator\ViewTracsaction.cshtml"
                               Write(order.order_List.OrderDetailId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <td>");
#nullable restore
#line 26 "D:\edit\YegnaGebiyaSystem1\Views\Administrator\ViewTracsaction.cshtml"
                   Write(order.seller.Users.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 27 "D:\edit\YegnaGebiyaSystem1\Views\Administrator\ViewTracsaction.cshtml"
                   Write(order.buyer.Users.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <th>");
#nullable restore
#line 28 "D:\edit\YegnaGebiyaSystem1\Views\Administrator\ViewTracsaction.cshtml"
                   Write(order.order_List.Order.Orderplaced);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <td>");
#nullable restore
#line 29 "D:\edit\YegnaGebiyaSystem1\Views\Administrator\ViewTracsaction.cshtml"
                   Write(order.product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 30 "D:\edit\YegnaGebiyaSystem1\Views\Administrator\ViewTracsaction.cshtml"
                   Write(order.product.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "D:\edit\YegnaGebiyaSystem1\Views\Administrator\ViewTracsaction.cshtml"
                   Write(order.product.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 33 "D:\edit\YegnaGebiyaSystem1\Views\Administrator\ViewTracsaction.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<orderListViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591