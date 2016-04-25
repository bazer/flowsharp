using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlowSharp.Tests
{
    [TestClass]
    public class TestBasics
    {
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

            FlowSharp.AsFlow(name)
               .FailOnValue(x => DemoFunctions.ValidateEmpty(x), string.Empty)
               .FailOnValue(x => DemoFunctions.ValidateEmail(x), string.Empty);

            var result = name.AsFlow()
               .FailOnValue(x => DemoFunctions.ValidateEmpty(x), string.Empty)
               .FailOnValue(x => DemoFunctions.ValidateEmail(x), string.Empty)
               .HandleFailure(x => Console.WriteLine(x))
               .Value;

            var result2 = name.AsFlow()
               .FailOnValue(() => DemoFunctionsWithErrors.ValidateEmpty(name), ReturnValues.ValueIsEmpty, fail => ReturnValues.UnknownError)
               .FailOnValue(() => DemoFunctionsWithErrors.ValidateEmail(name), ReturnValues.StringIsNotEmail)
               .HandleFailure(x => Console.WriteLine(x))
               .Value;

            var result3 = name.AsFlow()
               .FailOnValue(() => DemoFunctionsWithErrors.ValidateEmpty(name), ReturnValues.ValueIsEmpty, fail => ReturnValues.UnknownError)
               .FailOnValue(() => DemoFunctionsWithErrors.ValidateEmail(name), ReturnValues.StringIsNotEmail)
               .FailOnValue(() => DemoFunctionsWithErrors.Process(name), false, fail => false)
               .HandleFailure(x => Console.WriteLine(x))
               .Value;


            var result4 = FlowSharp.AsFlow(ReturnValues.Ok)
              .Flow(x => DemoFunctionsWithValueBag.ValidateEmpty(name))
              .Flow(x => DemoFunctionsWithValueBag.ValidateEmail(name))
              .Flow(x => DemoFunctionsWithValueBag.Process(name), fail => fail.ToString())
              .Flow(x => DemoFunctionsWithValueBag.Process(x))
              .HandleFailure(x => Console.WriteLine(x))
              .Value;


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
