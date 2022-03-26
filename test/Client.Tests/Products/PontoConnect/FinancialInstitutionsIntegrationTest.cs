using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Ibanity.Apis.Client.Http;
using Ibanity.Apis.Client.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ibanity.Apis.Client.Tests.Http
{
    [TestClass]
    public class FinancialInstitutionsIntegrationTest
    {
        [TestMethod]
        public async Task AbleToAuthenticateAndGetFinancialInstitutions()
        {
            var certificatePath = Environment.GetEnvironmentVariable("MTLS_CERTIFICATE_PATH");
            var certificatePassword = Environment.GetEnvironmentVariable("MTLS_CERTIFICATE_PASSWORD");

            if (string.IsNullOrWhiteSpace(certificatePath) || string.IsNullOrWhiteSpace(certificatePassword))
                Assert.Inconclusive("Missing 'MTLS_CERTIFICATE_PATH' or 'MTLS_CERTIFICATE_PASSWORD' environment variables");

            var signatureCertificatePath = Environment.GetEnvironmentVariable("SIGNATURE_CERTIFICATE_PATH");
            var signatureCertificatePassword = Environment.GetEnvironmentVariable("SIGNATURE_CERTIFICATE_PASSWORD");

            if (string.IsNullOrWhiteSpace(signatureCertificatePath) || string.IsNullOrWhiteSpace(signatureCertificatePassword))
                Assert.Inconclusive("Missing 'SIGNATURE_CERTIFICATE_PATH' or 'SIGNATURE_CERTIFICATE_PASSWORD' environment variables");

            Uri endpoint = new Uri("https://api.ibanity.com");

            var builder = new IbanityServiceBuilder();
            var ibanityService = builder.Build(
                endpoint,
                null,
                new X509Certificate2(certificatePath, certificatePassword),
                new X509Certificate2(signatureCertificatePath, signatureCertificatePassword),
                "7705c535-e9b4-416d-9a4a-97337b24fa1b",
                "", "", "", "", new Uri("https://fake-tpp.com/ponto-authorization"), null); // OAuth2 not yet implemented

            Guid id = Guid.Parse("433329cb-3a66-4d47-8387-98bdaa5e55ad");
            var financialInstitution = await ibanityService.PontoConnect.FinancialInstitutions.Get(id);
            Assert.IsNotNull(financialInstitution);

            var filters = new[] { new Filter("name", FilterOperator.Like, "gring") };
            var financialInstitutions = await ibanityService.PontoConnect.FinancialInstitutions.List(filters);
            Assert.IsNotNull(financialInstitutions);
        }
    }
}
