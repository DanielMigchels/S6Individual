using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.ViewModel;

namespace UserService
{
    public class HttpResponse
    {
        public static string Success(object obj)
        {
            ResponseViewModel responseVM = new ResponseViewModel();
            responseVM.Success = true;
            responseVM.Data = obj;

            return JsonConvert.SerializeObject(responseVM);
        }
    }
}
