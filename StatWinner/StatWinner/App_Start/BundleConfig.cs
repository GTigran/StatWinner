using System.Web;
using System.Web.Optimization;

namespace StatWinner
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").
                Include("~/Scripts/lib/jquery/dist/jquery.js").
                Include("~/Scripts/lib/jqueryui/jquery-ui.js").
                Include("~/Scripts/lib/livequery/jquery.livequery.js").
                Include("~/Scripts/lib/attrchange/attrchange.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/angular").
                Include("~/Scripts/lib/angular/angular.js").
                Include("~/Scripts/lib/angular-animate/angular-animate.js").
                Include("~/Scripts/lib/angular-ui/build/angular-ui.js").
                Include("~/Scripts/lib/angular-ui-router/release/angular-ui-router.js")
                );


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/lib/bootstrap/dist/js/bootstrap.js",
                "~/Scripts/lib/bootstrap-notify/js/bootstrap-notify.js",
                "~/Scripts/lib/bootbox/bootbox.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryplugins").Include(
                "~/Scripts/lib/jquery-flickr/jquery.flickr.js",
                "~/Scripts/lib/jquery.fancybox/fancybox/jquery.easing-1.3.pack.js",
                "~/Scripts/lib/jquery.fancybox/fancybox/jquery.easing-1.3.pack.js",
                "~/Scripts/lib/camera/scripts/camera.js",
                "~/Scripts/lib/superfish/dist/js/superfish.js",
                "~/Scripts/lib/superfish/dist/js/supersubs.js",
                "~/Scripts/lib/superfish/dist/js/hoverIntent.js",
                "~/Scripts/lib/other/sftouchscreen.js",
                "~/Scripts/lib/jquery.mobilemenu/jquery.mobilemenu.js",
                "~/Scripts/lib/jquery.mobilemenu/jquery.mobilemenu.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                "~/Scripts/lib/kendo/js/kendo.all.js",
                "~/Scripts/lib/kendo/js/kendo.angular.js"
                ));


            bundles.Add(new StyleBundle("~/Content/CommonCss").Include(
                "~/Content/Common/font-awesome.css",
                "~/Content/Common/default.css",
                "~/Content/Common/template.css",
                "~/Content/Common/touch.gallery.css",
                "~/Content/Common/responsive.css",
                "~/Content/Common/komento.css",
                "~/Content/Common/ui-font-line.css",
                "~/Content/Common/ui-font-solid.css",
                "~/Content/Common/Site.css",
                "~/Scripts/lib/bootstrap-notify/css/bootstrap-notify.css"
                ));

            bundles.Add(new StyleBundle("~/Content/Bootstrap").Include("~/Content/Common/bootstrap.css",
                "~/Scripts/lib/bootstrap-notify/cssbootstrap-notify.css"
                ));

            bundles.Add(new StyleBundle("~/Content/Bootstrap").Include("~/Content/Common/bootstrap.css",
                "~/Scripts/lib/bootstrap-notify/cssbootstrap-notify.css"
                ));

            bundles.Add(new StyleBundle("~/Content/JQueryPlugins").Include(
                "~/Scripts/lib/jquery.fancybox/fancybox/jquery.fancybox-1.3.4.css",
                "~/Scripts/lib/camera/css/camera.css",
                "~/Scripts/lib/superfish/dist/css/superfish.css",
                "~/Scripts/lib/superfish/dist/css/superfish-navbar.css",
                "~/Scripts/lib/superfish/dist/css/superfish-vertical.css"
                ));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                "~/Scripts/lib/kendo/styles/web/kendo.common.css",
                "~/Scripts/lib/kendo/styles/web/kendo.metro.css"
                ));

            #region "Administration Bundles"

            bundles.Add(new StyleBundle("~/Content/Administration").Include("~/Content/Pages/administration.page.css"));

            bundles.Add(new ScriptBundle("~/bundles/Administration").Include(
                "~/Scripts/Common/appConfig.js",
                "~/Scripts/App/Administration/Configuration/AdminConfig.js",
                "~/Scripts/Common/Directives/transferValidation.js",
                "~/Scripts/Common/Directives/configureContentHeight.js",
                "~/Scripts/Common/Directives/validationMessage.js",
                "~/Scripts/Common/Directives/gridCheckboxes.js",
                "~/Scripts/Common/Directives/leftPaneShowHide.js",
                "~/Scripts/Common/Directives/gridInPlaceModeManager.js",
                "~/Scripts/Common/Constants/Urls.js",
                "~/Scripts/Common/Interfaces/IGridScope.js",
                "~/Scripts/Common/Services/GridServiceBaseService.js",
                "~/Scripts/Common/Services/ValidatorService.js",
                "~/Scripts/Common/Services/LookupDataService.js",
                "~/Scripts/Common/Models/ModelBase.js",
                "~/Scripts/Common/Models/LookupModels.js",
                "~/Scripts/Common/ControllerExtensions/kendoGridManagementExtensions.js",
                "~/Scripts/Common/Responses/CommonResponses.js",
                "~/Scripts/App/Administration/Models/ConfigurationSettings.GridModel.js",
                "~/Scripts/App/Administration/Models/NotificationEventCategoryModel.js",
                "~/Scripts/App/Administration/Models/NotificationEventModel.js",
                "~/Scripts/App/Administration/Services/ConfigurationSettings.GridService.js",
                "~/Scripts/App/Administration/Services/NotificationEvents.GridService.js",
                "~/Scripts/App/Administration/Services/NotificationEventCategory.GridService.js",
                "~/Scripts/App/Administration/Controllers/AdministrationMainController.js",
                "~/Scripts/App/Administration/Controllers/ConfigurationSettingsController.js",
                "~/Scripts/App/Administration/Controllers/UserManagementController.js",
                "~/Scripts/App/Administration/Controllers/ButtonsController.js",
                "~/Scripts/App/Administration/Controllers/NotificationEventCategoryController.js",
                "~/Scripts/App/Administration/Controllers/NotificationEventsController.js",
                "~/Scripts/App/Administration/Directives/manageEventsInPlaceEdit.js"
                ));

            #endregion

            #region Registration

            bundles.Add(new StyleBundle("~/Content/Registration").Include("~/Content/Pages/register.page.css"));

            bundles.Add(new ScriptBundle("~/bundles/Registration").Include(
                "~/Scripts/Common/appConfig.js",
                "~/Scripts/Common/Directives/transferValidation.js",
                "~/Scripts/Common/Directives/validationMessage.js",
                "~/Scripts/Common/Directives/defaultButton.js",
                "~/Scripts/Common/Constants/Urls.js",
                "~/Scripts/Common/Models/ModelBase.js",
                "~/Scripts/Common/Models/LookupModels.js",
                "~/Scripts/Common/Services/ValidatorService.js",
                "~/Scripts/Common/Services/LookupDataService.js",
                "~/Scripts/Common/Responses/CommonResponses.js",
                "~/Scripts/Common/AngularValidators/ngRemoteValidate.js",
                "~/Scripts/Common/AngularValidators/compareValidator.js",
                "~/Scripts/App/Registration/Controllers/RegistrationController.js",
                "~/Scripts/App/Registration/Models/RegistrationModel.js",
                "~/Scripts/App/Registration/Services/RegistrationService.js"
                ));


            #endregion


            #region Login

            bundles.Add(new StyleBundle("~/Content/Login").Include("~/Content/Pages/signIn.page.css"));

            bundles.Add(new ScriptBundle("~/bundles/Login").Include(
                "~/Scripts/Common/appConfig.js",
                "~/Scripts/Common/Directives/transferValidation.js",
                "~/Scripts/Common/Directives/validationMessage.js",
                "~/Scripts/Common/Directives/defaultButton.js",
                "~/Scripts/Common/Constants/Urls.js",
                "~/Scripts/Common/Models/ModelBase.js",
                "~/Scripts/Common/Services/ValidatorService.js",
                "~/Scripts/Common/Services/MessageDisplayService.js",
                "~/Scripts/Common/Responses/CommonResponses.js",
                "~/Scripts/App/SignIn/Controllers/SignInController.js",
                "~/Scripts/App/SignIn/Models/SignInModel.js",
                "~/Scripts/App/SignIn/Services/SignInService.js"
                ));


            #endregion



        }
    }
}
