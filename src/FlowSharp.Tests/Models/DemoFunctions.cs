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
        public static SingleFlow<ReturnValues> ValidateEmpty(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return ReturnValues.ValueIsEmpty.Stop();

            return ReturnValues.Ok;
        }

        public static SingleFlow<ReturnValues> ValidateEmail(string email)
        {
            if (!email.Contains("@"))
                return ReturnValues.StringIsNotEmail.Stop();

            return ReturnValues.Ok;
        }


        public static SingleFlow<string> Process(string value)
        {
            return value.Flow();

            //return FlowSharp.Flow<string, ReturnValues>(value);
        }
    }

    //public class DemoFunctionsWithReturnFlow
    //{
    //    public static ReturnFlow ValidateEmpty(string value)
    //    {
    //        if (string.IsNullOrWhiteSpace(value))
    //            return ReturnValues.ValueIsEmpty.Stop();

    //        return ReturnValues.Ok.Flow();
    //    }

    //    public static ReturnFlow ValidateEmail(string email)
    //    {
    //        if (!email.Contains("@"))
    //            return ReturnValues.StringIsNotEmail.Stop();

    //        return ReturnValues.Ok;
    //    }


    //    public static SingleFlow<string> Process(string value)
    //    {
    //        return value.Flow();

    //        //return FlowSharp.Flow<string, ReturnValues>(value);
    //    }
    //}

    //public class ReturnFlow : ISingleFlow<ReturnValues, ReturnFlow>
    public class ReturnFlow : AbstractFlow<ReturnValues, ReturnFlow>
    {
        //public ReturnFlow(ReturnValues value) : base(value) { }

        //public bool IsStopped
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public ReturnValues Value
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public ReturnFlow Flow(ReturnValues value)
        //{
        //    throw new NotImplementedException();
        //}

        //public ReturnFlow Stop(ReturnValues value)
        //{
        //    throw new NotImplementedException();
        //}
        public ReturnFlow(ReturnValues value, bool isStopped = false) : base(value, isStopped)
        {
        }

        public override ReturnFlow Flow(ReturnValues value)
        {
            throw new NotImplementedException();
        }

        public override ReturnFlow Stop(ReturnValues value)
        {
            throw new NotImplementedException();
        }

        public static implicit operator ReturnValues(ReturnFlow v)
        {
            return v.Value;
        }

        public static implicit operator ReturnFlow(ReturnValues v)
        {
            return new ReturnFlow(v);
            //return SingleFlow<V>.Flow(v);
        }
    }
}
