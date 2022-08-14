// <summary>
// <copyright file="ForbiddenException.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Users.Resources.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Class Forbidden Exception.
    /// </summary>
    [Serializable]
    public class ForbiddenException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        public ForbiddenException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="message">Message Exception.</param>
        public ForbiddenException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="message">Message Exception.</param>
        /// <param name="innerException">Inner Exception.</param>
        public ForbiddenException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="info">info.</param>
        /// <param name="context">context.</param>
        protected ForbiddenException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}