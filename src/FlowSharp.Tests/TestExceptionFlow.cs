using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlowSharp.Tests
{
    [TestClass]
    public class TestExceptionFlow
    {
        [TestMethod]
        public void ShouldStopOnEmptyException()
        {
            "".ExceptionFlow()
              .SideFlow(DemoFunctionsWithExceptions.GetUser)
              .IfStopped(x => Assert.AreEqual(1, x.Count()))
              .IfStopped(x => Assert.AreEqual("Value is Empty", x.Single().Message))
              .IfFlowing(x => Assert.Fail("Should be stopped"));
        }

        [TestMethod]
        public void ShouldStopOnNotAnEmailException()
        {
            "not empty".ExceptionFlow()
              .SideFlow(DemoFunctionsWithExceptions.GetUser)
              .IfStopped(x => Assert.AreEqual(1, x.Count()))
              .IfStopped(x => Assert.AreEqual("String is not an email", x.Single().Message))
              .IfFlowing(x => Assert.Fail("Should be stopped"));
        }

        [TestMethod]
        public void ShouldNotStopException()
        {
            "test@test.com"
              .ExceptionFlow()
              .SideFlow(DemoFunctionsWithExceptions.GetUser)
              .IfStopped(x => Assert.Fail("Should not be stopped"))
              .IfFlowing(x => Assert.IsNotNull(x));
        }
    }
}
