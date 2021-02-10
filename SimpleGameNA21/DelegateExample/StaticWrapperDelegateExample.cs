using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGameNA21.DelegateExample
{
    public class StaticWrapperDelegateExample
    {
        private Func<string, bool> _delegate;

        public StaticWrapperDelegateExample()
        {
            _delegate = DoSomething.CheckLength;
        }

        public StaticWrapperDelegateExample(Func<string, bool> func)
        {
            _delegate = func;
        }

        public string IsTrue(string input)
        {
            return _delegate(input) ? "OK" : "NOTOK";
        }

    }

    public static class DoSomething
    {
        public static bool CheckLength(string input)
        {
            return input.Length == 10;
        }
    }
}
