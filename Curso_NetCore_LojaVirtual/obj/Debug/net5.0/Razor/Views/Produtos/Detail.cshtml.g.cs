#pragma checksum "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e38cef73a54a989fb9301fc1130dd1757b850c19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Produtos_Detail), @"mvc.1.0.view", @"/Views/Produtos/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e38cef73a54a989fb9301fc1130dd1757b850c19", @"/Views/Produtos/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"552e3558b8dc32577199954f9f688c4be1543c8f", @"/Views/_ViewImports.cshtml")]
    public class Views_Produtos_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Produtos>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AdicionarItem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Carrinho", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn  btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
 if (Model != null)
{



#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""container-fluid"" id=""code_prod_detail"" style=""margin-top: 50px"">
        <div class=""card"">
            <div class=""row no-gutters"">
                <aside class=""col-sm-5 border-right"">
                    <article class=""gallery-wrap"">
                        <div class=""img-big-wrap"">
");
#nullable restore
#line 13 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
                             if (@Model.Imagens != null)
                            {
                                if (Model.Imagens.Count > 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div> <a");
            BeginWriteAttribute("href", " href=\"", 588, "\"", 639, 1);
#nullable restore
#line 17 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
WriteAttributeValue("", 595, Model.Imagens.ElementAtOrDefault(0).caminho, 595, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-fancybox=\"\"><img");
            BeginWriteAttribute("src", " src=\"", 662, "\"", 712, 1);
#nullable restore
#line 17 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
WriteAttributeValue("", 668, Model.Imagens.ElementAtOrDefault(0).caminho, 668, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></a></div>\r\n");
#nullable restore
#line 18 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"

                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div> <a href=\"/img/produtoimagem.png\" data-fancybox=\"\"><img src=\"/img/produtoimagem.png\"></a></div>\r\n");
#nullable restore
#line 23 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"

                                }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div> <!-- slider-product.// -->\r\n                        <div class=\"img-small-wrap\">\r\n");
#nullable restore
#line 28 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
                             if (@Model.Imagens != null)
                            {
                                if (Model.Imagens.Count > 0)
                                {
                                    foreach (var item in Model.Imagens)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"item-gallery\"> <img");
            BeginWriteAttribute("src", " src=\"", 1524, "\"", 1543, 1);
#nullable restore
#line 34 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
WriteAttributeValue("", 1530, item.caminho, 1530, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></div>\r\n");
#nullable restore
#line 35 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
                                    }
                                }

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </article>\r\n                </aside>\r\n                <aside class=\"col-sm-7\">\r\n                    <article class=\"p-5\">\r\n                        <h3 class=\"title mb-3\">");
#nullable restore
#line 44 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
                                          Write(Model.nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n                        <div class=\"mb-3\">\r\n                            <var class=\"price h3 text-warning\">\r\n                                <span class=\"currency\"></span><span class=\"num\">");
#nullable restore
#line 48 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
                                                                           Write(Model.valor.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </var>
                            <span>/UN</span>
                        </div>
                        <dl>
                            <dt>Descri????o</dt>
                            <dd>
                                <p>
                                    ");
#nullable restore
#line 56 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
                               Write(Model.descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </p>
                            </dd>
                        </dl>
                        <dl class=""row"">
                            <dt class=""col-sm-3"">Peso (KG)</dt>
                            <dd class=""col-sm-9"">");
#nullable restore
#line 62 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
                                            Write(Model.peso);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n                            <dt class=\"col-sm-3\">Largura</dt>\r\n                            <dd class=\"col-sm-9\">");
#nullable restore
#line 65 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
                                            Write(Model.largura);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </dd>\r\n\r\n                            <dt class=\"col-sm-3\">Altura</dt>\r\n                            <dd class=\"col-sm-9\">");
#nullable restore
#line 68 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
                                            Write(Model.altura);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n                            <dt class=\"col-sm-3\">Comprimento</dt>\r\n                            <dd class=\"col-sm-9\">");
#nullable restore
#line 71 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
                                            Write(Model.comprimento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n                            <dt class=\"col-sm-3\">Quantidade Estoque</dt>\r\n                            <dd class=\"col-sm-9\">");
#nullable restore
#line 74 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
                                            Write(Model.quantidade);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n                        </dl>\r\n\r\n                        <hr>\r\n\r\n                        <hr>\r\n                        <a href=\"#\" class=\"btn  btn-primary\"> Comprar Agora </a>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e38cef73a54a989fb9301fc1130dd1757b850c1913780", async() => {
                WriteLiteral("\r\n                            <i class=\"fas fa-shopping-cart\"></i> Adicionar ao Carrinho\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 81 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
                                                                                  WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </article>\r\n                </aside>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 89 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"container\" style=\"margin-top: 50px\">\r\n\r\n        <div class=\"alert alert-info\"><b>Ops !!</b> No momento nenhum produto foi encontrado.</div>\r\n    </div>\r\n");
#nullable restore
#line 96 "C:\Users\edson\source\repos\Curso_NetCore_LojaVirtual\Curso_NetCore_LojaVirtual\Views\Produtos\Detail.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Produtos> Html { get; private set; }
    }
}
#pragma warning restore 1591
