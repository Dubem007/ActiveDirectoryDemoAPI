using ActiveDirectoryDemoAPI.Model;
using AutoMapper;
using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ActiveDirectoryDemoAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
       // private readonly IMapper _mapper;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
           // _mapper = mapper;

        }

        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            
            var clientId = _configuration.GetSection("AzureAd:ClientId").Value;
            var tenantId = _configuration.GetSection("AzureAd:TenantId").Value;
            var clientSecret = _configuration.GetValue<string>("AzureAd:ClientSecret");

            var clientSecretCredentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
            GraphServiceClient graphServiceClient = new GraphServiceClient(clientSecretCredentials);

            var users = graphServiceClient.Users.Request().GetAsync().Result;

            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var clientId = _configuration.GetSection("AzureAd:ClientId").Value;
            var tenantId = _configuration.GetSection("AzureAd:TenantId").Value;
            var clientSecret = _configuration.GetValue<string>("AzureAd:ClientSecret");

            var clientSecretCredentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
            GraphServiceClient graphServiceClient = new GraphServiceClient(clientSecretCredentials);

            var users = graphServiceClient.Users[$"{id}"].Request().GetAsync().Result;

            return Ok(users);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserDetail value)
        {
            
            var clientId = _configuration.GetSection("AzureAd:ClientId").Value;
            var tenantId = _configuration.GetSection("AzureAd:TenantId").Value;
            var clientSecret = _configuration.GetValue<string>("AzureAd:ClientSecret");

            // using Azure.Identity;
            var options = new TokenCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            };

            var clientSecretCredentials = new ClientSecretCredential(tenantId, clientId, clientSecret, options);
            GraphServiceClient graphServiceClient = new GraphServiceClient(clientSecretCredentials);

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                AccountEnabled = value.AccountEnabled,
                DisplayName = value.DisplayName,
                MailNickname = value.MailNickname,
                UserPrincipalName = value.UserPrincipalName,
                GivenName = value.GivenName,
                Mail = value.Mail,
                Surname = value.Surname,
                City = value.City,
                CompanyName = value.CompanyName,
                Country = value.Country,
                EmployeeHireDate = value.employeeHireDate,
                EmployeeId = value.employeeId,
                EmployeeType = value.employeeType,
                JobTitle = value.jobTitle,
                MobilePhone = value.mobilePhone,
                ODataType = value.odatatype,
                PasswordProfile = new PasswordProfile
                {
                    ForceChangePasswordNextSignIn = true,
                    Password = value.password
                }

            };
            //var response = _mapper.Map<User>(value);
            await graphServiceClient.Users.Request().AddAsync(user);
            return Ok(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UserDetail value)
        {
            var clientId = _configuration.GetSection("AzureAd:ClientId").Value;
            var tenantId = _configuration.GetSection("AzureAd:TenantId").Value;
            var clientSecret = _configuration.GetValue<string>("AzureAd:ClientSecret");

            var options = new TokenCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            };

            var clientSecretCredentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
            GraphServiceClient graphServiceClient = new GraphServiceClient(clientSecretCredentials);

            var users = graphServiceClient.Users[$"{id}"].Request().GetAsync().Result;

            var user = new User
            {
                
                AccountEnabled = value.AccountEnabled,
                DisplayName = value.DisplayName,
                MailNickname = value.MailNickname,
                UserPrincipalName = value.UserPrincipalName,
                GivenName = value.GivenName,
                Mail = value.Mail,
                Surname = value.Surname,
                City = value.City,
                CompanyName = value.CompanyName,
                Country = value.Country,
                EmployeeHireDate = value.employeeHireDate,
                EmployeeId = value.employeeId,
                EmployeeType = value.employeeType,
                JobTitle = value.jobTitle,
                MobilePhone = value.mobilePhone,
                ODataType = value.odatatype,
                PasswordProfile = new PasswordProfile
                {
                    ForceChangePasswordNextSignIn = true,
                    Password = value.password
                }

            };
            await graphServiceClient.Users[$"{id}"].Request().UpdateAsync(user);
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var clientId = _configuration.GetSection("AzureAd:ClientId").Value;
            var tenantId = _configuration.GetSection("AzureAd:TenantId").Value;
            var clientSecret = _configuration.GetValue<string>("AzureAd:ClientSecret");

            var clientSecretCredentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
            GraphServiceClient graphServiceClient = new GraphServiceClient(clientSecretCredentials);

            graphServiceClient.Users[$"{id}"].Request().DeleteAsync();
        }
    }
}
