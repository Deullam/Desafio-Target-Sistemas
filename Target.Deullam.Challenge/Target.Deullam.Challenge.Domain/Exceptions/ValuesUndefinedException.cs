namespace Target.Deullam.Challenge.Domain.Exceptions
{
    public class ValuesUndefinedException : BusinessException
    {
        public ValuesUndefinedException() : base("Values not informed or equal to 0!")
        {
        }
    }
}
