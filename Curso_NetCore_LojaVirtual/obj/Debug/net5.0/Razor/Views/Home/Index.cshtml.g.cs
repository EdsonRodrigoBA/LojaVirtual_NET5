#pragma checksum "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e5145156030b593d33b1321944c2821bcc77c5cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\_ViewImports.cshtml"
using Curso_NetCore_LojaVirtual;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\_ViewImports.cshtml"
using Curso_NetCore_LojaVirtual.Bibliotecas.ProdutoAgregador;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\_ViewImports.cshtml"
using Curso_NetCore_LojaVirtual.Bibliotecas.Login;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\_ViewImports.cshtml"
using Curso_NetCore_LojaVirtual.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\_ViewImports.cshtml"
using Curso_NetCore_LojaVirtual.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\_ViewImports.cshtml"
using X.PagedList.Web.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5145156030b593d33b1321944c2821bcc77c5cb", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552e3558b8dc32577199954f9f688c4be1543c8f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NewsLettersEmail>
    {
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
        private global::AspNetCore.Views_Home_Index.__Generated__ProdutosListagemViewComponentTagHelper __ProdutosListagemViewComponentTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Inicio";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main role=""main"">

    <div id=""myCarousel"" class=""carousel slide"" data-ride=""carousel"">
        <ol class=""carousel-indicators"">
            <li data-target=""#myCarousel"" data-slide-to=""0"" class=""active""></li>
            <li data-target=""#myCarousel"" data-slide-to=""1""></li>
            <li data-target=""#myCarousel"" data-slide-to=""2""></li>
        </ol>
        <div class=""carousel-inner"">
            <div class=""carousel-item active"">
                <img class=""first-slide"" src=""data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==""
                     alt=""First slide"">
                <div class=""container"">
                    <div class=""carousel-caption text-left"">
                        <h1>Example headline.</h1>
                        <p>
                            Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta
                            gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut ");
            WriteLiteral(@"id elit.
                        </p>
                        <p><a class=""btn btn-lg btn-primary"" href=""#"" role=""button"">Sign up today</a></p>
                    </div>
                </div>
            </div>
            <div class=""carousel-item"">
                <img class=""second-slide"" src=""data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==""
                     alt=""Second slide"">
                <div class=""container"">
                    <div class=""carousel-caption"">
                        <h1>Another example headline.</h1>
                        <p>
                            Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta
                            gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.
                        </p>
                        <p><a class=""btn btn-lg btn-primary"" href=""#"" role=""button"">Learn more</a></p>
                    </div>
                </div>");
            WriteLiteral(@"
            </div>
            <div class=""carousel-item"">
                <img class=""third-slide"" src=""data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==""
                     alt=""Third slide"">
                <div class=""container"">
                    <div class=""carousel-caption text-right"">
                        <h1>One more for good measure.</h1>
                        <p>
                            Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta
                            gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.
                        </p>
                        <p><a class=""btn btn-lg btn-primary"" href=""#"" role=""button"">Browse gallery</a></p>
                    </div>
                </div>
            </div>
        </div>
        <a class=""carousel-control-prev"" href=""#myCarousel"" role=""button"" data-slide=""prev"">
            <span class=""carousel-control-prev-icon");
            WriteLiteral(@""" aria-hidden=""true""></span>
            <span class=""sr-only"">Previous</span>
        </a>
        <a class=""carousel-control-next"" href=""#myCarousel"" role=""button"" data-slide=""next"">
            <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
            <span class=""sr-only"">Next</span>
        </a>
    </div>

    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("vc:produtos-listagem", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e5145156030b593d33b1321944c2821bcc77c5cb8404", async() => {
            }
            );
            __ProdutosListagemViewComponentTagHelper = CreateTagHelper<global::AspNetCore.Views_Home_Index.__Generated__ProdutosListagemViewComponentTagHelper>();
            __tagHelperExecutionContext.Add(__ProdutosListagemViewComponentTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</main>\r\n\r\n\r\n");
#nullable restore
#line 72 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Home\Index.cshtml"
  
    /* Fazendo com que ao submter o form volte de onde parou*/

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 76 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Home\Index.cshtml"
 using (Html.BeginForm(
actionName: null,
controllerName: null,
routeValues: null,
method: FormMethod.Post,
antiforgery: true,
htmlAttributes: new { @action = Url.Action("index", "home") + "#formulario" }
))
{




#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"container\" id=\"formulario\">\r\n        <div class=\"row\">\r\n            <div class=\"col-sm-6 offset-sm-3\">\r\n");
#nullable restore
#line 91 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Home\Index.cshtml"
                 if (TempData["MSG_SUCESSO"] != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p class=\"alert alert-succes\" style=\"color:\"><b>");
#nullable restore
#line 93 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Home\Index.cshtml"
                                                               Write(TempData["MSG_SUCESSO"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n");
#nullable restore
#line 94 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n\r\n\r\n            <div class=\"col-sm-6 col-md-6\">\r\n");
            WriteLiteral(@"
                <div class=""form-group"">
                    <label for=""nome"">Informe o seu E-mail e Receba nossas novidades</label>
                    <div class=""input-group"">
                        <div class=""input-group-prepend"">
                            <span class=""input-group-text""><i class=""fa fa-envelope""></i></span>
                        </div>
");
            WriteLiteral("                        <input type=\"text\" class=\"form-control\" name=\"email\" id=\"email\" placeholder=\"Informe seu E-mail\" />\r\n                    </div>\r\n                    <span class=\"text-danger\">");
#nullable restore
#line 112 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Home\Index.cshtml"
                                         Write(Html.ValidationMessageFor(m => m.email));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                </div>

            </div>
            <div class=""col-sm-3 col-md-3"" style=""margin-top:6px; margin-left: -8px"">
                <br />
                <button class=""subscribe btn btn-primary btn-block""> Enviar </button>

            </div>

        </div>
    </div>
");
#nullable restore
#line 124 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NewsLettersEmail> Html { get; private set; }
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute("vc:produtos-listagem")]
        public class __Generated__ProdutosListagemViewComponentTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
        {
            private readonly global::Microsoft.AspNetCore.Mvc.IViewComponentHelper __helper = null;
            public __Generated__ProdutosListagemViewComponentTagHelper(global::Microsoft.AspNetCore.Mvc.IViewComponentHelper helper)
            {
                __helper = helper;
            }
            [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNotBoundAttribute, global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewContextAttribute]
            public global::Microsoft.AspNetCore.Mvc.Rendering.ViewContext ViewContext { get; set; }
            public override async global::System.Threading.Tasks.Task ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext __context, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput __output)
            {
                (__helper as global::Microsoft.AspNetCore.Mvc.ViewFeatures.IViewContextAware)?.Contextualize(ViewContext);
                var __helperContent = await __helper.InvokeAsync("ProdutosListagem", new {  });
                __output.TagName = null;
                __output.Content.SetHtmlContent(__helperContent);
            }
        }
    }
}
#pragma warning restore 1591
