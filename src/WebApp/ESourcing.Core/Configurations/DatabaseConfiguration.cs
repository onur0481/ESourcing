namespace ESourcing.Core.Configurations
{
    public class DatabaseConfiguration
    {
        public string IdentityConnectionStrings { get; private set; }

        public DatabaseConfiguration(string identityConnectionStrings)
        {
            IdentityConnectionStrings = identityConnectionStrings;
        }
    }
}
