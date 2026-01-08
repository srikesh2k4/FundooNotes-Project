using BusinessLayer.Exceptions;

namespace BusinessLayer.Rules
{
    public static class LabelRules
    {
        public static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Label name is required");
        }
    }
}
