using System;
using System.Linq.Expressions;
using NSubstitute.Core;
using NSubstitute.Core.Arguments;

namespace NSubstitute
{
    /// <summary>
    /// Alternate version of <see cref="Arg"/> matchers for compatibility with pre-C#7 compilers
    /// which do not support <c>ref</c> return types. Do not use unless you are unable to use <see cref="Arg"/>.
    /// </summary>
    public static class CompatArg
    {
        /// <summary>
        /// Match any argument value compatible with type <typeparamref name="T"/>.
        /// This is provided for compatibility with older compilers --
        /// if possible use <see cref="Arg.Any{T}" /> instead.
        /// </summary>
        public static T Any<T>()
        {
            return Arg.Any<T>();
        }

        /// <summary>
        /// Match argument that is equal to <paramref name="value"/>.
        /// This is provided for compatibility with older compilers --
        /// if possible use <see cref="Arg.Is{T}(T)" /> instead.
        /// </summary>
        public static T Is<T>(T value)
        {
            return Arg.Is(value);
        }

        /// <summary>
        /// Match argument that satisfies <paramref name="predicate"/>. 
        /// If the <paramref name="predicate"/> throws an exception for an argument it will be treated as non-matching.
        /// This is provided for compatibility with older compilers --
        /// if possible use <see cref="Arg.Is{T}(Expression{Predicate{T}})" /> instead.
        /// </summary>
        public static T Is<T>(Expression<Predicate<T>> predicate)
        {
            return Arg.Is(predicate);
        }

        /// <summary>
        /// Invoke any <see cref="Action"/> argument whenever a matching call is made to the substitute.
        /// This is provided for compatibility with older compilers --
        /// if possible use <see cref="Arg.Invoke" /> instead.
        /// </summary>
        public static Action Invoke()
        {
            return Arg.Invoke();
        }

        /// <summary>
        /// Invoke any <see cref="Action&lt;T&gt;"/> argument with specified argument whenever a matching call is made to the substitute.
        /// This is provided for compatibility with older compilers --
        /// if possible use <see cref="Arg.Invoke{T}" /> instead.
        /// </summary>
        public static Action<T> Invoke<T>(T arg)
        {
            return Arg.Invoke(arg);
        }

        /// <summary>
        /// Invoke any <see cref="Action&lt;T1,T2&gt;"/> argument with specified arguments whenever a matching call is made to the substitute.
        /// This is provided for compatibility with older compilers --
        /// if possible use <see cref="Arg.Invoke{T1,T2}" /> instead.
        /// </summary>
        public static Action<T1, T2> Invoke<T1, T2>(T1 arg1, T2 arg2)
        {
            return Arg.Invoke(arg1, arg2);
        }

        /// <summary>
        /// Invoke any <see cref="Action&lt;T1,T2,T3&gt;"/> argument with specified arguments whenever a matching call is made to the substitute.
        /// This is provided for compatibility with older compilers --
        /// if possible use <see cref="Arg.Invoke{T1,T2,T3}" /> instead.
        /// </summary>
        public static Action<T1, T2, T3> Invoke<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3)
        {
            return Arg.Invoke(arg1, arg2, arg3);
        }

        /// <summary>
        /// Invoke any <see cref="Action&lt;T1,T2,T3,T4&gt;"/> argument with specified arguments whenever a matching call is made to the substitute.
        /// This is provided for compatibility with older compilers --
        /// if possible use <see cref="Arg.Invoke{T1,T2,T3,T4}" /> instead.
        /// </summary>
        public static Action<T1, T2, T3, T4> Invoke<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return Arg.Invoke(arg1, arg2, arg3, arg4);
        }

        /// <summary>
        /// Invoke any <typeparamref name="TDelegate"/> argument with specified arguments whenever a matching call is made to the substitute.
        /// This is provided for compatibility with older compilers --
        /// if possible use <see cref="Arg.InvokeDelegate{TDelegate}" /> instead.
        /// </summary>
        /// <param name="arguments">Arguments to pass to delegate.</param>
        public static TDelegate InvokeDelegate<TDelegate>(params object[] arguments)
        {
            return Arg.InvokeDelegate<TDelegate>(arguments);
        }

        /// <summary>
        /// Capture any argument compatible with type <typeparamref name="T"/> and use it to call the <paramref name="useArgument"/> function 
        /// whenever a matching call is made to the substitute.
        /// This is provided for compatibility with older compilers --
        /// if possible use <see cref="Arg.Do{T}" /> instead.
        /// </summary>
        public static T Do<T>(Action<T> useArgument)
        {
            return Arg.Do(useArgument);
        }
    }
}
