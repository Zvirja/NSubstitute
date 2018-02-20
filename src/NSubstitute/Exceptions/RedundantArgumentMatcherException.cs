using System;
using System.Collections.Generic;
using NSubstitute.Core.Arguments;

namespace NSubstitute.Exceptions
{
    public class RedundantArgumentMatcherException : SubstituteException
    {
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
                $"Not all the argument specifications (e.g. Arg.Is, Arg.Any) were bound during the last call.{Environment.NewLine}" +
                $"Usually, it means that previously you passed specifications to methods, which are not handled" +
                $" by the NSubstitute (e.g. methods are not virtual, or don't belong to a substitute)." +
                $" That is an indication of the invalid NSubstitute usage and most likely your test code behaves not as you expect.{Environment.NewLine}" +
                $"Please use the diagnostics information below to detect and fix the defective places.{Environment.NewLine}" +
                $"{Environment.NewLine}" +
                $"Remaining (non-bound) argument specifications:{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, remainingSpecifications)}{Environment.NewLine}" +
                $"{Environment.NewLine}" +
                $"All argument specifications:{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, allSpecifications)}";
        }
    }
}