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
                $"It could mean that previously you passed specification to a method, which is not handled" +
                $" by the NSubstitute (e.g. method is not virtual, or doesn't belong to a substitute). Another reason" +
                $" might be that argument specification type doesn't match the actual argument type, but code compiles due" +
                $" to an implicit cast (e.g. between 'int' and 'double'). In any case this exception is an indication" +
                $" of the unexpected NSubstitute usage and most likely your test code behaves not as intended.{Environment.NewLine}" +
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