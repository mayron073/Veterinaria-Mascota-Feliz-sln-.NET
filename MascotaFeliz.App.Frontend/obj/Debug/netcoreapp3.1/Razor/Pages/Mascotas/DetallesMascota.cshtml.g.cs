#pragma checksum "C:\Mascotas\MascotaFeliz.App\MascotaFeliz.App.Frontend\Pages\Mascotas\DetallesMascota.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7fcd9c02f874363294c4e7eefcab192fb8ef4222"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MascotaFeliz.App.Frontend.Pages.Mascotas.Pages_Mascotas_DetallesMascota), @"mvc.1.0.razor-page", @"/Pages/Mascotas/DetallesMascota.cshtml")]
namespace MascotaFeliz.App.Frontend.Pages.Mascotas
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
#line 1 "C:\Mascotas\MascotaFeliz.App\MascotaFeliz.App.Frontend\Pages\_ViewImports.cshtml"
using MascotaFeliz.App.Frontend;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fcd9c02f874363294c4e7eefcab192fb8ef4222", @"/Pages/Mascotas/DetallesMascota.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5cf052204a3bb4119b871dc96742e016457a0b55", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Mascotas_DetallesMascota : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Informacion del la mascota</h1>\r\n\r\n<div class=\"box\">\r\n    <div>\r\n        Id: ");
#nullable restore
#line 9 "C:\Mascotas\MascotaFeliz.App\MascotaFeliz.App.Frontend\Pages\Mascotas\DetallesMascota.cshtml"
       Write(Model.mascota.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        Nombre: ");
#nullable restore
#line 12 "C:\Mascotas\MascotaFeliz.App\MascotaFeliz.App.Frontend\Pages\Mascotas\DetallesMascota.cshtml"
           Write(Model.mascota.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        Color: ");
#nullable restore
#line 15 "C:\Mascotas\MascotaFeliz.App\MascotaFeliz.App.Frontend\Pages\Mascotas\DetallesMascota.cshtml"
          Write(Model.mascota.Color);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        Raza: ");
#nullable restore
#line 18 "C:\Mascotas\MascotaFeliz.App\MascotaFeliz.App.Frontend\Pages\Mascotas\DetallesMascota.cshtml"
         Write(Model.mascota.Raza);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        Especie: ");
#nullable restore
#line 21 "C:\Mascotas\MascotaFeliz.App\MascotaFeliz.App.Frontend\Pages\Mascotas\DetallesMascota.cshtml"
            Write(Model.mascota.Especie);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        Dueño: ");
#nullable restore
#line 24 "C:\Mascotas\MascotaFeliz.App\MascotaFeliz.App.Frontend\Pages\Mascotas\DetallesMascota.cshtml"
          Write(Model.mascota.Dueno.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        Veterinario: ");
#nullable restore
#line 27 "C:\Mascotas\MascotaFeliz.App\MascotaFeliz.App.Frontend\Pages\Mascotas\DetallesMascota.cshtml"
                Write(Model.mascota.Veterinario.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<a href=\"./ListaMascotas\" class=\"btn-default\">Lista de mascotas</a>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MascotaFeliz.App.Frontend.Pages.DetallesMascotaModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MascotaFeliz.App.Frontend.Pages.DetallesMascotaModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MascotaFeliz.App.Frontend.Pages.DetallesMascotaModel>)PageContext?.ViewData;
        public MascotaFeliz.App.Frontend.Pages.DetallesMascotaModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
