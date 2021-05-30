using AutoMapper;
using Ilknur.Core.Domain.Common;
using Ilknur.Core.Domain.Dto;
using Ilknur.Core.Loggers;
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
        private readonly IExceptionLogger ErrorLogger;

        public ErrorController(IMapper mapper,IExceptionLogger errorLogger)
        {
            Mapper = mapper;
            ErrorLogger = errorLogger;
        }

        [Route("Error/Http500")]
        public IActionResult Error() //500 numaralı status kodlarda yani C# kodlarının ürettiği exceptionlar için
        {
            IExceptionHandlerPathFeature exceptionHandlerPath = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            IHttpRequestFeature httpRequestFeature = HttpContext.Features.Get<IHttpRequestFeature>();

            var jsonSerializerSettings = new JsonSerializerSettings();
            //Json serileştirme ayarlarımız
            jsonSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsonSerializerSettings.Formatting = Formatting.Indented;

            var errorDto = new ErrorDto
            {
                CreateDate = DateTime.Now,
                QueryString = exceptionHandlerPath.Path.QueryStringFromUrl(),
                IsAjaxRequest = HttpContext.Request.IsAjaxRequest(),
                RequestType = Enum.Parse<RequestType>(httpRequestFeature.Method),
                StatusCode = 500,
                Url = exceptionHandlerPath.Path,
                Username = "admin",
                Exception = JsonConvert.SerializeObject(exceptionHandlerPath.Error, jsonSerializerSettings)
            };

            //Hatayı veritabanına kaydet
            ErrorLogger.LogException(errorDto);

            var errorVM = Mapper.Map<ErrorDto, ErrorVM>(errorDto);
            errorVM.Message = exceptionHandlerPath.Error.Message;
            
            return View("_Error",errorVM);
        }
    }
}
