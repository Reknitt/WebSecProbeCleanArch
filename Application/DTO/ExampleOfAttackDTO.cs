using Presentation.Domain.Entities.VulnerabilityEntities;

namespace WebSecProbeCleanArch.Application.DTO
{
    public class ExampleOfAttackDTO
    {
        public int Id { get; set; }
        public List<StepOfAttack> StepsOfAttack { get; set; }
    }
}
