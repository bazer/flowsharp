using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp.Tests
{
    public class DemoFunctions
    {
        public static string ValidateEmpty(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "Value is empty";

            return string.Empty;
        }

        public static string ValidateEmail(string email)
        {
            if (!email.Contains("@"))
                return "String is not email";

            return string.Empty;
        }
    }

    public enum ReturnValues
    {
        Ok,
        ValueIsEmpty,
        StringIsNotEmail,
        UnknownError
    }

    public class DemoFunctionsWithErrors
    {


        public static ReturnValues ValidateEmpty(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return ReturnValues.ValueIsEmpty;

            return ReturnValues.Ok;
        }

        public static ReturnValues ValidateEmail(string email)
        {
            if (!email.Contains("@"))
                return ReturnValues.StringIsNotEmail;

            return ReturnValues.Ok;
        }


        public static bool Process(string value)
        {
            return true;
        }
    }

    public class DemoFunctionsWithValueBag
    {


        public static IFlowValue<ReturnValues> ValidateEmpty(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return ReturnValues.ValueIsEmpty.AsFail();

            return ReturnValues.Ok.AsFlow();
        }

        public static IFlowValue<ReturnValues> ValidateEmail(string email)
        {
            if (!email.Contains("@"))
                return ReturnValues.StringIsNotEmail.AsFail();

            return ReturnValues.Ok.AsFlow();
        }


        public static IFlowValue<string> Process(string value)
        {
            return value.AsFlow();

            //return FlowSharp.Flow<string, ReturnValues>(value);
        }
    }
}
