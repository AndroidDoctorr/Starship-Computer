
namespace Assets.Scripts.Computer.Auth
{
    public class IdentityManager
    {
        // TODO: Return a response object instead of a bool???
        public bool ValidateIdentity()
        {
            // MFA Layers:

            // Biometrics
            // - Retina
            // - Fingerprint
            // - Vascular pattern
            // - Face
            // - Voice
            // - DNA
            // Comm Badge (Device)
            // Location Tracking
            // - Unique Location
            // - Consistent History
            // Password (for command functions)
            return true;
        }
        public Identity CreateIdentity()
        {
            return new Identity();
        }
    }
}
