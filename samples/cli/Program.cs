﻿using Ibanity.Apis.Client;
using Ibanity.Apis.Sample.CLI;

Console.WriteLine("Loading configuration");

var configuration = Configuration.BuildFromEnvironment();

Console.WriteLine("Building service...");

var ibanityService = new IbanityServiceBuilder().
    SetEndpoint(configuration.Endpoint).
    AddClientCertificate(
        configuration.MtlsCertificatePath,
        configuration.MtlsCertificatePassword).
    AddSignatureCertificate(
        configuration.SignatureCertificateId,
        configuration.SignatureCertificatePath,
        configuration.SignatureCertificatePassword).
    AddPontoConnectOAuth2Authentication(
        configuration.PontoConnectClientId,
        configuration.PontoConnectClientSecret).
    EnableRetries().
    AddLogging(new ConsoleLogger()).
    Build();

var cancellationTokenSource = new CancellationTokenSource();
Console.CancelKeyPress += (s, e) =>
{
    Console.WriteLine("Canceling...");
    cancellationTokenSource.Cancel();
    e.Cancel = true;
};

Console.WriteLine("Running client sample...");
var clientSample = new ClientSample(configuration, ibanityService);
await clientSample.Run(cancellationTokenSource.Token);
