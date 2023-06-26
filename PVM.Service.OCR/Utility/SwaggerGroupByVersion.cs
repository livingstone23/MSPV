using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace PVM.Service.OCR.Utility
{
    public class SwaggerGroupByVersion : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var namespaceControler = controller.ControllerType.Namespace;                       //Controllers.V1
            var versionApi = namespaceControler.Split('.').Last().ToLower();            //V1
            controller.ApiExplorer.GroupName = versionApi;
        }
    }
}
