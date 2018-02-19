using System;
using System.Collections.Generic;
using NSubstitute.Core.Arguments;

namespace NSubstitute.Exceptions
{
    public class AmbiguousArgumentsException : SubstituteException
    {
        public AmbiguousArgumentsException(IEnumerable<IArgumentSpecification> queuedSpecifications)
            : this(BuildExceptionMessage(queuedSpecifications))
        {
        }

        public AmbiguousArgumentsException(string message) : base(message)
        {
        }

        private static string BuildExceptionMessage(IEnumerable<IArgumentSpecification> queuedSpecifications)
        {
            return $"Cannot determine argument specifications to use. Please use specifications for all arguments of the same type.{Environment.NewLine}" +
                   $"All queued specifications:{Environment.NewLine}" +
                   $"{string.Join(Environment.NewLine, queuedSpecifications)}";
        }
    }
}
