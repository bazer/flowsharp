using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlowSharp.Tests
{
    [TestClass]
    public class TestBasics
    {
        [TestMethod]
        public void ShouldStopOnFirstValue()
        {
            var email = "";

            email.Flow()
               .StopOnValue(() => DemoFunctions.ValidateEmpty(email), "Value is empty")
               .StopOnValue(() => DemoFunctions.ValidateEmail(email), "String is not email")
               .IfStopped(x => Assert.AreEqual("Value is empty", x))
               .IfFlowing(x => Assert.Fail("Should be stopped"));
        }

        [TestMethod]
        public void ShouldStopOnSecondValue()
        {
            var email = "not empty";

            email.Flow()
               .StopOnValue(() => DemoFunctions.ValidateEmpty(email), "Value is empty")
               .StopOnValue(() => DemoFunctions.ValidateEmail(email), "String is not email")
               .IfStopped(x => Assert.AreEqual("String is not email", x))
               .IfFlowing(x => Assert.Fail("Should be stopped"));
        }

        [TestMethod]
        public void ShouldNotStop()
        {
            var email = "test@test.com";

            email.Flow()
               .StopOnValue(() => DemoFunctions.ValidateEmpty(email), "Value is empty")
               .StopOnValue(() => DemoFunctions.ValidateEmail(email), "String is not email")
               .IfStopped(x => Assert.Fail("Should not be stopped"))
               .IfFlowing(x => Assert.AreEqual("", x));
        }

        [TestMethod]
        public void Basics()
        {
            var name = "";
            var email = "";

            //SharpTrack.Wrap<string, string>((x) => string.IsNullOrWhiteSpace(x) ? "Name is empty" : "").ContinueIfEmpty(name);

            //DemoFunctions.ValidateEmpty(name)
            //    .FailOnValue(string.Empty)
            //    .FailOnValue(value => DemoFunctions.ValidateEmail(value), string.Empty);

            //SharpTrack.ToTrack<string>()
            //   .SwitchOnValue(string.Empty, () => DemoFunctions.ValidateEmpty(name))
            //   .SwitchOnValue(string.Empty, x => DemoFunctions.ValidateEmail(x));

            name.Flow()
               .StopOnValue(x => DemoFunctions.ValidateEmpty(x), string.Empty)
               .StopOnValue(x => DemoFunctions.ValidateEmail(x), string.Empty);

            var result = name.Flow()
               .StopOnValue(x => DemoFunctions.ValidateEmpty(x), string.Empty)
               .StopOnValue(x => DemoFunctions.ValidateEmail(x), string.Empty)
               .IfStopped(x => Console.WriteLine(x))
               .Value;

            var result2 = name.Flow()
               //.StopOnValue(() => DemoFunctionsWithErrors.ValidateEmpty(name), ReturnValues.ValueIsEmpty, fail => ReturnValues.UnknownError)
               .StopOnValue(() => DemoFunctionsWithErrors.ValidateEmail(name), ReturnValues.StringIsNotEmail)
               .IfStopped(x => Console.WriteLine(x))
               .Value;

            var result3 = name.Flow()
               //.StopOnValue(() => DemoFunctionsWithErrors.ValidateEmpty(name), ReturnValues.ValueIsEmpty, fail => ReturnValues.UnknownError)
               .StopOnValue(() => DemoFunctionsWithErrors.ValidateEmail(name), ReturnValues.StringIsNotEmail)
               .StopOnValue(() => DemoFunctionsWithErrors.Process(name), false, fail => false)
               .IfStopped(x => Console.WriteLine(x))
               .Value;


            
            var result4 = ReturnValues.Ok
              .Flow(x => DemoFunctionsWithValueBag.ValidateEmpty(name))
              .Flow(x => DemoFunctionsWithValueBag.ValidateEmail(name))
              .Flow(x => DemoFunctionsWithValueBag.Process(name), fail => fail.ToString())
              .Flow(x => DemoFunctionsWithValueBag.Process(x))
              .IfStopped(x => Console.WriteLine(x));
              


            var result5 = ReturnValues.Ok.Flow()
              .I(x => DemoFunctionsWithValueBag.ValidateEmpty(name))
              .I(x => DemoFunctionsWithValueBag.ValidateEmail(name))
              //.I(x => DemoFunctionsWithValueBag.Process(name), fail => fail.ToString())
              .I(DemoFunctionsWithValueBag.Process)
              .I(DemoFunctionsWithValueBag.Process)
              .I(DemoFunctionsWithValueBag.Process)
              .I(DemoFunctionsWithValueBag.Process)
              .IfStopped(x => Console.WriteLine(x))
              .Value;



            var result4 = ReturnValues.Ok.SideFlow<ReturnValues, string>()
              .SideFlow(() => DemoFunctionsWithValueBag.ValidateEmpty(name))
              .SideFlow(() => DemoFunctionsWithValueBag.ValidateEmail(name))
              //.Flow(x => DemoFunctionsWithValueBag.Process(name), fail => fail.ToString())
              //.Flow(x => DemoFunctionsWithValueBag.Process(x))
              .IfStopped(x => Console.WriteLine(x));

            //var result4 = FlowSharp.AsFlow(ReturnValues.Ok)
            //  .Flow(() => DemoFunctionsWithValueBag.ValidateEmpty(name), fail => ReturnValues.UnknownError)
            //  .FailOnValue(() => DemoFunctionsWithValueBag.ValidateEmail(name), ReturnValues.StringIsNotEmail)
            //  .Flow(() => DemoFunctionsWithValueBag.Process(name), fail => fail.ToString())
            //  .Flow(() => DemoFunctionsWithValueBag.Process(name))
            //  .OnFail(x => Console.WriteLine(x))
            //  .Value;


            //DemoFunctionsWithValueBag.ValidateEmpty(name).
            //var result = SharpTrack
            //    .Wrap<string, string>(DemoFunctions.ValidateName).ContinueIfEmpty(name);

            //result.Wrap<string, string>(DemoFunctions.ValidateEmail).ContinueIfEmpty(email);


            DemoFunctions.ValidateEmpty(name);
            DemoFunctions.ValidateEmail(email);
        }
    }
}
