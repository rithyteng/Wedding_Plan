#pragma checksum "/Users/rithyteng/Documents/dotNET_stack/weddingplan/Views/Home/WeddingDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "039ce9f91067b1b8b66aafd35f605557ff843f41"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_WeddingDetail), @"mvc.1.0.view", @"/Views/Home/WeddingDetail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/WeddingDetail.cshtml", typeof(AspNetCore.Views_Home_WeddingDetail))]
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
#line 1 "/Users/rithyteng/Documents/dotNET_stack/weddingplan/Views/_ViewImports.cshtml"
using weddingplan;

#line default
#line hidden
#line 2 "/Users/rithyteng/Documents/dotNET_stack/weddingplan/Views/_ViewImports.cshtml"
using weddingplan.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"039ce9f91067b1b8b66aafd35f605557ff843f41", @"/Views/Home/WeddingDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ac8ff3fefd9466ce2bce77fa8cd755aabef8afb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_WeddingDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wedding>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(15, 33, true);
            WriteLiteral("<!DOCTYPE html>\n<html lang=\"en\">\n");
            EndContext();
            BeginContext(48, 202, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "039ce9f91067b1b8b66aafd35f605557ff843f413345", async() => {
                BeginContext(54, 189, true);
                WriteLiteral("\n    <meta charset=\"UTF-8\">\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n    <meta http-equiv=\"X-UA-Compatible\" content=\"ie=edge\">\n    <title>Document</title>\n");
                EndContext();
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
            EndContext();
            BeginContext(250, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(251, 314, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "039ce9f91067b1b8b66aafd35f605557ff843f414705", async() => {
                BeginContext(257, 10, true);
                WriteLiteral("\n    <h1> ");
                EndContext();
                BeginContext(268, 8, false);
#line 11 "/Users/rithyteng/Documents/dotNET_stack/weddingplan/Views/Home/WeddingDetail.cshtml"
    Write(Model.W1);

#line default
#line hidden
                EndContext();
                BeginContext(276, 5, true);
                WriteLiteral(" and ");
                EndContext();
                BeginContext(282, 8, false);
#line 11 "/Users/rithyteng/Documents/dotNET_stack/weddingplan/Views/Home/WeddingDetail.cshtml"
                  Write(Model.W2);

#line default
#line hidden
                EndContext();
                BeginContext(290, 58, true);
                WriteLiteral(" \'s Wedding</h1>\n    <a href=\"/logout\"> Log Out</a>\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 348, "\"", 377, 2);
                WriteAttributeValue("", 355, "/Dashboard/", 355, 11, true);
#line 13 "/Users/rithyteng/Documents/dotNET_stack/weddingplan/Views/Home/WeddingDetail.cshtml"
WriteAttributeValue("", 366, ViewBag.Id, 366, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(378, 43, true);
                WriteLiteral(">Dashboard</a>\n    <h3> Guests: </h3>\n    \n");
                EndContext();
#line 16 "/Users/rithyteng/Documents/dotNET_stack/weddingplan/Views/Home/WeddingDetail.cshtml"
         for(int i = 0; i < @Model.Guests.Count; i ++){

#line default
#line hidden
                BeginContext(477, 16, true);
                WriteLiteral("            <p> ");
                EndContext();
                BeginContext(494, 22, false);
#line 17 "/Users/rithyteng/Documents/dotNET_stack/weddingplan/Views/Home/WeddingDetail.cshtml"
           Write(Model.Guests[i].Guests);

#line default
#line hidden
                EndContext();
                BeginContext(516, 6, true);
                WriteLiteral(" </p>\n");
                EndContext();
#line 18 "/Users/rithyteng/Documents/dotNET_stack/weddingplan/Views/Home/WeddingDetail.cshtml"
        }

#line default
#line hidden
                BeginContext(532, 26, true);
                WriteLiteral("        \n    \n\n    \n    \n\n");
                EndContext();
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
            EndContext();
            BeginContext(565, 8, true);
            WriteLiteral("\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wedding> Html { get; private set; }
    }
}
#pragma warning restore 1591
