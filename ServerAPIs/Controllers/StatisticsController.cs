using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerServer.Core;

namespace ServerAPIs
{
    /// <summary>
    /// Statistics information query API
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]

    // Sets the authorization policy
    // The default policy is the one used by PowerServer Web APIs
    // For security concern, it is recommended to use different authorization policies for PowerServer Web APIs and management APIs
    // see https://docs.microsoft.com/en-us/aspnet/core/security/authorization/policies
    [Authorize(PowerServerConstants.DefaultAuthorizePolicy)]

    // Sets the return data type of the API
    [Produces(MediaTypeNames.Application.Json)]
    // Sets the data type when the API returns error
    [ProducesErrorResponseType(typeof(ValidationProblemDetails))]

    // Sets the possible response statuses and their data types of the API
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(object))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
    public class StatisticsController : ControllerBase
    {
        private readonly IPowerServerStatisticsClient _statisticsClient;

        public StatisticsController(IPowerServerService service)
        {
            _statisticsClient = service.StatisticsClient;
        }

        /// <summary>
        /// Loads the summary statistics of all requests
        /// </summary>
        /// <returns></returns>
        // GET api/statistics/loadrequestsummarystatistics
        [HttpGet]
        public IRequestSummaryStatistics LoadRequestSummaryStatistics()
        {
            return _statisticsClient.GetRequestSummaryStatistics();
        }

        /// <summary>
        /// Loads the detailed statistics of the requests in the specified category
        /// </summary>
        /// <param name="failedOnly">Failed requests</param>
        /// <returns></returns>
        // GET api/statistics/loadrequestsstatistics/true
        [HttpGet("{failedOnly}")]
        public IReadOnlyList<IRequestStatistics> LoadRequestsStatistics(bool failedOnly)
        {
            return _statisticsClient.GetRequestsStatistics(failedOnly);
        }

        /// <summary>
        /// Loads transaction statistics
        /// </summary>
        /// <returns></returns>
        // GET api/statistics/loadtransactionsummarystatistics
        [HttpGet]
        public ITransactionSummaryStatistics LoadTransactionSummaryStatistics()
        {
            return _statisticsClient.GetTransactionSummaryStatistics();
        }

        /// <summary>
        /// Loads the detailed statistics of failed transactions
        /// </summary>
        /// <returns></returns>
        // GET api/statistics/loadfailedtransactionsstatistics
        [HttpGet]
        public IReadOnlyList<ITransactionStatistics> LoadFailedTransactionsStatistics()
        {
            return _statisticsClient.GetFailedTransactionsStatistics();
        }

        /// <summary>
        /// Loads the detailed statistics of successful transactions
        /// </summary>
        /// <returns></returns>
        // GET api/statistics/loadsucceedtransactionsstatistics
        [HttpGet]
        public IReadOnlyList<ITransactionStatistics> LoadSucceedTransactionsStatistics()
        {
            return _statisticsClient.GetSucceedTransactionsStatistics();
        }
    }
}
