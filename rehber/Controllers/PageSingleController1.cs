using Anka.Yg.Frc.Framework.ErrorMessages.Client;
using Anka.Yg.Frc.Framework.Serialization.Abstractions;
using Anka.Yg.Frc.Framework.State.Manager;
using Anka.Yg.Frc.Framework.State.Manager.Models.OperationState;
using Anka.Yg.Frc.Ui.Components.Ui.Helpers;
using Anka.Yg.Frc.Ui.Rendering.Base.Controllers;
using Anka.Yg.Frc.Ui.Rendering.Base.Integrations;
using Anka.Yg.Frc.Ui.Rendering.TagHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace rehber.Controllers
{
    public class PageSingleController1 : BaseAnkaScreenController
    {
        private readonly string Sayfa_1_ViewName = "Sayfa-1"; // Not: MVC yapısında yer alan, Views folderındaki sayfa adına karşılık gelmektedir.
        public PageSingleController1(IAnkaOperationStateManager operationStateManager,
            IAnkaSessionHelper sessionHelper,
            IJsonSerializer jsonSerializer,
            IDraftClient draftClient,
            IErrorMessagesClient errorMessagesClient,
            ILogger<BaseAnkaScreenController> logger,
            IRestCallUtil restCallUtil) : base(operationStateManager, sessionHelper, jsonSerializer, draftClient, errorMessagesClient, logger, restCallUtil)
        {
        }

        protected override void InitializeAnkaOperationState(AnkaOperationState operationState)
        {
            operationState.Layout = AnkaScreenLayout.SingleScreen;
            operationState.ActiveViewName = Sayfa_1_ViewName;

            operationState.Screens.Add(new AnkaScreen()
            {
                //Not: eklenecek sayfa ile ilgili bilgiler girilir.
                Label = "Sayfa1",
                ViewName = Sayfa_1_ViewName,
                ViewModel = new PageViewModel()
            });
        }

        public override async Task<IActionResult> Index(Guid operationId)
        {
            await LoadAnkaOperationState(operationId);

            var model = new PageViewModel();
            await _operationStateManager.SaveScreenViewModel(operationId, Sayfa_1_ViewName, model);
            await _operationStateManager.SetActiveScreen(operationId, Sayfa_1_ViewName);

            return await ViewCurrentScreen(operationId);
        }
    }
}

