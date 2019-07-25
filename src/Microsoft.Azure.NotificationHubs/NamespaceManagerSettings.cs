﻿using System;
using Microsoft.Azure.NotificationHubs.Auth;

namespace Microsoft.Azure.NotificationHubs
{
    internal sealed class NamespaceManagerSettings
    {
        private int getEntitiesPageSize;
        private TimeSpan operationTimeout;
        private readonly TimeSpan MaxOperationTimeout = TimeSpan.FromDays(1);
        private RetryPolicy retryPolicy;

        public NamespaceManagerSettings()
        {
            operationTimeout = TimeSpan.FromMinutes(1.0);
            getEntitiesPageSize = int.MaxValue;
            TokenProvider = null;
        }

        /// <summary>
        /// Gets or sets the operation timeout.
        /// </summary>
        /// <value>
        /// The operation timeout. It sets the timeout period for all of Namespace management operations, such as GetQueue, CreteQueue, etc.
        /// </value>
        /// <exception cref="ArgumentNullException">throws if a null is set - e.g. a nullable TimeSpan.</exception>
        /// <exception cref="ArgumentOutOfRangeException">throws when a zero or negative TimeSpan is set.</exception>
        public TimeSpan OperationTimeout
        {
            get
            {
                return operationTimeout;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("OperationTimeout");
                }

                if (value < TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException("OperationTimeout");
                }

                operationTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the security token provider.
        /// </summary>
        /// 
        /// <returns>
        /// The security token provider.
        /// </returns>
        public TokenProvider TokenProvider { get; set; }

        internal TimeSpan InternalOperationTimeout
        {
            get { return operationTimeout > MaxOperationTimeout ? MaxOperationTimeout : operationTimeout; }
        }

        internal int GetEntitiesPageSize
        {
            get
            {
                return getEntitiesPageSize;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("GetEntitiesPageSize has to be positive value");
                }

                getEntitiesPageSize = value;
            }
        }

    }
}
