using AWSLambdaFunction.Interfaces;
using AWSLambdaFunction.Object;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using VogCodeChallenge.BLL.Interfaces;
using VogCodeChallenge.BLL.Models;

namespace VogCodeChallenge.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IVogCodeChallengeAPIHandler vogCodeChallengeAPIHandler;
        private readonly ILambdaFunctionHandler lambdaFunctionHandler;


        public EmployeeController(IVogCodeChallengeAPIHandler vogCodeChallengeAPIHandler, ILambdaFunctionHandler lambdaFunctionHandler,  ILogger<EmployeeController> logger)
        {
            this.vogCodeChallengeAPIHandler = vogCodeChallengeAPIHandler;
            this.lambdaFunctionHandler = lambdaFunctionHandler;
            this.logger = logger;
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>A <see cref="Employee"/> Representing the asynchronous operation.</returns>
        [Produces("application/json")]
        [SwaggerResponse(200, "successfully retrieved", typeof(IEnumerable<Employee>))]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        [Route("employees")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var type = this.GetType().Name;

            this.logger.LogInformation($"Begin {type}.{methodName}");

            var ret = this.vogCodeChallengeAPIHandler.GetAll();

            this.logger.LogInformation($"End {type}.{methodName}");
            return this.Ok(ret);
        }

        /// <summary>
        /// List all employees
        /// </summary>
        /// <returns>A <see cref="Employee"/> Representing the asynchronous operation.</returns>
        [Produces("application/json")]
        [SwaggerResponse(200, "successfully retrieved", typeof(IEnumerable<Employee>))]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        [Route("employees/listAll")]
        [HttpGet]
        public async Task<IActionResult> ListAllEmployees()
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var type = this.GetType().Name;

            this.logger.LogInformation($"Begin {type}.{methodName}");

            var ret = this.vogCodeChallengeAPIHandler.ListAll();

            this.logger.LogInformation($"End {type}.{methodName}");
            return this.Ok(ret);
        }

        /// <summary>
        /// Get specific department employees
        /// </summary>
        /// <param name="departmentId">departmentId</param>
        /// <returns>A <see cref="Employee"/> Representing the asynchronous operation.</returns>
        [Produces("application/json")]
        [SwaggerResponse(200, "successfully retrieved", typeof(IEnumerable<Employee>))]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        [Route("employees/department/{departmentId}")]
        [HttpGet]
        public async Task<IActionResult> GetAll(int departmentId)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var type = this.GetType().Name;

            this.logger.LogInformation($"Begin {type}.{methodName}");

            this.logger.LogDebug($"{type}.{methodName} - Parms - departmentId = {departmentId}");

            var ret = this.vogCodeChallengeAPIHandler.ListAll();

            this.logger.LogInformation($"End {type}.{methodName}");
            return this.Ok(ret);
        }

        /// <summary>
        /// List specific department employees
        /// </summary>
        /// <param name="departmentId">departmentId</param>
        /// <returns>A <see cref="Employee"/> Representing the asynchronous operation.</returns>
        [Produces("application/json")]
        [SwaggerResponse(200, "successfully retrieved", typeof(IEnumerable<Employee>))]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        [Route("employees/department/{departmentId}/ListAll")]
        [HttpGet]
        public async Task<IActionResult> ListAll(int departmentId)
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var type = this.GetType().Name;

            this.logger.LogInformation($"Begin {type}.{methodName}");

            this.logger.LogDebug($"{type}.{methodName} - Parms - departmentId = {departmentId}");

            var ret = this.vogCodeChallengeAPIHandler.ListAll(departmentId);

            this.logger.LogInformation($"End {type}.{methodName}");
            return this.Ok(ret);
        }

        /// <summary>
        /// Get aws Lambda function log
        /// </summary>
        /// <returns>A <see cref="Employee"/> Representing the asynchronous operation.</returns>
        [Produces("application/json")]
        [SwaggerResponse(200, "successfully retrieved", typeof(IEnumerable<Log>))]
        [SwaggerOperation(Tags = new[] { "AWS" })]
        [Route("lambdaFunction")]
        [HttpGet]
        public async Task<IActionResult> GetLambdaFunctionLog()
        {
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var type = this.GetType().Name;

            this.logger.LogInformation($"Begin {type}.{methodName}");

            var ret = this.lambdaFunctionHandler.RunLambdaFunction();

            this.logger.LogInformation($"End {type}.{methodName}");
            return this.Ok(ret);
        }

    }
}
