// 代码生成时间: 2025-10-07 02:28:23
// <summary>
// Represents a simple SSL/TLS certificate manager for .NET applications.
// </summary>
using System;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace CertificateManagement
{
    public class CertificateManager
    {
        // Loads a certificate from a file path
        public X509Certificate2 LoadCertificate(string filePath)
        {
            try
            {
                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("The certificate file was not found.", filePath);
                }

                // Load the certificate from the file path
                X509Certificate2 certificate = new X509Certificate2(filePath);
                return certificate;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the loading process
                Console.WriteLine($"An error occurred while loading the certificate: {ex.Message}");
                return null;
            }
        }

        // Saves a certificate to a file path
        public void SaveCertificate(X509Certificate2 certificate, string filePath, bool overwrite = false)
        {
            try
            {
                // Check if the file already exists and whether to overwrite it
                if (File.Exists(filePath) && !overwrite)
                {
                    throw new IOException("The file already exists and overwrite is not allowed.");
                }

                // Save the certificate to the file path
                certificate.Export(X509ContentType.Pkcs12, null, out byte[] rawData);
                File.WriteAllBytes(filePath, rawData);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the saving process
                Console.WriteLine($"An error occurred while saving the certificate: {ex.Message}");
            }
        }

        // Checks if a certificate is valid
        public bool IsValidCertificate(X509Certificate2 certificate)
        {
            try
            {
                // Check if the certificate is valid at the current moment
                return certificate.Verify();
            }
            catch (CryptographicException ex)
            {
                // Handle cryptographic errors
                Console.WriteLine($"The certificate is not valid: {ex.Message}");
                return false;
            }
        }
    }
}
