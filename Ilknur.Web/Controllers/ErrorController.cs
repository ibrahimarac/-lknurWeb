using AutoMapper;
using Ilknur.Core.Domain.Common;
using Ilknur.Core.Domain.Dto;
using Ilknur.Core.Services;
using Ilknur.Utils.Extensions;
using Ilknur.Web.Models.VM;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilknur.Web.Controllers
{
    public class ErrorController : Controller
    {
        private readonly IMapper Mapper;
        private readonly IErrorService ErrorService;

        public ErrorController(IMapper mapper,IErrorService errorService)
        {
            Mapper = mapper;
            ErrorService = errorService;
        }

        [Route("Error/Http500")]
        public IActionResult Error() //500 numaralı status kodlarda yani C# kodlarının ürettiği exceptionlar için
        {
            IExceptionHandlerPathFeature exceptionHandlerPath = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            IHttpRequestFeature httpRequestFeature = HttpContext.Features.Get<IHttpRequestFeature>();

            var errorDto = new ErrorDto
            {
                CreateDate = DateTime.Now,
                QueryString = exceptionHandlerPath.Path.QueryStringFromUrl(),
                IsAjaxRequest= HttpContext.Request.IsAjaxRequest(),
                RequestType=Enum.Parse<RequestType>(httpRequestFeature.Method),
                StatusCode=500,
                Url=exceptionHandlerPath.Path,
                Username="admin",
                Exception=JsonConvert.SerializeObject(exceptionHandlerPath.Error)
            };

            //Hatayı veritabanına kaydet
            ErrorService.AddError(errorDto);

            var errorVM = Mapper.Map<ErrorDto, ErrorVM>(errorDto);
            errorVM.Message = "Kayıt esnasında bir hata oluştu. Hata kayıt altına alındı. Lütfen sistem yöneticinizle görüşün.";
            
            return View("_Error",errorVM);
        }
    }
}
