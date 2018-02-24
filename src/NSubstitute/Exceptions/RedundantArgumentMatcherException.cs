using System.Collections.Generic;
using NSubstitute.Core.Arguments;
using static System.Environment;

namespace NSubstitute.Exceptions
{
    public class RedundantArgumentMatcherException : SubstituteException
    {
        private static readonly string ItemSeparator = NewLine + "    ";

        private static readonly string BaseMessage =
            "Some argument specifications (e.g. Arg.Is, Arg.Any) were left over after the last call." +
            NewLine +
            NewLine +
            "This is often caused by using an argument spec with a call to a member NSubstitute does not handle" +
            " (such as a non-virtual member or a call to an instance which is not a substitute), or for a purpose" +
            " other than specifying a call (such as using an arg spec as a return value). For example:" +
            NewLine +
            NewLine +
            "    var sub = Substitute.For<SomeClass>();" + NewLine +
            "    var realType = new MyRealType(sub);" + NewLine +
            "    // INCORRECT, arg spec used on realType, not a substitute:" + NewLine +
            "    realType.SomeMethod(Arg.Any<int>());" + NewLine +
            "    // INCORRECT, arg spec used as a return value, not to specify a call:" + NewLine +
            "    sub.VirtualMethod(2).Returns(Arg.Any<int>());" + NewLine +
            "    // INCORRECT, arg spec used with a non-virtual method:" + NewLine +
            "    sub.NonVirtualMethod(Arg.Any<int>()).Returns(2);" + NewLine +
            "    // CORRECT, arg spec used to specify virtual call on a substitute:" + NewLine +
            "    sub.VirtualMethod(Arg.Any<int>()).Returns(2);" + NewLine +
            NewLine +
            "To fix this make sure you only use argument specifications with calls to substitutes. If your substitute" +
            " is a class, make sure the member is virtual." +
            NewLine +
            NewLine +
            "Another possible cause is that the argument spec type does not match the actual argument type," +
            " but code compiles due to an implicit cast. For example, Arg.Any<int>() was used, but Arg.Any<double>()" +
            " was required." +
            NewLine +
            NewLine +
            "NOTE: the cause of this exception can be in a previously executed test. Use the diagnostics below to see the" +
            " types of any redundant arg specs, then work out where they are being created." +
            NewLine +
            NewLine +
            "Diagnostic information:" +
            NewLine +
            NewLine;

        public RedundantArgumentMatcherException(IEnumerable<IArgumentSpecification> remainingSpecifications,
            IEnumerable<IArgumentSpecification> allSpecifications)
            : this(FormatErrorMessage(remainingSpecifications, allSpecifications))
        {
        }

        public RedundantArgumentMatcherException(string message) : base(message)
        {
        }

        private static string FormatErrorMessage(IEnumerable<IArgumentSpecification> remainingSpecifications,
            IEnumerable<IArgumentSpecification> allSpecifications)
        {
            return
                BaseMessage +
                $"Remaining (non-bound) argument specifications:{ItemSeparator}" +
                $"{string.Join(ItemSeparator, remainingSpecifications)}{NewLine}" +
                NewLine +
                $"All argument specifications:{ItemSeparator}" +
                $"{string.Join(ItemSeparator, allSpecifications)}" +
                NewLine;
        }
    }
}