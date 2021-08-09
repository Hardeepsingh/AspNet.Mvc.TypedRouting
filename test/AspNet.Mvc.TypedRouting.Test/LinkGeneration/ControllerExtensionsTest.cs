﻿namespace AspNet.Mvc.TypedRouting.Test.LinkGeneration
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Xunit;
    using System;

    [Collection("TypedRoutingTests")]
    public class ControllerExtensionsTest
    {
        [Fact]
        public void CreatedAtAction_WithParams()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.CreatedAtActionWithParams(5) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ControllerName);
            Assert.Equal("CreatedAtActionWithParams", result.ActionName);
            Assert.Equal(5, result.RouteValues["value"]);
            Assert.Null(result.Value);
        }

        [Fact]
        public void CreatedAtAction_OtherController_WithParams()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.CreatedAtActionOtherControllerWithParams(5) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Other", result.ControllerName);
            Assert.Equal("ActionWithParam", result.ActionName);
            Assert.Equal(5, result.RouteValues["value"]);
            Assert.Null(result.Value);
        }

        [Fact]
        public void CreatedAtAction_OtherController_WithParamsAndRouteValues()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.CreatedAtActionOtherControllerWithParamsAndRouteValues(5) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Other", result.ControllerName);
            Assert.Equal("ActionWithParam", result.ActionName);
            Assert.Equal(5, result.RouteValues["value"]);
            Assert.Equal(1, result.RouteValues["id"]);
            Assert.Equal("test", result.Value);
        }

        [Fact]
        public void CreatedAtAction_SameController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.CreatedAtActionSameController() as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ControllerName);
            Assert.Equal("CreatedAtActionSameController", result.ActionName);
            Assert.Empty(result.RouteValues);
            Assert.Equal("test", result.Value);
        }

        [Fact]
        public void CreatedAtActionWithRouteValues_SameController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.CreatedAtActionSameControllerRouteValues() as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ControllerName);
            Assert.Equal("CreatedAtActionSameControllerRouteValues", result.ActionName);
            Assert.Single( result.RouteValues);
            Assert.Equal(1, result.RouteValues["id"]);
            Assert.Equal("test", result.Value);
        }

        [Fact]
        public void CreatedAtAction_OtherController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.CreatedAtActionOtherController() as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Other", result.ControllerName);
            Assert.Equal("Action", result.ActionName);
            Assert.Empty(result.RouteValues);
            Assert.Equal("test", result.Value);
        }

        [Fact]
        public void CreatedAtActionWithRouteValues_OtherController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.CreatedAtActionOtherControllerRouteValues() as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Other", result.ControllerName);
            Assert.Equal("Action", result.ActionName);
            Assert.Single( result.RouteValues);
            Assert.Equal(1, result.RouteValues["id"]);
            Assert.Equal("test", result.Value);
        }

        //Custom
        [Fact]
        public void CreatedToGenerateRouteUsingCustomSiteAction_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.CreatedToGenerateRouteUsingCustomSiteAction_ResolvesCorrectly() as string;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void CreatedAtRoute_SameController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.CreatedAtRouteSameController() as CreatedAtRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("route", result.RouteName);
            Assert.Equal(2, result.RouteValues.Count);
            Assert.Equal("MyTest", result.RouteValues["controller"]);
            Assert.Equal("CreatedAtRouteSameController", result.RouteValues["action"]);
            Assert.Equal("test", result.Value);
        }

        [Fact]
        public void CreatedAtRouteWithRouteValues_SameController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.CreatedAtRouteSameControllerRouteValues() as CreatedAtRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("route", result.RouteName);
            Assert.Equal(3, result.RouteValues.Count);
            Assert.Equal("MyTest", result.RouteValues["controller"]);
            Assert.Equal("CreatedAtRouteSameControllerRouteValues", result.RouteValues["action"]);
            Assert.Equal(1, result.RouteValues["id"]);
            Assert.Equal("test", result.Value);
        }

        [Fact]
        public void CreatedAtRoute_OtherController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.CreatedAtRouteOtherController() as CreatedAtRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("route", result.RouteName);
            Assert.Equal(2, result.RouteValues.Count);
            Assert.Equal("Other", result.RouteValues["controller"]);
            Assert.Equal("Action", result.RouteValues["action"]);
            Assert.Equal("test", result.Value);
        }

        [Fact]
        public void CreatedAtRouteWithRouteValues_OtherController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.CreatedAtRouteOtherControllerRouteValues() as CreatedAtRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("route", result.RouteName);
            Assert.Equal(3, result.RouteValues.Count);
            Assert.Equal("Other", result.RouteValues["controller"]);
            Assert.Equal("Action", result.RouteValues["action"]);
            Assert.Equal(1, result.RouteValues["id"]);
            Assert.Equal("test", result.Value);
        }

        [Fact]
        public void RedirectToAction_SameController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.RedirectToActionSameController() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.RouteValues);
            Assert.Null(result.ControllerName);
            Assert.Equal("CreatedAtRouteSameController", result.ActionName);
            Assert.False(result.Permanent);
        }

        [Fact]
        public void RedirectToActionWithRouteValues_SameController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.RedirectToActionSameControllerRouteValues() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Single( result.RouteValues);
            Assert.Null(result.ControllerName);
            Assert.Equal("CreatedAtRouteSameControllerRouteValues", result.ActionName);
            Assert.Equal(1, result.RouteValues["id"]);
            Assert.False( result.Permanent);
        }

        [Fact]
        public void RedirectToAction_OtherController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.RedirectToActionOtherController() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.RouteValues);
            Assert.Equal("Other", result.ControllerName);
            Assert.Equal("Action", result.ActionName);
            Assert.False( result.Permanent);
        }

        [Fact]
        public void RedirectToActionWithRouteValues_OtherController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.RedirectToActionOtherControllerRouteValues() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Single( result.RouteValues );
            Assert.Equal("Other", result.ControllerName);
            Assert.Equal("Action", result.ActionName);
            Assert.Equal(1, result.RouteValues["id"]);
            Assert.False( result.Permanent);
        }

        [Fact]
        public void RedirectToActionPermanent_SameController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.RedirectToActionPermanentSameController() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.RouteValues);
            Assert.Null(result.ControllerName);
            Assert.Equal("CreatedAtRouteSameController", result.ActionName);
            Assert.True(result.Permanent);
        }

        [Fact]
        public void RedirectToActionPermanentWithRouteValues_SameController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.RedirectToActionPermanentSameControllerRouteValues() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Single( result.RouteValues );
            Assert.Null(result.ControllerName);
            Assert.Equal("CreatedAtRouteSameControllerRouteValues", result.ActionName);
            Assert.Equal(1, result.RouteValues["id"]);
            Assert.True(result.Permanent);
        }

        [Fact]
        public void RedirectToActionPermanent_OtherController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.RedirectToActionPermanentOtherController() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.RouteValues);
            Assert.Equal("Other", result.ControllerName);
            Assert.Equal("Action", result.ActionName);
            Assert.True(result.Permanent);
        }

        [Fact]
        public void RedirectToActionPermanentWithRouteValues_OtherController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.RedirectToActionPermanentOtherControllerRouteValues() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Single( result.RouteValues );
            Assert.Equal("Other", result.ControllerName);
            Assert.Equal("Action", result.ActionName);
            Assert.Equal(1, result.RouteValues["id"]);
            Assert.True(result.Permanent);
        }

        [Fact]
        public void RedirectToRoute_SameController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.RedirectToRouteSameController() as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("route", result.RouteName);
            Assert.Equal(2, result.RouteValues.Count);
            Assert.Equal("MyTest", result.RouteValues["controller"]);
            Assert.Equal("CreatedAtRouteSameController", result.RouteValues["action"]);
            Assert.False( result.Permanent);
        }

        [Fact]
        public void RedirectToRouteWithRouteValues_SameController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.RedirectToRouteSameControllerRouteValues() as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("route", result.RouteName);
            Assert.Equal(3, result.RouteValues.Count);
            Assert.Equal("MyTest", result.RouteValues["controller"]);
            Assert.Equal("CreatedAtRouteSameControllerRouteValues", result.RouteValues["action"]);
            Assert.Equal(1, result.RouteValues["id"]);
            Assert.False( result.Permanent);
        }

        [Fact]
        public void RedirectToRoute_OtherController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.RedirectToRouteOtherController() as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("route", result.RouteName);
            Assert.Equal(2, result.RouteValues.Count);
            Assert.Equal("Other", result.RouteValues["controller"]);
            Assert.Equal("Action", result.RouteValues["action"]);
            Assert.False( result.Permanent);
        }

        [Fact]
        public void RedirectToRouteWithRouteValues_OtherController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.RedirectToRouteOtherControllerRouteValues() as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("route", result.RouteName);
            Assert.Equal(3, result.RouteValues.Count);
            Assert.Equal("Other", result.RouteValues["controller"]);
            Assert.Equal("Action", result.RouteValues["action"]);
            Assert.Equal(1, result.RouteValues["id"]);
            Assert.False( result.Permanent);
        }

        [Fact]
        public void RedirectToRoutePermanent_SameController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.RedirectToRoutePermanentSameController() as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("route", result.RouteName);
            Assert.Equal(2, result.RouteValues.Count);
            Assert.Equal("MyTest", result.RouteValues["controller"]);
            Assert.Equal("CreatedAtRouteSameController", result.RouteValues["action"]);
            Assert.True(result.Permanent);
        }

        [Fact]
        public void RedirectToRoutePermanentWithRouteValues_SameController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.RedirectToRoutePermanentSameControllerRouteValues() as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("route", result.RouteName);
            Assert.Equal(3, result.RouteValues.Count);
            Assert.Equal("MyTest", result.RouteValues["controller"]);
            Assert.Equal("CreatedAtRouteSameControllerRouteValues", result.RouteValues["action"]);
            Assert.Equal(1, result.RouteValues["id"]);
            Assert.True(result.Permanent);
        }

        [Fact]
        public void RedirectToRoutePermanent_OtherController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.RedirectToRoutePermanentOtherController() as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("route", result.RouteName);
            Assert.Equal(2, result.RouteValues.Count);
            Assert.Equal("Other", result.RouteValues["controller"]);
            Assert.Equal("Action", result.RouteValues["action"]);
            Assert.True(result.Permanent);
        }

        [Fact]
        public void RedirectToRoutePermanentWithRouteValues_OtherController_ResolvesCorrectly()
        {
            // Arrange
            var controller = new MyTestController();

            // Act
            var result = controller.RedirectToRoutePermanentOtherControllerRouteValues() as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("route", result.RouteName);
            Assert.Equal(3, result.RouteValues.Count);
            Assert.Equal("Other", result.RouteValues["controller"]);
            Assert.Equal("Action", result.RouteValues["action"]);
            Assert.Equal(1, result.RouteValues["id"]);
            Assert.True(result.Permanent);
        }
    }

    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    RequestServices = TestServices.Global
                }
            };
        }
    }

    public class MyTestController : BaseController
    {
        private IUrlHelper _url;
        public MyTestController()
        {
            _url = new UrlHelper(ControllerContext);
		}

        public IActionResult CreatedAtActionWithParams(int value)
        {
            return this.CreatedAtAction(c => c.CreatedAtActionWithParams(value), null);
        }

        public IActionResult CreatedAtActionOtherControllerWithParams(int value)
        {
            return this.CreatedAtAction<OtherController>(c => c.ActionWithParam(value), null);
        }

        public IActionResult CreatedAtActionOtherControllerWithParamsAndRouteValues(int value)
        {
            return this.CreatedAtAction<OtherController>(c => c.ActionWithParam(value), new { id = 1 }, "test");
        }

        public IActionResult CreatedAtActionSameController()
        {
            return this.CreatedAtAction(c => c.CreatedAtActionSameController(), "test");
        }

        public IActionResult CreatedAtActionSameControllerRouteValues()
        {
            return this.CreatedAtAction(c => c.CreatedAtActionSameControllerRouteValues(), new { id = 1 }, "test");
        }

        public IActionResult CreatedAtActionOtherController()
        {
            return this.CreatedAtAction<OtherController>(c => c.Action(), "test");
        }

        public IActionResult CreatedAtActionOtherControllerRouteValues()
        {
            return this.CreatedAtAction<OtherController>(c => c.Action(), new { id = 1 }, "test");
        }

        public string CreatedToGenerateRouteUsingCustomSiteAction_ResolvesCorrectly()
        {
            var route= _url.SiteAction<MyTestController>(x => x.AddDataDate(1, true, new DateTime(), "/Sites/Test/SuperProjectView/AdminShow/2?"), new TestExtensionMethods.Site());
            return route;
        }

        public void AddDataDate(int id, bool v, DateTime date, string thisUrl)
        {
            throw new NotImplementedException();
        }

        public IActionResult CreatedAtRouteSameController()
        {
            return this.CreatedAtRoute("route", c => c.CreatedAtRouteSameController(), "test");
        }

        public IActionResult CreatedAtRouteSameControllerRouteValues()
        {
            return this.CreatedAtRoute("route", c => c.CreatedAtRouteSameControllerRouteValues(), new { id = 1 }, "test");
        }

        public IActionResult CreatedAtRouteOtherController()
        {
            return this.CreatedAtRoute<OtherController>("route", c => c.Action(), "test");
        }

        public IActionResult CreatedAtRouteOtherControllerRouteValues()
        {
            return this.CreatedAtRoute<OtherController>("route", c => c.Action(), new { id = 1 }, "test");
        }

        public IActionResult RedirectToActionSameController()
        {
            return this.RedirectToAction(c => c.CreatedAtRouteSameController());
        }

        public IActionResult RedirectToActionSameControllerRouteValues()
        {
            return this.RedirectToAction(c => c.CreatedAtRouteSameControllerRouteValues(), new { id = 1 });
        }

        public IActionResult RedirectToActionOtherController()
        {
            return this.RedirectToAction<OtherController>(c => c.Action());
        }

        public IActionResult RedirectToActionOtherControllerRouteValues()
        {
            return this.RedirectToAction<OtherController>(c => c.Action(), new { id = 1 });
        }

        public IActionResult RedirectToActionPermanentSameController()
        {
            return this.RedirectToActionPermanent(c => c.CreatedAtRouteSameController());
        }

        public IActionResult RedirectToActionPermanentSameControllerRouteValues()
        {
            return this.RedirectToActionPermanent(c => c.CreatedAtRouteSameControllerRouteValues(), new { id = 1 });
        }

        public IActionResult RedirectToActionPermanentOtherController()
        {
            return this.RedirectToActionPermanent<OtherController>(c => c.Action());
        }

        public IActionResult RedirectToActionPermanentOtherControllerRouteValues()
        {
            return this.RedirectToActionPermanent<OtherController>(c => c.Action(), new { id = 1 });
        }

        public IActionResult RedirectToRouteSameController()
        {
            return this.RedirectToRoute("route", c => c.CreatedAtRouteSameController());
        }

        public IActionResult RedirectToRouteSameControllerRouteValues()
        {
            return this.RedirectToRoute("route", c => c.CreatedAtRouteSameControllerRouteValues(), new { id = 1 });
        }

        public IActionResult RedirectToRouteOtherController()
        {
            return this.RedirectToRoute<OtherController>("route", c => c.Action());
        }

        public IActionResult RedirectToRouteOtherControllerRouteValues()
        {
            return this.RedirectToRoute<OtherController>("route", c => c.Action(), new { id = 1 });
        }

        public IActionResult RedirectToRoutePermanentSameController()
        {
            return this.RedirectToRoutePermanent("route", c => c.CreatedAtRouteSameController());
        }

        public IActionResult RedirectToRoutePermanentSameControllerRouteValues()
        {
            return this.RedirectToRoutePermanent("route", c => c.CreatedAtRouteSameControllerRouteValues(), new { id = 1 });
        }

        public IActionResult RedirectToRoutePermanentOtherController()
        {
            return this.RedirectToRoutePermanent<OtherController>("route", c => c.Action());
        }

        public IActionResult RedirectToRoutePermanentOtherControllerRouteValues()
        {
            return this.RedirectToRoutePermanent<OtherController>("route", c => c.Action(), new { id = 1 });
        }
    }

    public class OtherController : BaseController
    {
        public IActionResult Action()
        {
            return null;
        }

        public IActionResult ActionWithParam(int value)
        {
            return this.CreatedAtAction(c => c.ActionWithParam(value), value);
        }
    }
}
