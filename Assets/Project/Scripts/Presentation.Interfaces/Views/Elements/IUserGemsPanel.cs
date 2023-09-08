using JetBrains.Annotations;
using PromoTest.Project.BusinessLogic.Interfaces.Services;

namespace PromoTest.Project.Presentation.Interfaces.Views
{
    public interface IUserGemsPanel
    {
        void Initialize([NotNull] IUserService userService);
    }
}