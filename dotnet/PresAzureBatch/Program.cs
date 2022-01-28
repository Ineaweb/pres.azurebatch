// See https://aka.ms/new-console-template for more information

using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

using CommandLine;
using PresAzureBatch.Model;

Args resultBatchArgs = new Args();
Parser
    .Default
    .ParseArguments<Args>(args)
    .WithParsed(x => resultBatchArgs = x);

// Récupération de la variable d'environnement définit par Azure Batch : AZ_BATCH_POOL_ID
string poolID = Environment.GetEnvironmentVariable("AZ_BATCH_POOL_ID") ?? "";

// Récupération de la variable d'environnement définit dans le Job Azure Batch : JobName
string jobName = Environment.GetEnvironmentVariable("JobName") ?? "";
Console.WriteLine($"Hello & Azug Nantes {resultBatchArgs.UserName}, from {poolID}, in {jobName} job !");

// Récupération de la variable d'environnement définit dans le Job Azure Batch : KeyVaultUrl (l'url du KeyVault)
string? keyVaultUrl = Environment.GetEnvironmentVariable("KeyVaultUrl");
if(keyVaultUrl != null)
{
    Console.WriteLine($"Url of vault : {keyVaultUrl}");

    // Utilisation de la User Assigned Managed Identity pour se connecter au KeyVault.
    var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

    // Récupération du secret "SecretInformation" dans le KeyVault.
    var secretValue = client.GetSecret("SecretInformation");
    Console.WriteLine($"This is the secret found in the vault : {secretValue.Value.Value}");
}
